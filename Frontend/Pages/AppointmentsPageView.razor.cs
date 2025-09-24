using System.Net.Http.Json;
using Patient_Portal.Core;
using Patient_Portal.WebApi;
using Patient_Portal.WebApi.Models;
using PatientPortalBackend.Models;
using System.Threading.Tasks;

namespace Patient_Portal.Pages
{
    public partial class AppointmentsPageView
    {
        private List<PatientAppointment> upcomingAppointments = new();
        private List<PatientAppointment> pastAppointments = new();
        private List<PatientAppointment> canceledAppointments = new();
        private List<PopupEntry> specialtyList = new(); // Add this line
        private bool showUpcomingAppointments = true;
        private bool showPastAppointments = false;
        private bool showCanceledAppointments = false;
        private bool showCancelModal = false;
        private bool showOtpVerification = false;
        private string cancelReason = string.Empty;
        private string selectedAppointmentId = string.Empty;
        private string otpCode = string.Empty;
        private string enteredOtpCode = string.Empty;
        private string otpErrorMessage = string.Empty;

        private bool showRescheduleModal = false;
        private bool showRescheduleOtpVerification = false;
        private string rescheduleReason = string.Empty;
        private DateTime rescheduleDate = DateTime.Today;
        private string selectedRescheduleAppointmentId = string.Empty;
        private string rescheduleOtpCode = string.Empty;
        private string enteredRescheduleOtpCode = string.Empty;
        private string rescheduleOtpErrorMessage = string.Empty;

        private List<PopupEntry> planningStateList = new();
        private Dictionary<int, string> planningStateTextByCode = new();

        private List<DepartmentWithServiceUnitsDto> departmentList = new();

        private Dictionary<long, string> serviceUnitIdToDoctorName = new();

        protected override async Task OnInitializedAsync()
        {
            await CheckAllowed(LocalStorage);

            if (!IsAllowed)
            {
                await Task.Delay(3000);
                NavigationManager.NavigateTo("/", false, true);
                return;
            }

            await LoadResourceDetails(); // <-- Add this line
            await LoadDepartments();
            await LoadSpecialties();
            await LoadPlanningState();
            await LoadAppointments();
        }

        private string GetDoctorName(long? serviceUnitId)
        {
            if (serviceUnitId.HasValue && serviceUnitIdToDoctorName.TryGetValue(serviceUnitId.Value, out var name))
                return name;
            return "Unknown Doctor";
        }

        private async Task LoadResourceDetails()
        {
            var request = new ServiceMedimaxGetResourceIdListRequest();
            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxGetResourceIdListResponse, ServiceMedimaxGetResourceIdListRequest>(
                _httpClient, request, ServiceUris.GetResourceDetailsByUserIdUri);

            if (response != null && response.Success && response.ResourceDetails != null)
            {
                serviceUnitIdToDoctorName = response.ResourceDetails
                    .GroupBy(r => r.ServiceUnitId)
                    .ToDictionary(g => g.Key, g => g.First().Name);
            }
        }

        private async Task LoadSpecialties() // Add this method
        {
            var request = new ServiceMedimaxGetPopupsListRequest
            {
                PtPopupKey = "Specialization"
            };

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxGetPopupsListResponse, ServiceMedimaxGetPopupsListRequest>(_httpClient, request, ServiceUris.GetPopupDetailsListUri);

            if (response != null && response.Success)
            {
                specialtyList = response.PopupEntryList;
            }
        }

        // Add this method to load departments
        private async Task LoadDepartments()
        {
            var request = new ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest();
            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse, ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest>(
                _httpClient, request, ServiceUris.GetDepartmentDetailsAndServiceUnitsUri);

            if (response != null && response.Success)
            {
                departmentList = response.Departments;
            }
        }

        // Add this method to get department name by id
        private string GetDepartmentName(int departmentId)
        {
            var dept = departmentList.FirstOrDefault(d => d.DepartmentId == departmentId);
            return dept?.DepartmentName ?? "Unknown Specialty";
        }

        private string GetSpecialtyText(int specialtyCode) // Add this method
        {
            var entry = specialtyList.FirstOrDefault(e => e.PopupEntryCode == specialtyCode);
            return entry?.Text ?? "Unknown Specialty";
        }

