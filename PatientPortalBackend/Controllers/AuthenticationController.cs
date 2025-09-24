using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatientPortalBackend.Access;
using PatientPortalBackend.DbModels;
using PatientPortalBackend.Models;
using PatientPortalBackend.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;
using PatientPortalBackend.Utils;

namespace PatientPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : PortalBaseController
    {
        public AuthenticationController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings) : base(httpClientFactory, portalSettings)
        {
        }

        [HttpPost]
        [Route("GetConfirmationCode")]
        public async Task<ServiceGetConfirmationCodeResponse> GetConfirmationCode(
            ServiceGetConfirmationCodeRequest request)
        {
            var patHash = GetHashValueOfPatientToAuthenticate(request);
            var todayDate = DateTime.Now.Date;
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var existingEntry = context.PatientAuthentication.FirstOrDefault(p =>
                    p.PatientHash == patHash &&
                    p.DateTried == todayDate);

                if (existingEntry != null && existingEntry.TryCount > 3)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceGetConfirmationCodeResponse>("B199",
                        "You already tried to log in 4 times today. You are blocked until tomorrow!");
                }
            }


            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetConfirmationCodeResponse>(errorCode,
                    errorMsg);
            }

            if (!ValidateGetConfirmationCodeRequest(request, out errorCode, out errorMsg))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetConfirmationCodeResponse>(errorCode,
                    errorMsg);
            }

            var patRequest =
                BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPatientForPatientPortalRequest>(_portalSettings,
                    mcBaseRequest);
            patRequest.IdNumber = request.IdNumber;
            patRequest.Email = request.Email;
            patRequest.DateOfBirth = request.DateOfBirth;

            Patient patientRecord;
            var patResponse =
                await BasicServiceWebHelper
                    .CallMedCubesServiceAsync<ServiceGetPatientForPatientPortalResponse,
                        ServiceGetPatientForPatientPortalRequest>(_httpClientFactory, patRequest, iisUrl,
                        "Patient/GetPatientForPatientPortal");

            if (!patResponse.Success)
            {
                //Increase tryCount of authentication
                if (patResponse.ErrorCode == "B104")
                {
                    using (var context = new MedCubes_PatientPortalBackendEntities())
                    {
                        var existing = context.PatientAuthentication.FirstOrDefault(p =>
                            p.PatientHash == patHash &&
                            p.DateTried == todayDate);

                        if (existing != null)
                        {
                            existing.TryCount++;
                        }
                        else
                        {
                            var newEntry = new PatientAuthentication();
                            newEntry.PatientHash = patHash;
                            newEntry.DateTried = todayDate;
                            newEntry.TryCount = 1;
                            Guid tenGuid;
                            if (Guid.TryParse(request.TenantKey, out tenGuid))
                            {
                                newEntry.TenantGuid = tenGuid;
                            }

                            context.PatientAuthentication.Add(newEntry);
                        }

                        var saved = context.SaveChanges();
                    }
                }

                return
                    BasicServiceWebHelper.CreateFaultResponse<ServiceGetConfirmationCodeResponse>(
                        patResponse.ErrorCode, patResponse.ServiceMessages.ToList());
            }

            patientRecord = patResponse.PatientRecord;

            //Create confirmation code and save into DB
            var generator = new Random();
            var confirmationCode = generator.Next(0, 1000000).ToString("D6");

            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var existingRecord =
                    context.PatientExtension.FirstOrDefault(p => p.PatientId == patientRecord.PatientId &&
                                                                 p.CustomerId == mcBaseRequest.ClientCustomerId &&
                                                                 p.TenantId == mcBaseRequest.ClientTenantId);

                if (existingRecord != null)
                {
                    ServiceGetConfirmationCodeResponse respo;
                    if (AccessChecker.IsAccessDenied(existingRecord, out respo))
                    {
                        return respo;
                    }

                    existingRecord.ConfirmationCode = confirmationCode;
                    existingRecord.ConfirmationCodeCreated = DateTimeOffset.Now;
                }
                else
                {
                    var newEntry = new PatientExtension();
                    newEntry.CustomerId = mcBaseRequest.ClientCustomerId;
                    newEntry.TenantId = mcBaseRequest.ClientTenantId;
                    newEntry.ConfirmationCode = confirmationCode;
                    newEntry.ConfirmationCodeCreated = DateTimeOffset.Now;
                    newEntry.IsDisclaimerAccepted = false;
                    newEntry.PatientId = patientRecord.PatientId;
                    context.PatientExtension.Add(newEntry);
                }

                var saved = context.SaveChanges();
            }

            ////Patient found -> send an email
            //var sendMailRequest = new ServiceSendMailRequest();
            //sendMailRequest.ClientCustomerId = mcBaseRequest.ClientCustomerId;
            //sendMailRequest.ClientTenantId = mcBaseRequest.ClientTenantId;
            //sendMailRequest.ClientUserId = mcBaseRequest.ClientUserId;
            //sendMailRequest.ClientUserName = mcBaseRequest.ClientUserName;
            //sendMailRequest.ClientToken = mcBaseRequest.ClientToken;
            //sendMailRequest.TransactionId = Guid.Parse(_portalSettings.MedCubesTransactionId);
            //var mailContainer = new MailContainer();
            //mailContainer.From = _portalSettings.EmailFrom;
            //mailContainer.To = new List<string>{patientRecord.Email};
            //mailContainer.Subject =
            //    "Confirmation for Patient Portal"; //TODO cz config?? Language?? maybe from patient culture or language?
            //mailContainer.Body = String.Format("Enter the following confirmation code at the application: {0}",
            //    confirmationCode);
            //sendMailRequest.MailContainer = mailContainer;

            //var mailResp =
            //    await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceSendMailResponse, ServiceSendMailRequest>(
            //        _httpClientFactory, sendMailRequest, iisUrl, "MailCommunication/SendMail");

            //if (!mailResp.Success)
            //{
            //    return
            //        BasicServiceWebHelper.CreateFaultResponse<ServiceGetConfirmationCodeResponse>(
            //            mailResp.ErrorCode, mailResp.ServiceMessages);
            //}

            var resp = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetConfirmationCodeResponse>();
            resp.PatientId = patientRecord.PatientId;
            return resp;
        }

        [HttpPost]
        [Route("VerifyConfirmationCode")]
        public async Task<ServiceVerifyConfirmationCodeResponse> VerifyConfirmationCode(ServiceVerifyConfirmationCodeRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>(errorCode, errorMsg);
            }

            if (!ValidateVerifyConfirmationCodeRequest(request, out errorCode, out errorMsg))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>(errorCode, errorMsg);
            }

            var patientId = Guid.Parse(request.PatientId);
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var confCodeEntry = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientId);

                if (confCodeEntry == null)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>("B123",
                        String.Format("No confirmation code found for patient with internal ID '{0}'", request.PatientId));
                }
                ServiceVerifyConfirmationCodeResponse respo;
                if (AccessChecker.IsAccessDenied(confCodeEntry, out respo))
                {
                    return respo;
                }
                if (request.ConfirmationCode != confCodeEntry.ConfirmationCode)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>("B124",
                        "Confirmation Code is not correct.");
                }

                //TODO validation regarding vaild datetime ?
            }

            var patRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPatientByIdRequest>(_portalSettings, mcBaseRequest);
            patRequest.PatientId = patientId;

            var patResponse =
                await BasicServiceWebHelper
                    .CallMedCubesServiceAsync<ServiceGetPatientByIdResponse, ServiceGetPatientByIdRequest>(_httpClientFactory, patRequest,
                        iisUrl, "Patient/GetPatientById");

            if (!patResponse.Success)
            {
                return
                    BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>(
                        patResponse.ErrorCode, patResponse.ServiceMessages.ToList());
            }
            var patientRecord = patResponse.PatientList.FirstOrDefault();
            if (patientRecord == null)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceVerifyConfirmationCodeResponse>("B125",
                    String.Format("No patient with internal ID '{0}' found!", request.PatientId));
            }

            //Update - set IsIdentified to TRUE
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var patientExt = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientId);
                if (patientExt != null)
                {
                    patientExt.IsIdentified = true;
                    var saved = context.SaveChanges();
                }
            }

            var resp = BasicServiceWebHelper.CreateSuccessResponse<ServiceVerifyConfirmationCodeResponse>();
            if (request.OnlyReturnFirstName && !String.IsNullOrWhiteSpace(patientRecord.FirstName))
            {
                resp.PatientName = patientRecord.FirstName;
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(patientRecord.FirstName))
                {
                    resp.PatientName = patientRecord.FirstName + " " + patientRecord.LastName;
                }
                else
                {
                    resp.PatientName = patientRecord.LastName;
                }
            }

            return resp;

        }

        private string GetHashValueOfPatientToAuthenticate(ServiceGetConfirmationCodeRequest request)
        {
            var stringToHash = (request.IdNumber + request.Email + request.DateOfBirthStr).ToLower();
            using (var sha1 = SHA1.Create())
            {
                var hash = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
                return hash;
            }
        }

        private bool ValidateVerifyConfirmationCodeRequest(ServiceVerifyConfirmationCodeRequest request, out string errorCode, out string errorMsg)
        {
            errorCode = null;
            errorMsg = null;
            if (String.IsNullOrWhiteSpace(request.PatientId))
            {
                errorCode = "B120";
                errorMsg = "The ID of the patient must be set!";
            }
            if (String.IsNullOrWhiteSpace(request.ConfirmationCode))
            {
                errorCode = "B121";
                errorMsg = "The confirmation code must be set!";
            }
            Guid patGuid;
            if (!Guid.TryParse(request.PatientId, out patGuid))
            {
                errorCode = "B122";
                errorMsg = "The patient ID is not valid!";
            }
            return errorCode == null;
        }

        private bool ValidateGetConfirmationCodeRequest(ServiceGetConfirmationCodeRequest request, out string errorCode,
            out string errorMsg)
        {
            errorCode = null;
            errorMsg = null;
            if (String.IsNullOrWhiteSpace(request.IdNumber))
            {
                errorCode = "B110";
                errorMsg = "The ID of the patient must be set!";
            }
            if (request.DateOfBirth == DateTime.MinValue)
            {
                errorCode = "B111";
                errorMsg = "The Date of Birth must be set!";
            }
            if (String.IsNullOrWhiteSpace(request.Email))
            {
                errorCode = "B112";
                errorMsg = "The Email address must be set!";
            }
            return errorCode == null;
        }

    }
}
