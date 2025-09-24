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
using System.Linq;

namespace PatientPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedimaxDocumentController : PortalBaseController
    {
        public MedimaxDocumentController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings) : base(httpClientFactory, portalSettings)
        {
        }

        #region GetDocumentTypes
        [HttpPost]
        [Route("GetDocumentTypes")]
        #endregion

        #region GetPatientDocuments

        [HttpPost]
        [Route("GetPatientDocuments")]
        public async Task<ServiceMedimaxGetPatientDocumentsResponse> GetPatientDocuments(
            ServiceMedimaxGetPatientDocumentsRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;

            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetPatientDocumentsResponse>(errorCode, errorMsg);
            }

            if (request.PatientId == Guid.Empty)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetPatientDocumentsResponse>("B101", "The patient id must be set!");
            }

            ServiceMedimaxGetPatientDocumentsResponse respo;
            if (AccessChecker.IsAccessDenied(request.PatientId, out respo))
            {
                return respo;
            }

            // Prepare MedCubes request
            var req = BasicServiceWebHelper.CreateMedCubesRequest<PatientPortalBackend.Models.MedCubesModels.ServiceGetDocumentInfoListRequest>(_portalSettings, mcBaseRequest);
            req.PrimaryParentKey = request.PatientId.ToString();

            // Call MedCubes service
            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<
                PatientPortalBackend.Models.MedCubesModels.ServiceGetDocumentInfoListResponse,
                PatientPortalBackend.Models.MedCubesModels.ServiceGetDocumentInfoListRequest>(
                    _httpClientFactory, req, iisUrl, "DocumentInfo/GetDocumentInfoList");

            if (!resp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetPatientDocumentsResponse>(resp.ErrorCode, resp.ServiceMessages);
            }

            // Map DocumentInfoWrapperList to PatientDocument list
            var documentList = new List<PatientDocument>();
            if (resp.DocumentInfoWrapperList != null)
            {
                foreach (var wrapper in resp.DocumentInfoWrapperList)
                {
                    var entry = wrapper.DocumentInfoRecord; // Adjust property name if needed
                    if (entry == null) continue;

                    documentList.Add(new PatientDocument
                    {
                        DocumentId = entry.DocumentId,
                        DocumentType = entry.DocumentType ?? 0,
                        Link = entry.ExternalDocumentUrl,
                        Name = entry.Title,
                        DateTimeCreatedStr = entry.CreatedDate?.DateTime.ToString("yyyy-MM-dd HH:mm"),
                        DocumentKey = entry.DocumentKey,
                        Version = entry.Version,
                        IsFinalized = entry.IsFinalized
                    });
                }
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetPatientDocumentsResponse>();
            response.DocumentList = documentList;
            return response;
        }

        #endregion

        #region DownloadPatientDocument
        [HttpPost]
        [Route("DownloadPatientDocument")]
        public async Task<ServiceMedimaxDownloadPatientDocumentResponse> DownloadPatientDocument(ServiceMedimaxDownloadPatientDocumentRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;

            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDownloadPatientDocumentResponse>(errorCode, errorMsg);
            }

            if (request.DocumentId <= 0)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDownloadPatientDocumentResponse>("B500", "The documentId must be valid!");
            }

            // Map to MedCubes request
            var medCubesReq = BasicServiceWebHelper.CreateMedCubesRequest<PatientPortalBackend.Models.MedCubesModels.ServiceDownloadDocumentInfoRequest>(_portalSettings, mcBaseRequest);
            medCubesReq.DocumentId = request.DocumentId;
            medCubesReq.Version = request.Version;
            medCubesReq.IsDocumentInfoRecordAttached = true;
            medCubesReq.DocumentPassword = request.DocumentPassword;

            // Call MedCubes service
            var medCubesResp = await BasicServiceWebHelper.CallMedCubesServiceAsync<
                PatientPortalBackend.Models.MedCubesModels.ServiceDownloadDocumentInfoResponse,
                PatientPortalBackend.Models.MedCubesModels.ServiceDownloadDocumentInfoRequest>(
                    _httpClientFactory, medCubesReq, iisUrl, "DocumentInfo/DownloadDocumentInfo");

            if (!medCubesResp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDownloadPatientDocumentResponse>(medCubesResp.ErrorCode, medCubesResp.ServiceMessages);
            }

            var extension = medCubesResp.MimeType; // actually a file extension
            var mimeType = GetMimeTypeFromExtension(extension);
            var fileName = medCubesResp.DocumentInfoRecord?.Title;
            if (!string.IsNullOrEmpty(extension) && fileName != null && !fileName.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                fileName += extension;
            if (string.IsNullOrEmpty(fileName))
                fileName = "document" + extension;

            return new ServiceMedimaxDownloadPatientDocumentResponse
            {
                Success = true,
                DocumentContent = medCubesResp.DocumentRecord,
                MimeType = mimeType,
                FileName = fileName
            };
        }


        #endregion

        private static string GetMimeTypeFromExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                return "application/octet-stream";
            if (!extension.StartsWith(".")) extension = "." + extension;
            return extension.ToLower() switch
            {
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".pdf" => "application/pdf",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream",
            };
        }

    }
}
