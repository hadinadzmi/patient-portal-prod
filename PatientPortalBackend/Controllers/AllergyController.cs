using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatientPortalBackend.Access;
using PatientPortalBackend.Models.MedCubesModels.Core;
using PatientPortalBackend.Models;
using PatientPortalBackend.Utils;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using PatientPortalBackend.Models.MedCubesModels;

namespace PatientPortalBackend.Controllers
{
    [ApiController]
    [Route("api/Allergies")]
    public class AllergyController : PortalBaseController
    {
        public AllergyController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings) : base(httpClientFactory, portalSettings)
        {
        }

        [HttpPost]
        [Route("GetPatientAllergies")]
        public async Task<ServiceGetPatientAllergiesResponse> GetPatientAllergies(
            ServiceGetPatientAllergiesRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAllergiesResponse>(errorCode,
                    errorMsg);
            }

            if (request.PatientId == Guid.Empty)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAllergiesResponse>("B101",
                    "The patient id must be set!");
            }

            ServiceGetPatientAllergiesResponse respo;
            if (AccessChecker.IsAccessDenied(request.PatientId, out respo))
            {
                return respo;
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceReadPatientAllergyRequest>(_portalSettings,
                mcBaseRequest);
            req.PatientId = request.PatientId;


            var resp = await BasicServiceWebHelper
                .CallMedCubesServiceAsync<ServiceReadPatientAllergyResponse, ServiceReadPatientAllergyRequest>(
                    _httpClientFactory, req, iisUrl, "Allergy/ReadPatientAllergy");
            if (!resp.Success)
            {
                return
                    BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAllergiesResponse>(
                        resp.ErrorCode, resp.ServiceMessages);
            }

            // Convert the response to the format the frontend expects
            var mcAllergies = resp.PatientAllergyRecordList;

            var respList = new List<Models.PatientAllergy>();
            foreach (var entry in mcAllergies)
            {
                respList.Add(new Models.PatientAllergy(entry.Code, entry.Name, entry.AdditionalText, entry.Description, entry.AllergyState));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetPatientAllergiesResponse>();
            response.AllergyList = respList;
            return response;
        }
    }
}
