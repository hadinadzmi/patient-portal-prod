using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatientPortalBackend.Access;
using PatientPortalBackend.Models.MedCubesModels.Core;
using PatientPortalBackend.Models.MedCubesModels;
using PatientPortalBackend.Models;
using PatientPortalBackend.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using System.Net;
using System.Linq;
using static PatientPortalBackend.Models.ServiceMedimaxGetUserDetailsByUserIdsResponse;

namespace PatientPortalBackend.Controllers
{
    [ApiController]
    [Route("api/Appointments")]
    public class MedimaxAppointmentController : PortalBaseController
    {
        public MedimaxAppointmentController(IHttpClientFactory httpClientFactory, IOptions<PortalSettings> portalSettings)
            : base(httpClientFactory, portalSettings)
        {
        }
        #region CreatePatientAppointment
        [HttpPost]
        [Route("CreatePatientAppointment")]
        public async Task<ServiceCreatePatientAppointmentResponse> CreatePatientAppointment(
            ServiceCreatePatientAppointmentRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceCreatePatientAppointmentResponse>(errorCode,
                    errorMsg);
            }

            var patientCalendarEntry = new PatientCalendarEntry
            {

                Speciality = request.SpecialtyId,
                //StartDateTime = request.AppointmentDateTime,
                //EndDateTime = request.AppointmentDateTime.AddHours(1), // Assuming a default duration of 1 hour
                StartDateTime = request.AppointmentDateTime,
                EndDateTime = request.AppointmentDateTime.AddMinutes(30), // Changed duration to 30 minutes
                Name = request.Name,// wajib ada
                PatientId = request.PatientId, // wajib ada
                PlanningState = 1000,
                AdditionalInfo = request.AdditionalMsg,
                PatientCalendarEntryID = Guid.NewGuid(), //wajib ada
                ServiceUnitId = request.MedimaxServiceUnitId,
                ServiceId = Guid.Parse("6B58C2A6-317F-40B2-9FAF-50D71F096422"), //Doctor Fee, SPECIALIST CONSULTATION ServiceId

                //PlanningStateDateTime = request.PtDob ?? DateTime.UtcNow,
                //SeriesDefinition = request.HospitalLocationId,
                //AbstractBackupSeq = request.DoctorId,
                //AbstractBackupNo = request.PtNRIC,
                //AppointmentMode = request.CountryCode,
                //Npo = request.PtMobileNum,
                //PlanningState = request.PaymentMethod, //kene tukar lain PlanningState biar 1000
            };
            patientCalendarEntry.State = Models.MedCubesModels.Core.ModelState.Added; // need kalau nak add/create something and pass kat databased
            patientCalendarEntry.ResourceRelationshipList = new List<PatientCalendarEntryResourceRelationship>();
            patientCalendarEntry.ResourceRelationshipList.Add(new PatientCalendarEntryResourceRelationship
            {
                ResourceId = request.MedimaxResourceId,
                PatientCalendarEntryId = patientCalendarEntry.PatientCalendarEntryID,
            });
            var serviceRequest =
                BasicServiceWebHelper.CreateMedCubesRequest<ServiceCreatePatientCalendarEntryRequest>(_portalSettings,
                    mcBaseRequest); //need for SEMUA controller

            serviceRequest.PatientCalendarEntryList = new List<PatientCalendarEntry> { patientCalendarEntry };
            serviceRequest.SkipCreateUserAssignment = false;


            var serviceResponse = await BasicServiceWebHelper
                .CallMedCubesServiceAsync<ServiceCreatePatientCalendarEntryResponse, ServiceCreatePatientCalendarEntryRequest>(
                    _httpClientFactory, serviceRequest, iisUrl, "PatientCalendarEntry/CreatePatientCalendarEntry");

            if (!serviceResponse.Success) // buat gini boh kalau nak deliver error message
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceCreatePatientAppointmentResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceCreatePatientAppointmentResponse>();
            response.PatientId = request.PatientId; // Include the PatientId in the response
            return response;
        }
        #endregion

