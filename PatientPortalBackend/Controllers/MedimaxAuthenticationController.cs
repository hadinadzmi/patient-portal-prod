using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatientPortalBackend.Access;
using PatientPortalBackend.DbModels;
using PatientPortalBackend.Models.MedCubesModels.Core;
using PatientPortalBackend.Models.MedCubesModels;
using PatientPortalBackend.Models;
using PatientPortalBackend.Utils;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.Reflection.Emit;

namespace PatientPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedimaxAuthenticationController : PortalBaseController
    {
        public MedimaxAuthenticationController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings) : base(httpClientFactory, portalSettings)
        {
        }

        #region GetLoginDetails
        [HttpPost]
        [Route("GetLoginDetails")]
        public async Task<ServiceGetLoginDetailsResponse> GetLoginDetails(
            ServiceGetLoginDetailsRequest request)
        {
            string taskNo = "";
            var patHash = GetHashValueOfPatientToAuthenticate(request);
            var todayDate = DateTime.Now.Date;
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var existingEntry = context.PatientAuthentication.FirstOrDefault(p =>
                    p.PatientHash == patHash &&
                    p.DateTried == todayDate);

                if (existingEntry != null && existingEntry.TryCount > 3)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceGetLoginDetailsResponse>("B199",
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
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetLoginDetailsResponse>(errorCode,
                    errorMsg);
            }

            var patRequest =
                BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetMaxLoginDetailsRequest>(_portalSettings,
                    mcBaseRequest);
            patRequest.IdNumber = request.PatientNric;
            //patRequest.Password = request.PatientPassword;

            Patient patientRecord;
            var patResponse =
                await BasicServiceWebHelper
                    .CallMedCubesServiceAsync<ServiceGetMaxLoginDetailsResponse,
                        ServiceGetMaxLoginDetailsRequest>(_httpClientFactory, patRequest, iisUrl,
                        "Patient/GetPatientForMedimaxPortal");
            taskNo = "1";
            if (!patResponse.Success)
            {
                taskNo = "2";
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
                    BasicServiceWebHelper.CreateFaultResponse<ServiceGetLoginDetailsResponse>(
                        patResponse.ErrorCode, patResponse.ServiceMessages.ToList());
            }

            patientRecord = patResponse.PatientRecord;

            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var patientExtension = context.PatientExtension
                    .FirstOrDefault(p => p.PatientId == patientRecord.PatientId);

                if (patientExtension == null)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceGetLoginDetailsResponse>("B198",
                        "Patient record not found.");
                }

                using (var sha256 = SHA256.Create())
                {
                    var inputBytes = Encoding.UTF8.GetBytes(request.PatientPassword);
                    var inputHash = Convert.ToBase64String(sha256.ComputeHash(inputBytes));

                    if (patientExtension.PassHashWord != inputHash)
                    {
                        return BasicServiceWebHelper.CreateFaultResponse<ServiceGetLoginDetailsResponse>("B197",
                            "Invalid password.");
                    }
                }
            }

            var resp = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetLoginDetailsResponse>();
            resp.PatId = patientRecord.PatientId;
            resp.PatName = patientRecord.FirstName + " " + patientRecord.MiddleName + " " + patientRecord.LastName;
            // add Patient NRIC.
            resp.PatNRIC = patientRecord.IdentityDocumentNumber;
            //add Patient Mobile Number
            string countryCode = "";
            string mobileNumber = patientRecord.MobileNumber;
            if (patientRecord.AddressCountryCode == "MAL")
            {
                countryCode = "60";
                if (mobileNumber.StartsWith("0"))
                {
                    mobileNumber = mobileNumber.Substring(1);
                }
            }
            resp.PatMobileNum = countryCode + mobileNumber;
            //add Patient DOB
            resp.PatDOB = patientRecord.DateOfBirth?.ToString("yyyy-MM-dd");

            return resp;
        }
        #endregion

        #region GetConfirmationCode
        [HttpPost]
        [Route("GetConfirmationCode")]
        public async Task<ServiceGetMaxConfirmationCodeResponse> GetConfirmationCode(
    ServiceGetMaxConfirmationCodeRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>(errorCode,
                    errorMsg);
            }
            if (!ValidateGetConfirmationCodeRequest(request, out errorCode, out errorMsg))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>(errorCode,
                    errorMsg);
            }

            string dialingCode;
            if (!PhoneHelper.CountryDialingCodes.TryGetValue(request.patAddressCountryCode ?? "MAL", out dialingCode))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>("B201", "Unsupported country code.");
            }

            string mobileNumber;
            try
            {
                mobileNumber = PhoneHelper.NormalizeForDb(request.patMobileNum, dialingCode);
            }
            catch (ArgumentException)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>("B202", "Invalid mobile number format.");
            }

            var patRequest =
                BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPatientForConfirmationCodeRequest>(_portalSettings,
                    mcBaseRequest);
            patRequest.PatIdNum = request.patNRIC;
            patRequest.PatMobileNum = mobileNumber;
            patRequest.RequestType = request.RequestType; // Added this line

            Patient patientRecord;
            var patResponse =
                await BasicServiceWebHelper
                    .CallMedCubesServiceAsync<ServiceGetPatientForConfirmationCodeResponse,
                        ServiceGetPatientForConfirmationCodeRequest>(_httpClientFactory, patRequest, iisUrl,
                        "Patient/GetPatientMedimaxForConfirmationCode");

            if (!patResponse.Success)
            {
                //increase tryCount of confirmation Code authentication
                if (patResponse.ErrorCode == "B104")
                {
                    using (var context = new MedCubes_PatientPortalBackendEntities())
                    {
                        var existing = context.PatientAuthentication.FirstOrDefault(p =>
                            p.PatientHash == patRequest.PatIdNum &&
                            p.DateTried == DateTime.Now.Date);
                        if (existing != null)
                        {
                            existing.TryCount++;
                        }
                        else
                        {
                            var newEntry = new PatientAuthentication();
                            newEntry.PatientHash = patRequest.PatIdNum;
                            newEntry.DateTried = DateTime.Now.Date;
                            newEntry.TryCount = 1;
                            context.PatientAuthentication.Add(newEntry);
                        }
                        var saved = context.SaveChanges();
                    }
                }

                return
                    BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>(
                        patResponse.ErrorCode, patResponse.ServiceMessages.ToList());
            }

            patientRecord = patResponse.PatientRecord;

            // Create confirmation code and save it in the database
            var generatorCode = new Random();
            var confirmationCode = generatorCode.Next(0, 1000000).ToString("D6");

            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var existingRecord = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientRecord.PatientId &&
                                                                                  p.CustomerId == mcBaseRequest.ClientCustomerId &&
                                                                                  p.TenantId == mcBaseRequest.ClientTenantId);
                if (request.RequestType == "FirstTimeLogin")
                {
                    if (existingRecord != null && !string.IsNullOrEmpty(existingRecord.PassHashWord))
                    {
                        return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>(
                            "B300", "Password already set.");
                    }
                }
                else if (request.RequestType == "ResetPassword")
                {
                    if (string.IsNullOrEmpty(existingRecord.PassHashWord))
                    {
                        return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>(
                            "B301", "No password set.");
                    }
                }

                if (existingRecord != null)
                {
                    ServiceGetMaxConfirmationCodeResponse respo;
                    if (AccessChecker.IsAccessDenied(existingRecord, out respo))
                    {
                        return respo;
                    }

                    existingRecord.ConfirmationCode = confirmationCode;
                    existingRecord.ConfirmationCodeCreated = DateTimeOffset.Now;
                }
                else
                {
                    // CREATE new PatientExtension entry
                    var newEntry = new PatientExtension();
                    newEntry.CustomerId = mcBaseRequest.ClientCustomerId;
                    newEntry.TenantId = mcBaseRequest.ClientTenantId;
                    newEntry.ConfirmationCode = confirmationCode;
                    newEntry.ConfirmationCodeCreated = DateTimeOffset.Now;
                    newEntry.PatientId = patientRecord.PatientId;
                    context.PatientExtension.Add(newEntry);
                }

                var saved = context.SaveChanges();
            }

            // Customize the message based on the request type
            string message;
            string name = $"{patientRecord.FirstName} {patientRecord.LastName}";

            switch (request.RequestType)
            {
                case "ResetPassword":
                    message = $"Hi {name}, code: {confirmationCode}. Use it to reset your password. Call 07-9063111 if not you.";
                    break;
                case "FirstTimeLogin":
                    message = $"Hi {name}, code: {confirmationCode}. Use it to set your password. Call 07-9063111 if not you.";
                    break;
                case "Reschedule":
                    message = $"Hi {name}, code: {confirmationCode}. Use it to reschedule your appointment. Call 07-9063111 if not you.";
                    break;
                case "Cancel":
                    message = $"Hi {name}, code: {confirmationCode}. Use it to cancel your appointment. Call 07-9063111 if not you.";
                    break;
                default:
                    message = $"Hi {name}, code: {confirmationCode}. Use it for your request. Call 07-9063111 if not you.";
                    break;
            }


            string mobileNumberForSms;
            try
            {
                mobileNumberForSms = PhoneHelper.NormalizeForSms(mobileNumber, dialingCode);
            }
            catch (ArgumentException)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>("B203", "Invalid mobile number format for SMS.");
            }

            // Send confirmation code to patient mobile number
            var smsRequest = new HttpRequestMessage(HttpMethod.Post, "https://demo-sms.qbe.ee/api_sms/my_sena")
            {
                Content = new StringContent(
                    $"{{\"message\":\"{message}\",\"to\":[\"{mobileNumberForSms}\"]}}",
                    Encoding.UTF8,
                    "application/json")
            };
            smsRequest.Headers.Add("Accept", "application/json");
            smsRequest.Headers.Add("Access-Token", "e/cncPqUXtHDRPTKswOltbDoWEJPES9VZ7ChefG2y0I=");

            var httpClient = _httpClientFactory.CreateClient();
            var smsResponse = await httpClient.SendAsync(smsRequest);
            if (!smsResponse.IsSuccessStatusCode)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetMaxConfirmationCodeResponse>("B200",
                    "Failed to send confirmation code via SMS.");
            }

            var resp = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetMaxConfirmationCodeResponse>();
            resp.patID = patientRecord.PatientId;
            resp.patName = patientRecord.FirstName + " " + patientRecord.MiddleName + " " + patientRecord.LastName;
            resp.patNRIC = patientRecord.IdentityDocumentNumber;
            resp.patAddressCountryCode = patientRecord.AddressCountryCode;
            resp.patMobileNum = mobileNumberForSms;
            return resp;
        }

        #endregion

        #region VerifyConfirmationCode

        [HttpPost]
        [Route("VerifyConfirmationCode")]
        public async Task<ServiceMedimaxVerifyConfirmationCodeResponse> VerifyConfirmationCode(ServiceMedimaxVerifyConfirmationCodeRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxVerifyConfirmationCodeResponse>(errorCode, errorMsg);
            }
            if (!ValidateVerifyConfirmationCodeRequest(request, out errorCode, out errorMsg))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxVerifyConfirmationCodeResponse>(errorCode, errorMsg);
            }

            var patientId = Guid.Parse(request.PatientId);
            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var confCodeEntry = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientId);

                if (confCodeEntry == null)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxVerifyConfirmationCodeResponse>("B123",
                        $"No confirmation code found for patient with internal ID '{request.PatientId}'");
                }
                ServiceMedimaxVerifyConfirmationCodeResponse respo;
                if (AccessChecker.IsAccessDenied(confCodeEntry, out respo))
                {
                    return respo;
                }

                // Check if the confirmation code is still valid
                var codeValidityDuration = TimeSpan.FromSeconds(300);
                if (DateTimeOffset.Now - confCodeEntry.ConfirmationCodeCreated > codeValidityDuration)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxVerifyConfirmationCodeResponse>("B126",
                        "The confirmation code has expired!");
                }

                if (confCodeEntry.ConfirmationCode != request.ConfirmationCode)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxVerifyConfirmationCodeResponse>("B124",
                        "The confirmation code is not valid!");
                }

                // Optionally, you can clear the code here if you want to make it single-use
                // confCodeEntry.ConfirmationCode = null;
                // confCodeEntry.ConfirmationCodeCreated = null;
                // context.SaveChanges();
            }

            return BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxVerifyConfirmationCodeResponse>();
        }

        #endregion

        #region SetPasswordAfterCode
        [HttpPost]
        [Route("SetPasswordAfterCode")]
        public async Task<ServiceBaseWebResponse> SetPasswordAfterCode([FromBody] SetPasswordAfterCodeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PatientId) ||
                string.IsNullOrWhiteSpace(request.ConfirmationCode) ||
                string.IsNullOrWhiteSpace(request.NewPassword))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceBaseWebResponse>("B410", "All fields are required.");
            }

            Guid patientId;
            if (!Guid.TryParse(request.PatientId, out patientId))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceBaseWebResponse>("B411", "Invalid patient ID.");
            }

            using (var context = new MedCubes_PatientPortalBackendEntities())
            {
                var confCodeEntry = context.PatientExtension.FirstOrDefault(p => p.PatientId == patientId);

                if (confCodeEntry == null)
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceBaseWebResponse>("B412", "Patient not found.");
                }

                if (confCodeEntry.ConfirmationCode != request.ConfirmationCode ||
                    DateTimeOffset.Now - confCodeEntry.ConfirmationCodeCreated > TimeSpan.FromSeconds(300))
                {
                    return BasicServiceWebHelper.CreateFaultResponse<ServiceBaseWebResponse>("B413", "Invalid or expired confirmation code.");
                }

                // Set new password
                using (var sha256 = SHA256.Create())
                {
                    var newHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(request.NewPassword)));
                    confCodeEntry.PassHashWord = newHash;
                }

                // Clear the confirmation code
                confCodeEntry.ConfirmationCode = null;
                confCodeEntry.ConfirmationCodeCreated = null;

                context.SaveChanges();
            }

            return BasicServiceWebHelper.CreateSuccessResponse<ServiceBaseWebResponse>();
        }

        public class SetPasswordAfterCodeRequest
        {
            public string PatientId { get; set; }
            public string ConfirmationCode { get; set; }
            public string NewPassword { get; set; }
        }
        #endregion

        private string GetHashValueOfPatientToAuthenticate(ServiceGetLoginDetailsRequest request)
        {
            var stringToHash = (request.PatientNric + request.PatientPassword).ToLower();
            using (var sha1 = SHA1.Create())
            {
                var hash = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
                return hash;
            }
        }

        private bool ValidateGetConfirmationCodeRequest(ServiceGetMaxConfirmationCodeRequest request, out string errorCode, out string errorMsg)
        {
            if (string.IsNullOrEmpty(request.patNRIC))
            {
                errorCode = "B100";
                errorMsg = "Patient NRIC is required!";
                return false;
            }
            if (string.IsNullOrEmpty(request.patMobileNum))
            {
                errorCode = "B101";
                errorMsg = "Patient Mobile Number is required!";
                return false;
            }
            errorCode = "";
            errorMsg = "";
            return true;
        }

        private bool ValidateVerifyConfirmationCodeRequest(ServiceMedimaxVerifyConfirmationCodeRequest request, out string errorCode, out string errorMsg)
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
    }
}