        private async Task LoadPlanningState()
        {
            var request = new ServiceMedimaxGetPopupsListRequest
            {
                PtPopupKey = "PlanningState"
            };

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxGetPopupsListResponse, ServiceMedimaxGetPopupsListRequest>(_httpClient, request, ServiceUris.GetPopupDetailsListUri);

            if (response != null && response.Success)
            {
                planningStateList = response.PopupEntryList;
                planningStateTextByCode = planningStateList
                    .GroupBy(e => e.PopupEntryCode)
                    .Select(g => g.First())
                    .ToDictionary(e => e.PopupEntryCode, e => e.Text);
            }
        }

        private string GetStatus(PatientAppointment appointment)
        {
            if (appointment.RecordState == "1")
            {
                return "Cancelled";
            }

            if (appointment.PlanningState.HasValue && planningStateTextByCode.TryGetValue(appointment.PlanningState.Value, out var planningStateText))
            {
                return planningStateText;
            }

            if (appointment.RecordState == "0" && appointment.StartDateTime < DateTimeOffset.Now)
            {
                return "Missed";
            }

            return "Pending";
        }

        private async Task LoadAppointments()
        {
            SetBusy(true);

            var request = new ServiceGetPatientAppointmentsRequest
            {
                PatientId = GlobalData.PatientId
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceGetPatientAppointmentsResponse, ServiceGetPatientAppointmentsRequest>(_httpClient, request,
                    ServiceUris.GetPatientAppointmentUri);

            if (response != null && response.Success)
            {
                var now = DateTimeOffset.Now;

                upcomingAppointments = response.AppointmentList
                    .Where(a =>
                    {
                        var status = GetStatus(a);
                        return (status == "Planned" || status == "Confirmed" || status == "In Process")
                            && a.StartDateTime >= now;
                    })
                    .ToList();

                pastAppointments = response.AppointmentList
                    .Where(a =>
                    {
                        var status = GetStatus(a);
                        // Completed, or Planned/Confirmed/In Process but already in the past
                        return status == "Completed"
                            || ((status == "Planned" || status == "Confirmed" || status == "In Process")
                                && a.StartDateTime < now);
                    })
                    .ToList();

                canceledAppointments = response.AppointmentList
                    .Where(a =>
                    {
                        var status = GetStatus(a);
                        return status == "Cancelled";
                    })
                    .ToList();
            }

            SetBusy(false);
        }

        private void NavigateToBookAppointment()
        {
            NavigationManager.NavigateTo("/book-appointment");
        }

        private void ShowUpcomingAppointments()
        {
            showUpcomingAppointments = true;
            showPastAppointments = false;
            showCanceledAppointments = false;
        }

        private void ShowPastAppointments()
        {
            showUpcomingAppointments = false;
            showPastAppointments = true;
            showCanceledAppointments = false;
        }

        private void ShowCanceledAppointments()
        {
            showUpcomingAppointments = false;
            showPastAppointments = false;
            showCanceledAppointments = true;
        }

        private void ShowCancelModal(string appointmentId)
        {
            selectedAppointmentId = appointmentId;
            showCancelModal = true;
            showOtpVerification = false;
        }

        private void CloseCancelModal()
        {
            showCancelModal = false;
            cancelReason = string.Empty;
            showOtpVerification = false;
            otpCode = string.Empty;
            enteredOtpCode = string.Empty;
            otpErrorMessage = string.Empty;
        }

        private async Task SendOtp()
        {
            var request = new ServiceGetMaxConfirmationCodeRequest()
            {
                patNRIC = GlobalData.PatientNRIC,
                patMobileNum = GlobalData.PatientMobileNumber,
                RequestType = "Cancel"
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceGetMaxConfirmationCodeResponse, ServiceGetMaxConfirmationCodeRequest>(_httpClient, request,
                    ServiceUris.GetConfirmationCodeUri);

            if (response.Success)
            {
                showOtpVerification = true;
            }
            else
            {
                // Handle error
            }
        }

        private async Task VerifyOtp()
        {
            var request = new ServiceMedimaxVerifyConfirmationCodeRequest
            {
                PatientId = GlobalData.PatientId.ToString(),
                ConfirmationCode = enteredOtpCode,
                RequestType = "Cancel"
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceMedimaxVerifyConfirmationCodeResponse, ServiceMedimaxVerifyConfirmationCodeRequest>(_httpClient, request,
                    ServiceUris.VerifyConfirmationCodeUri);

            if (response.Success)
            {
                await ConfirmCancelAppointment();
                otpErrorMessage = string.Empty; // Clear error message
            }
            else
            {
                otpErrorMessage = "Invalid OTP number.";
            }
        }

        private async Task ConfirmCancelAppointment()
        {
            SetBusy(true);

            var request = new ServiceMedimaxDeletePatientAppointmentRequest
            {
                PkId = selectedAppointmentId,
                CancelReason = cancelReason
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceMedimaxDeletePatientAppointmentResponse, ServiceMedimaxDeletePatientAppointmentRequest>(_httpClient, request,
                    ServiceUris.CancelPatientAppointmentUri);

            if (response != null && response.Success)
            {
                await LoadAppointments();
                CloseCancelModal();
            }
            else
            {
                // Handle error
            }

            SetBusy(false);
        }

        private void ShowRescheduleModal(string appointmentId)
        {
            selectedRescheduleAppointmentId = appointmentId;
            showRescheduleModal = true;
            showRescheduleOtpVerification = false;
        }

        private void CloseRescheduleModal()
        {
            showRescheduleModal = false;
            rescheduleReason = string.Empty;
            rescheduleDate = DateTime.Today;
            showRescheduleOtpVerification = false;
            rescheduleOtpCode = string.Empty;
            enteredRescheduleOtpCode = string.Empty;
            rescheduleOtpErrorMessage = string.Empty;
        }

        private async Task SendRescheduleOtp()
        {
            var request = new ServiceGetMaxConfirmationCodeRequest()
            {
                patNRIC = GlobalData.PatientNRIC,
                patMobileNum = GlobalData.PatientMobileNumber,
                RequestType = "Reschedule"
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceGetMaxConfirmationCodeResponse, ServiceGetMaxConfirmationCodeRequest>(_httpClient, request,
                    ServiceUris.GetConfirmationCodeUri);

            if (response.Success)
            {
                showRescheduleOtpVerification = true;
            }
            else
            {
                // Handle error
            }
        }

        private async Task VerifyRescheduleOtp()
        {
            var request = new ServiceMedimaxVerifyConfirmationCodeRequest
            {
                PatientId = GlobalData.PatientId.ToString(),
                ConfirmationCode = enteredRescheduleOtpCode,
                RequestType = "Reschedule"
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceMedimaxVerifyConfirmationCodeResponse, ServiceMedimaxVerifyConfirmationCodeRequest>(_httpClient, request,
                    ServiceUris.VerifyConfirmationCodeUri);

            if (response.Success)
            {
                await ConfirmRescheduleAppointment();
                rescheduleOtpErrorMessage = string.Empty; // Clear error message
            }
            else
            {
                rescheduleOtpErrorMessage = "Invalid OTP number.";
            }
        }

        private async Task ConfirmRescheduleAppointment()
        {
            SetBusy(true);

            var appointment = upcomingAppointments.FirstOrDefault(a => a.PkID == selectedRescheduleAppointmentId);
            if (appointment == null)
            {
                SetBusy(false);
                return;
            }

            var request = new ServiceMedimaxUpdatePatientAppointmentRequest
            {
                PkIdToUpdate = long.Parse(appointment.PkID),
                PatientCalendarEntryID = appointment.PatientCalendarEntryID,
                StartDateTime = rescheduleDate,
                UpdateReason = rescheduleReason
            };

            var prx = new ServiceProxy(this);
            var response =
                await prx.CallWebApi<ServiceMedimaxUpdatePatientAppointmentResponse, ServiceMedimaxUpdatePatientAppointmentRequest>(_httpClient, request,
                    ServiceUris.UpdatePatientAppointmentUri);

            if (response != null && response.Success)
            {
                await LoadAppointments();
                CloseRescheduleModal();
            }
            else
            {
                // Handle error
            }

            SetBusy(false);
        }
    }
}