        #region GetPatientAppointments
        [HttpPost]
        [Route("GetPatientAppointments")]
        public async Task<ServiceGetPatientAppointmentsResponse> GetPatientAppointments(
            ServiceGetPatientAppointmentsRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAppointmentsResponse>(errorCode,
                    errorMsg);
            }

            if (request.PatientId == Guid.Empty)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAppointmentsResponse>("B101",
                    "The patient id must be set!");
            }

            ServiceGetPatientAppointmentsResponse respo;
            if (AccessChecker.IsAccessDenied(request.PatientId, out respo))
            {
                return respo;
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPatientCalendarEntryListRequest>(_portalSettings,
                mcBaseRequest);
            req.PatientId = request.PatientId;

            var resp = await BasicServiceWebHelper
                .CallMedCubesServiceAsync<ServiceGetPatientCalendarEntryListResponse, ServiceGetPatientCalendarEntryListRequest>(
                    _httpClientFactory, req, iisUrl, "PatientCalendarEntry/GetPatientCalendarEntryList");

            if (!string.IsNullOrEmpty(resp.ErrorCode))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetPatientAppointmentsResponse>(resp.ErrorCode, "Failed to get patient calendar entry list.");
            }

            var mcAppointments = resp.PatientCalendarEntryList;

            var respList = new List<PatientAppointment>();
            if (mcAppointments != null)
            {
                foreach (var entry in mcAppointments)
                {
                    respList.Add(new PatientAppointment
                    {
                        PkID = entry.PkId.ToString(),
                        PatientCalendarEntryID = entry.PatientCalendarEntryID,
                        StartDateTime = entry.StartDateTime,
                        EndDateTime = entry.EndDateTime,
                        Name = entry.Name,
                        AdditionalInfo = entry.AdditionalInfo,
                        Speciality = entry.Speciality ?? 0,
                        RecordState = entry.RecordState.ToString(),
                        ServiceUnitId = entry.ServiceUnitId,
                        PlanningState = entry.PlanningState,
                        CancelReason = entry.CancelReason,
                    });
                }
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetPatientAppointmentsResponse>();
            response.AppointmentList = respList;
            return response;
        }
        #endregion

        #region GetPopupDetailsList
        [HttpPost]
        [Route("GetPopupDetailsList")]
        public async Task<ServiceMedimaxGetPopupsListResponse> GetPopupDetailsList(ServiceMedimaxGetPopupsListRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetPopupsListResponse>(errorCode, errorMsg);
            }

            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPopupEntryListRequest>(_portalSettings, mcBaseRequest);
            serviceRequest.PopupKey = request.PtPopupKey;

            var serviceResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetPopupEntryListResponse, ServiceGetPopupEntryListRequest>(
                _httpClientFactory, serviceRequest, iisUrl, "Popup/MedimaxGetPopupEntryList");

            if (!serviceResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetPopupsListResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetPopupsListResponse>();
            response.PopupEntryList = serviceResponse.PopupEntryList?
                .Where(e => e.RecordState == 0)
                .ToList();
            return response;
        }
        #endregion

        #region GetTenantIdList
        [HttpPost]
        [Route("GetResourceList")]
        public async Task<ServiceGetTenantDetailsResponse> TestGetResourceList(ServiceGetTenantDetailsRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetTenantDetailsResponse>(errorCode, errorMsg);
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetTenantListRequest>(_portalSettings, mcBaseRequest);

            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetTenantListResponse, ServiceGetTenantListRequest>(_httpClientFactory, req, iisUrl, "Tenant/GetTenantList");

            if (!resp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetTenantDetailsResponse>(resp.ErrorCode, String.Join(Environment.NewLine, resp.ServiceMessages));
            }

            var mcTenants = resp.TenantList;

            var respList = new List<TenantDto>();
            if (mcTenants != null)
            {
                foreach (var tenant in mcTenants.Where(t => t.TenantId == 1))
                {
                    respList.Add(new TenantDto
                    {
                        TenantId = tenant.TenantId,
                        TenantName = tenant.Name,
                        CustomerId = tenant.CustomerId,
                        RecordState = tenant.RecordState
                    });
                }
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetTenantDetailsResponse>();
            response.TenantList = respList;
            return response;
        }
        #endregion

        #region GetDepartmentDetailsAndServiceUnits
        [HttpPost]
        [Route("GetDepartmentDetailsAndServiceUnits")]
        public async Task<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse> GetDepartmentDetailsAndServiceUnits(ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest request)
        {
            string errorCode, errorMsg, iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse>(errorCode, errorMsg);
            }

            // Fetch Departments
            var deptRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetDepartmentListRequest>(_portalSettings, mcBaseRequest);
            var deptResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetDepartmentListResponse, ServiceGetDepartmentListRequest>(
                _httpClientFactory, deptRequest, iisUrl, "DepartmentData/GetDepartmentList");

            if (!deptResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse>(deptResponse.ErrorCode, "Failed to get department list.");
            }

            // Fetch ServiceUnits
            var suRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetServiceUnitListRequest>(_portalSettings, mcBaseRequest);
            var suResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetServiceUnitListResponse, ServiceGetServiceUnitListRequest>(
                _httpClientFactory, suRequest, iisUrl, "DepartmentData/GetServiceUnitList");

            if (!suResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse>(suResponse.ErrorCode, "Failed to get service unit list.");
            }

            var now = DateTime.UtcNow;
            var allowedShortNames = new HashSet<string> { "CO", "ET", "GM", "GS", "HS", "IM", "OG", "OR", "PA", "PY" };

            // Filter by TenantId, ValidUntil, and ShortName
            var filteredDepartments = deptResponse.DepartmentList
                .Where(d => (!request.TenantId.HasValue || d.TenantId == request.TenantId)
                    && (!d.ValidUntil.HasValue || d.ValidUntil.Value >= now)
                    && allowedShortNames.Contains(d.ShortName))
                .ToList();

            var filteredServiceUnits = suResponse.ServiceUnitList
                .Where(su => (!request.TenantId.HasValue || su.TenantId == request.TenantId)
                    && (!su.ValidUntil.HasValue || su.ValidUntil.Value >= now))
                .ToList();

            // Match ServiceUnits to Departments
            var departments = filteredDepartments.Select(d => new DepartmentWithServiceUnitsDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Name,
                TenantId = d.TenantId,
                ServiceUnits = filteredServiceUnits
                    .Where(su => su.DepartmentId == d.DepartmentId)
                    .Select(su => new ServiceUnitDto
                    {
                        ServiceUnitId = su.ServiceUnitId,
                        ServiceUnitName = su.Name,
                        DepartmentId = su.DepartmentId,
                        TenantId = su.TenantId
                    }).ToList()
            }).ToList();

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse>();
            response.Departments = departments;
            return response;
        }
        #endregion

        #region GetUserIdByTenantId
        [HttpPost]
        [Route("GetUsersIdByTenantId")]
        public async Task<ServiceGetUsersIdByTenantResponse> GetUsersByTenantId(ServiceGetUsersIdByTenantRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetUsersIdByTenantResponse>(errorCode, errorMsg);
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetTenantOfUserListRequest>(_portalSettings, mcBaseRequest);
            req.CustomerId = request.CustomerId;
            req.TenantId = request.TenantId;

            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetTenantOfUserListResponse, ServiceGetTenantOfUserListRequest>(_httpClientFactory, req, iisUrl, "User/GetTenantOfUserList");

            if (!resp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetUsersIdByTenantResponse>(resp.ErrorCode, String.Join(Environment.NewLine, resp.ServiceMessages));
            }

            var mcUsers = resp.TenantOfUserList;

            var respList = new List<UserIdListDto>();
            if (mcUsers != null)
            {
                foreach (var user in mcUsers)
                {
                    respList.Add(new UserIdListDto
                    {
                        UserId = user.UserId,
                        RecordState = user.RecordState
                    });
                }
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetUsersIdByTenantResponse>();
            response.UserList = respList;
            return response;
        }
        #endregion

        #region GetUserDetailsByUserIdList
        [HttpPost]
        [Route("GetUserDetailsByUserIdList")]
        public async Task<ServiceMedimaxGetUserDetailsByUserIdsResponse> GetUserDetailsByUserIdList(ServiceMedimaxGetUserDetailsByUserIdsRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetUserDetailsByUserIdsResponse>(errorCode, errorMsg);
            }

            // Prepare MedCubes request
            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetUserListSimpleRequest>(_portalSettings, mcBaseRequest);
            serviceRequest.UserIds = request.ListUserIds;

            // Call MedCubes service
            var serviceResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetUserListSimpleResponse, ServiceGetUserListSimpleRequest>(
                _httpClientFactory, serviceRequest, iisUrl, "User/GetUserListSimple");

            if (!serviceResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetUserDetailsByUserIdsResponse>(
                    serviceResponse.ErrorCode, "Failed to get user details.");
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetUserDetailsByUserIdsResponse>();
            response.ListUserDetails = serviceResponse.UserList?
                .Where(u => u.Speciality.HasValue && u.Speciality.Value != 0)
                .Select(u => new UserBasicInfoDto
                {
                    UserId = u.UserId,
                    RecordState = u.RecordState,
                    UserState = u.UserState,
                    Speciality = u.Speciality,
                    State = (int)u.State
                }).ToList();
            return response;
        }
        #endregion

        #region GetUserNameByUserId
        [HttpPost]
        [Route("GetUserNameByUserId")]
        public async Task<ServiceGetUsersDetailsByUserIdResponse> GetUserNameByUserId(ServiceGetUsersDetailsByUserIdRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetUsersDetailsByUserIdResponse>(errorCode, errorMsg);
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetUserCodesByUserIdListRequest>(_portalSettings, mcBaseRequest);
            req.UserIdList = request.UserIds;
            req.CustomerId = request.CustomerId;
            req.TenantId = request.TenantId;

            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetUserCodesByUserIdListResponse, ServiceGetUserCodesByUserIdListRequest>(_httpClientFactory, req, iisUrl, "User/GetUserCodesByUserIdList");

            if (!resp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetUsersDetailsByUserIdResponse>(resp.ErrorCode, String.Join(Environment.NewLine, resp.ServiceMessages));
            }

            var userDetailsList = resp.UserCodeDtoList?.Select(userCodeDto => new ServiceGetUsersDetailsByUserIdResponse.UserDetailsDto
            {
                UserId = userCodeDto.UserId,
                UserFirstName = userCodeDto.UserFirstName,
                UserLastName = userCodeDto.UserLastName,
            }).ToList();


            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceGetUsersDetailsByUserIdResponse>();
            response.UserDetails = userDetailsList;
            return response;
        }
        #endregion

        #region GetResourceDetailList
        [HttpPost]
        [Route("GetResourceDetailList")]
        public async Task<ServiceMedimaxGetResourceIdListResponse> GetResourceDetailList(ServiceMedimaxGetResourceIdListRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetResourceIdListResponse>(errorCode, errorMsg);
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetResourceListRequest>(_portalSettings, mcBaseRequest);
            req.FillAdditionalUserKey = true;

            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetResourceListResponse, ServiceGetResourceListRequest>(
                _httpClientFactory, req, iisUrl, "Scheduler/GetResourceList");

            if (!resp.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetResourceIdListResponse>(resp.ErrorCode, String.Join(Environment.NewLine, resp.ServiceMessages));
            }

            var resourceList = resp.ResourceList;

            // Filter by TenantId if provided
            var filteredResources = resourceList?
                .Where(r => r.Type == 0 && r.MainDataId != null)
                .Where(r => !request.TenantId.HasValue || r.TenantId == request.TenantId)
                .Where(r => r.RecordState == 0) // Add this line to filter by RecordState
                .ToList();

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetResourceIdListResponse>();
            response.ResourceDetails = filteredResources;
            return response;
        }
        #endregion

        #region GetPatientCalendarEntryIdList
        [HttpPost]
        [Route("GetPatientCalendarEntryIdList")]
        public async Task<IActionResult> GetPatientCalendarEntryIdList(ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BadRequest(BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse>(errorCode, errorMsg));
            }

            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceReadAssignedResourcesToPatientCalendarEntryRequest>(_portalSettings, mcBaseRequest);
            if (request.ResourceId == null || !request.ResourceId.Any())
            {
                return BadRequest(BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse>(
                    "B105", "ResourceId list must be provided and contain at least one value."));
            }
            serviceRequest.ResourceIdList = request.ResourceId.ToList();


            var serviceResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceReadAssignedResourcesToPatientCalendarEntryResponse, ServiceReadAssignedResourcesToPatientCalendarEntryRequest>(
                _httpClientFactory, serviceRequest, iisUrl, "Scheduler/ReadAssignedResourcesToPatientCalendarEntry");

            if (!serviceResponse.Success)
            {
                return BadRequest(BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages)));
            }

            var response = new ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse
            {
                PatientCalendarEntryId = serviceResponse.AssignedResourcesList.Select(r => new PatientCalendarEntryDetails
                {
                    ResourceId = r.ResourceId,
                    PatientCalendarEntryId = r.PatientCalendarEntryId
                }).ToList()
            };

            return Ok(response);
        }
        #endregion

        #region GetAppointmentDetailsByPatientCalendarEntryId
        [HttpPost]
        [Route("GetAppointmentDetailsByPatientCalendarEntryId")]
        public async Task<ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse> GetAppointmentDetailsByPatientCalendarEntryId(
    ServiceGetAppointmentDetailsByPatientCalendarEntryIdRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse>(errorCode, errorMsg);
            }

            if (request.PatientCalendarEntryIdList == null || !request.PatientCalendarEntryIdList.Any())
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse>("B102", "The PatientCalendarEntryIdList must be set and contain at least one ID.");
            }

            var req = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetPatientCalendarEntryListRequest>(_portalSettings, mcBaseRequest);
            req.PatientIdList = request.PatientCalendarEntryIdList;

            var resp = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetPatientCalendarEntryListResponse, ServiceGetPatientCalendarEntryListRequest>(
                _httpClientFactory, req, iisUrl, "PatientCalendarEntry/GetPatientCalendarEntryList");

            if (!resp.Success)
            {
                // Return a standardized error response
                return BasicServiceWebHelper.CreateFaultResponse<ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse>(
                    resp.ErrorCode,
                    resp.ServiceMessages != null ? string.Join(Environment.NewLine, resp.ServiceMessages) : "Unknown error"
                );
            }

            // On success, return the data and set Success = true
            var response = new ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse
            {
                Success = true,
                PatientCalendarEntryDetails = resp.PatientCalendarEntryList?
                    .Where(entry => request.PatientCalendarEntryIdList.Contains(entry.PatientCalendarEntryID))
                    .Select(entry => new AppointmentDetailsForUser
                    {
                        PatientCalendarEntryID = entry.PatientCalendarEntryID,
                        StartDateTime = entry.StartDateTime,
                        EndDateTime = entry.EndDateTime
                    }).ToList()
            };

            return response;

        }

        #endregion

        #region GetUserResourceTimeListByResourceId
        [HttpPost]
        [Route("GetUserResourceTimeListByResourceId")]
        public async Task<ServiceMedimaxGetResourceTimeListResponse> GetUserResourceTimeListByResourceId(
            ServiceMedimaxGetResourceTimeListRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg, out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetResourceTimeListResponse>(errorCode, errorMsg);
            }

            if (request.ResourceIdList == null || !request.ResourceIdList.Any())
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetResourceTimeListResponse>(
                    "B106", "ResourceIdList must be provided and contain at least one value.");
            }

            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceGetResourceTimeListRequest>(_portalSettings, mcBaseRequest);
            serviceRequest.ResourceIdList = request.ResourceIdList;

            var serviceResponse = await BasicServiceWebHelper.CallMedCubesServiceAsync<ServiceGetResourceTimeListResponse, ServiceGetResourceTimeListRequest>(
                _httpClientFactory, serviceRequest, iisUrl, "Scheduler/GetResourceTimeList");

            if (!serviceResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxGetResourceTimeListResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxGetResourceTimeListResponse>();
            response.ResourceTimeList = serviceResponse.ResourceTimeList?
                .Where(rt => rt.RecordState == 0)
                .ToList();
            return response;
        }
        #endregion

        #region CancelPatientAppointment
        [HttpPost]
        [Route("CancelPatientAppointment")]
        public async Task<ServiceMedimaxDeletePatientAppointmentResponse> CancelPatientAppointment(
            ServiceMedimaxDeletePatientAppointmentRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDeletePatientAppointmentResponse>(errorCode,
                    errorMsg);
            }

            if (request.PkId == "")
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDeletePatientAppointmentResponse>("B103",
                    "The patient calendar entry id must be set!");
            }

            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceMedimaxDeletePatientCalendarEntryRequest>(_portalSettings, mcBaseRequest);
            //serviceRequest.PkIdToDelete = request.PkId;
            serviceRequest.PkIdToDelete = long.Parse(request.PkId);
            serviceRequest.CancelReason = request.CancelReason;
            serviceRequest.DeleteRemainingSeriesEntries = false;

            var serviceResponse = await BasicServiceWebHelper
                .CallMedCubesServiceAsync<ServiceMedimaxDeletePatientCalendarEntryResponse, ServiceMedimaxDeletePatientCalendarEntryRequest>(
                    _httpClientFactory, serviceRequest, iisUrl, "PatientCalendarEntry/MedimaxDeletePatientCalendarEntry");

            if (!serviceResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxDeletePatientAppointmentResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxDeletePatientAppointmentResponse>();
            response.IsDeleted = true;
            return response;
        }
        #endregion

        #region UpdatePatientAppointment
        [HttpPost]
        [Route("UpdatePatientAppointment")]
        public async Task<ServiceMedimaxUpdatePatientAppointmentResponse> UpdatePatientAppointment(
            ServiceMedimaxUpdatePatientAppointmentRequest request)
        {
            string errorCode;
            string errorMsg;
            string iisUrl;
            ServiceBaseRequest mcBaseRequest;
            if (!BasicServiceWebHelper.ValidateBaseWebRequest(_httpClientFactory, request, out errorCode, out errorMsg,
                    out iisUrl, out mcBaseRequest))
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxUpdatePatientAppointmentResponse>(errorCode,
                    errorMsg);
            }

            if (request.PatientCalendarEntryID == Guid.Empty)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxUpdatePatientAppointmentResponse>("B104",
                    "The patient calendar entry id must be set!");
            }

            var serviceRequest = BasicServiceWebHelper.CreateMedCubesRequest<ServiceMedimaxUpdatePatientCalendarEntryRequest>(_portalSettings, mcBaseRequest);
            serviceRequest.PkIdToUpdate = request.PkIdToUpdate;
            serviceRequest.PatientCalendarEntryID = request.PatientCalendarEntryID;
            serviceRequest.StartDateTime = request.StartDateTime;
            serviceRequest.EndDateTime = request.StartDateTime.AddHours(1);
            serviceRequest.UpdateReason = request.UpdateReason;

            var serviceResponse = await BasicServiceWebHelper
                .CallMedCubesServiceAsync<ServiceMedimaxUpdatePatientCalendarEntryResponse, ServiceMedimaxUpdatePatientCalendarEntryRequest>(
                    _httpClientFactory, serviceRequest, iisUrl, "PatientCalendarEntry/MedimaxUpdatePatientCalendarEntry");

            if (!serviceResponse.Success)
            {
                return BasicServiceWebHelper.CreateFaultResponse<ServiceMedimaxUpdatePatientAppointmentResponse>(serviceResponse.ErrorCode, String.Join(Environment.NewLine, serviceResponse.ServiceMessages));
            }

            var response = BasicServiceWebHelper.CreateSuccessResponse<ServiceMedimaxUpdatePatientAppointmentResponse>();
            return response;
        }
        #endregion

    }
}