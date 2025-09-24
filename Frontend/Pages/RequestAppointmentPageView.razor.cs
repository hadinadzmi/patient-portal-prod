using Microsoft.AspNetCore.Components;
using Patient_Portal.Core;
using System.Globalization;
using Patient_Portal.WebApi;
using PatientPortalBackend.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Patient_Portal.WebApi.Models;
using static PatientPortalBackend.Models.ServiceGetUsersDetailsByUserIdResponse;

namespace Patient_Portal.Pages
{
    public partial class RequestAppointmentPageView : McComponentBase
    {
        private AppointmentFormModel formModel = new AppointmentFormModel(); // Use the new model class

        private string selectedTime;
        private bool isInsuranceSelected = false;
        private DateTime currentMonth = DateTime.Now;
        private DateTime selectedDate = DateTime.MinValue;
        private readonly string[] daysOfWeek = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedDayNames;

        private ServiceMedimaxGetResourceTimeListResponse.ResourceTime? openResourceTimeForSelectedDate;
        private List<ServiceMedimaxGetResourceTimeListResponse.ResourceTime> resourceTimesForSelectedResource = new();

        private List<TenantDto> tenantList = new();

        private List<DateTime> unavailableDates = new();
        private List<string> unavailableTimeSlots = new();
        private List<string> blockedTimeSlots = new();

        private bool showSuccessModal = false;
        private bool showErrorModal = false;
        private string modalMessage = string.Empty;

        private int countdown = 5; // Countdown timer in seconds
        private bool isButtonEnabled = false;

        private long? selectedTenantId;
        private long? selectedDepartmentId;
        private List<DepartmentWithServiceUnitsDto> filteredDepartmentList = new();

        private List<ServiceUnitDto> filteredDoctorList = new();
        private long? selectedDoctorId;

        private List<ResourceDetailDto> resourceDetailList = new();
        private Guid? selectedResourceId;

        public List<PatientCalendarEntryDetails> PatientCalendarEntryId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BlockSundaysInCurrentMonth(); // Block Sundays immediately
            await FetchTenantList();
        }

        private void BlockSundaysInCurrentMonth()
        {
            unavailableDates ??= new List<DateTime>();
            foreach (var day in GetDaysInMonth())
            {
                if (day.DayOfWeek == DayOfWeek.Sunday && !unavailableDates.Contains(day.Date))
                {
                    unavailableDates.Add(day.Date);
                }
            }
        }

        private async Task FetchTenantList()
        {
            SetBusy(true);

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceGetTenantDetailsResponse, ServiceBaseWebRequest>(_httpClient, new ServiceBaseWebRequest(), ServiceUris.GetTenantDetailsUri);

            if (response != null && response.Success)
            {
                tenantList = response.TenantList;
            }

            SetBusy(false);
        }

        private async Task OnTenantChanged(ChangeEventArgs e)
        {
            if (long.TryParse(e.Value?.ToString(), out var tenantId))
            {
                selectedTenantId = tenantId;
                await FetchDepartmentsByTenantId(tenantId);
            }
            else
            {
                selectedTenantId = null;
                filteredDepartmentList.Clear();
            }
            selectedDepartmentId = null;
            StateHasChanged();
        }

        private async Task FetchDepartmentsByTenantId(long tenantId)
        {
            SetBusy(true);

            var prx = new ServiceProxy(this);
            var request = new ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest
            {
                TenantId = tenantId
            };

            var response = await prx.CallWebApi<ServiceMedimaxGetDepartmentDetailsAndServiceUnitResponse, ServiceMedimaxGetDepartmentDetailsAndServiceUnitRequest>(
                _httpClient, request, ServiceUris.GetDepartmentDetailsAndServiceUnitsUri);

            if (response != null && response.Success)
            {
                // Filter and sort departments by TenantId and DepartmentName (A-Z)
                filteredDepartmentList = response.Departments
                    .Where(d => d.TenantId == tenantId)
                    .OrderBy(d => d.DepartmentName)
                    .ToList();
            }
            else
            {
                filteredDepartmentList.Clear();
            }

            SetBusy(false);
        }

        private async Task OnDepartmentChanged(ChangeEventArgs e)
        {
            if (long.TryParse(e.Value?.ToString(), out var departmentId))
            {
                selectedDepartmentId = departmentId;
                await FetchDoctorsByDepartmentId(departmentId);
            }
            else
            {
                selectedDepartmentId = null;
                filteredDoctorList.Clear();
            }
            selectedDoctorId = null;
            StateHasChanged();
        }

        private async Task FetchDoctorsByDepartmentId(long departmentId)
        {
            filteredDoctorList.Clear();

            // Find the selected department in the already-fetched filteredDepartmentList
            var department = filteredDepartmentList.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null && department.ServiceUnits != null)
            {
                // Sort doctors (service units) by name A-Z
                filteredDoctorList = department.ServiceUnits
                    .OrderBy(su => su.ServiceUnitName)
                    .ToList();
            }
            else
            {
                filteredDoctorList = new List<ServiceUnitDto>();
            }
        }

        private async Task OnDoctorChanged(ChangeEventArgs e)
        {
            if (long.TryParse(e.Value?.ToString(), out var doctorId))
            {
                selectedDoctorId = doctorId;
                await FetchResourceDetailsByDoctorId(doctorId);
                await FetchAssignedResourceCalendarEntries();
                await FetchResourceTimesForSelectedDoctor();
            }
            else
            {
                selectedDoctorId = null;
                resourceDetailList.Clear();
                selectedResourceId = null;
                blockedTimeSlots.Clear();
                unavailableTimeSlots.Clear();
            }
            StateHasChanged();
        }

        private async Task FetchResourceDetailsByDoctorId(long doctorId)
        {
            resourceDetailList.Clear();
            selectedResourceId = null;

            if (selectedTenantId == null)
                return;

            SetBusy(true);

            var prx = new ServiceProxy(this);
            var request = new ServiceMedimaxGetResourceIdListRequest
            {
                TenantId = selectedTenantId
            };

            var response = await prx.CallWebApi<ServiceMedimaxGetResourceIdListResponse, ServiceMedimaxGetResourceIdListRequest>(
                _httpClient, request, ServiceUris.GetResourceDetailsByUserIdUri);

            if (response != null && response.Success && response.ResourceDetails != null)
            {
                // Filter resources for the selected doctor (ServiceUnitId)
                resourceDetailList = response.ResourceDetails
                    .Where(r => r.ServiceUnitId == doctorId)
                    .ToList();

                // Optionally select the first resource by default
                selectedResourceId = resourceDetailList.FirstOrDefault()?.ResourceId;
            }
            else
            {
                resourceDetailList.Clear();
                selectedResourceId = null;
            }

            // You may want to update unavailableDates/unavailableTimeSlots here based on selectedResourceId

            SetBusy(false);
        }

        // This is to pull existing appointments for the selected resource
        // This will block dates/times that are already booked
        // Status : "Not Available" (Red highlight)
        private async Task FetchAssignedResourceCalendarEntries()
        {
            unavailableDates.Clear();
            unavailableTimeSlots.Clear();
            BlockSundaysInCurrentMonth();

            if (selectedResourceId == null)
                return;

            SetBusy(true);

            var prx = new ServiceProxy(this);

            // 1. Get PatientCalendarEntryId for the selected resource
            var resourceRequest = new ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryRequest
            {
                ResourceId = new[] { selectedResourceId.Value }
            };

            var resourceResponse = await prx.CallWebApi<ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse, ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryRequest>(
                _httpClient, resourceRequest, ServiceUris.GetAppointmentDetailsByPatientCalendarEntryIdUri);

            if (resourceResponse != null && resourceResponse.PatientCalendarEntryId != null && resourceResponse.PatientCalendarEntryId.Count > 0)
            {
                var calendarEntryIds = resourceResponse.PatientCalendarEntryId
                    .Select(x => x.PatientCalendarEntryId)
                    .ToArray();

                // Add this check:
                if (calendarEntryIds.Length == 0)
                {
                    SetBusy(false);
                    return;
                }

                var appointmentRequest = new ServiceGetAppointmentDetailsByPatientCalendarEntryIdRequest
                {
                    PatientCalendarEntryIdList = calendarEntryIds
                };

                var appointmentResponse = await prx.CallWebApi<ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse, ServiceGetAppointmentDetailsByPatientCalendarEntryIdRequest>(
                    _httpClient, appointmentRequest, ServiceUris.GetAppointmentDetailsUri);

                if (appointmentResponse != null && appointmentResponse.PatientCalendarEntryDetails != null)
                {
                    foreach (var appointment in appointmentResponse.PatientCalendarEntryDetails)
                    {
                        var startTime = appointment.StartDateTime.TimeOfDay;
                        var endTime = appointment.EndDateTime?.TimeOfDay ?? startTime.Add(TimeSpan.FromHours(1)); // Default 1 hour if EndDateTime is null

                        // Block the whole date if all slots are booked (9:00 AM to 5:30 PM)
                        if (startTime <= new TimeSpan(9, 0, 0) && endTime >= new TimeSpan(17, 30, 0))
                        {
                            if (!unavailableDates.Contains(appointment.StartDateTime.Date))
                                unavailableDates.Add(appointment.StartDateTime.Date);
                        }

                        // Block time slots for the selected date
                        if (appointment.StartDateTime.Date == selectedDate.Date)
                        {
                            foreach (var timeSlot in GetTimeSlots())
                            {
                                var time = DateTime.ParseExact(timeSlot, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                                if (time >= startTime && time < endTime)
                                {
                                    if (!unavailableTimeSlots.Contains(timeSlot))
                                        unavailableTimeSlots.Add(timeSlot);
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                // Optionally clear unavailable slots if no entries found
                unavailableDates.Clear();
                unavailableTimeSlots.Clear();
            }

            SetBusy(false);
        }

        // This is to pull resource times (open/close) for the selected doctor/resource
        private async Task FetchResourceTimesForSelectedDoctor()
        {
            blockedTimeSlots.Clear();
            openResourceTimeForSelectedDate = null; // Reset

            if (selectedResourceId == null || selectedDate == DateTime.MinValue)
                return;

            SetBusy(true);

            var prx = new ServiceProxy(this);
            var request = new ServiceMedimaxGetResourceTimeListRequest
            {
                ResourceIdList = new[] { selectedResourceId.Value }
            };

            var response = await prx.CallWebApi<ServiceMedimaxGetResourceTimeListResponse, ServiceMedimaxGetResourceTimeListRequest>(
                _httpClient, request, ServiceUris.GetUserResourceTimeListByResourceIdUri);

            if (response != null && response.Success && response.ResourceTimeList != null)
            {
                resourceTimesForSelectedResource = response.ResourceTimeList
                    .Where(rt => rt.ResourceId == selectedResourceId.Value)
                    .ToList();

                // Find open time for selected weekday
                openResourceTimeForSelectedDate = GetOpenResourceTimeForSelectedWeekday(resourceTimesForSelectedResource);

                // Blocked/closed logic (Type == 1) can remain as is
                foreach (var resourceTime in resourceTimesForSelectedResource)
                {
                    if (resourceTime.Type == 1)
                    {
                        // All-day/multi-day event: block all slots if selectedDate is within the range
                        if (selectedDate.Date >= resourceTime.TimeFrom.Date && selectedDate.Date < resourceTime.TimeUntil.Date)
                        {
                            foreach (var timeSlot in GetTimeSlots())
                            {
                                if (!blockedTimeSlots.Contains(timeSlot))
                                    blockedTimeSlots.Add(timeSlot);
                            }
                        }
                        // Partial-day event: block only the slots within the time range for the selected date
                        else if (resourceTime.TimeFrom.Date == selectedDate.Date)
                        {
                            var timeFrom = resourceTime.TimeFrom.TimeOfDay;
                            var timeUntil = resourceTime.TimeUntil.TimeOfDay;

                            foreach (var timeSlot in GetTimeSlots())
                            {
                                var slotTime = DateTime.ParseExact(timeSlot, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                                if (slotTime >= timeFrom && slotTime < timeUntil)
                                {
                                    if (!blockedTimeSlots.Contains(timeSlot))
                                        blockedTimeSlots.Add(timeSlot);
                                }
                            }
                        }
                    }
                }
            }

            SetBusy(false);
        }

        private async Task StartCountdown()
        {
            isButtonEnabled = false;
            while (countdown > 0)
            {
                await Task.Delay(1000);
                countdown--;
                StateHasChanged();
            }
            isButtonEnabled = true;
            StateHasChanged();

            // Auto-redirect after countdown if success modal is shown
            if (showSuccessModal)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private void ShowSuccessModal(string message)
        {
            modalMessage = message;
            showSuccessModal = true;
            countdown = 5; // Reset countdown
            _ = StartCountdown(); // Start countdown

            // Refresh unavailable slots after booking
            _ = RefreshUnavailableSlots();
        }

        private async Task RefreshUnavailableSlots()
        {
            await FetchAssignedResourceCalendarEntries();
            // Optionally, re-select the date to update time slots
            if (selectedDate != DateTime.MinValue)
            {
                await SelectDate(selectedDate);
            }
        }

        private void ShowErrorModal(string message)
        {
            modalMessage = message;
            showErrorModal = true;
            countdown = 5; // Reset countdown
            _ = StartCountdown(); // Start countdown
        }

        private void CloseModal()
        {
            if (showSuccessModal)
            {
                showSuccessModal = false;
                modalMessage = string.Empty;
                isButtonEnabled = false;
                NavigationManager.NavigateTo("/"); // Redirect to root after success
            }
            else if (showErrorModal)
            {
                showErrorModal = false;
                modalMessage = string.Empty;
                isButtonEnabled = false;
            }
        }

        private async Task HandleValidSubmit()
        {
            // Validate required fields
            if (selectedTenantId == null ||
                selectedDepartmentId == null ||
                selectedDoctorId == null ||
                selectedResourceId == null ||
                selectedDate == DateTime.MinValue ||
                string.IsNullOrEmpty(selectedTime) ||
                formModel.PatientMobileNumber == null ||
                formModel.PatientName == null
                //string.IsNullOrEmpty(formModel.PaymentMethod)
                )
            {
                ShowErrorModal("Please complete all required fields before submitting.");
                return;
            }

            SetBusy(true);

            try
            {
                // Build the appointment request
                var request = new ServiceCreatePatientAppointmentRequest
                {
                    // Appointment Information
                    SpecialtyId = (int)selectedDepartmentId.Value, // Explicit cast to int
                    AppointmentDateTimeStr = $"{selectedDate:yyyy-MM-dd} {DateTime.ParseExact(selectedTime, "h:mm tt", CultureInfo.InvariantCulture):HH:mm}",
                    MedimaxServiceUnitId = selectedDoctorId.Value,
                    MedimaxResourceId = selectedResourceId.Value,

                    // Patient Information
                    Name = "Appointment",
                    PatientId = new Guid("00000000-0000-0000-0000-000000000000"), // decidated profile for non mrn booking request
                    AdditionalMsg = "[Non-Existing Patient] " + formModel.PatientName + ";" + formModel.PatientMobileNumber + ";"
                };

                var prx = new ServiceProxy(this);
                var response = await prx.CallWebApi<ServiceCreatePatientAppointmentResponse, ServiceCreatePatientAppointmentRequest>(
                    _httpClient, request, ServiceUris.CreatePatientAppointmentUri);

                if (response != null && response.Success)
                {
                    ShowSuccessModal("Your appointment has been booked successfully.");
                }
                else
                {
                    ShowErrorModal("Failed to book your appointment. Please try again.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorModal($"An error occurred: {ex.Message}");
            }
            finally
            {
                SetBusy(false);
            }
        }

        // CALENDAR
        private void PreviousMonth()
        {
            currentMonth = currentMonth.AddMonths(-1);
            BlockSundaysInCurrentMonth();
        }

        private void NextMonth()
        {
            currentMonth = currentMonth.AddMonths(1);
            BlockSundaysInCurrentMonth();
        }

        private IEnumerable<DateTime> GetDaysInMonth()
        {
            var firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            for (int i = 0; i < daysInMonth; i++)
            {
                yield return firstDayOfMonth.AddDays(i);
            }
        }

        private async Task SelectDate(DateTime date)
        {
            if (!IsPastDate(date) && !unavailableDates.Contains(date.Date))
            {
                selectedDate = date;
                selectedTime = null; // Reset the selected time
                await FetchAssignedResourceCalendarEntries(); // Update time slots for this date
                await FetchResourceTimesForSelectedDoctor(); // <-- Add this
            }
            else
            {
                unavailableTimeSlots.Clear();
                foreach (var timeSlot in GetTimeSlots())
                {
                    unavailableTimeSlots.Add(timeSlot);
                }
            }
        }

        private bool IsPastDate(DateTime date)
        {
            // Only allow dates at least 24 hours from now
            return date < DateTime.Now.AddDays(1).Date;
        }

        private string GetDayClass(DateTime day)
        {
            if (IsPastDate(day))
            {
                return "past";
            }
            if (unavailableDates.Contains(day.Date))
            {
                return "unavailable";
            }
            return day.Date == selectedDate.Date ? "selected" : string.Empty;
        }

        private bool IsCurrentMonth()
        {
            return currentMonth.Year == DateTime.Now.Year && currentMonth.Month == DateTime.Now.Month;
        }

        // SELECT / DESELECT TIME
        private void SelectTime(string time)
        {
            if (selectedTime == time)
            {
                selectedTime = null; // Deselect if the same time is clicked again
            }
            else
            {
                selectedTime = time;
            }
        }

        // TIME
        private List<string> GetTimeSlots()
        {
            var timeSlots = new List<string>
{
    "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM",
    "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM",
    "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM",
    "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM", "8:00 PM", "8:30 PM", "9:00 PM"
};

            var minAllowed = DateTime.Now.AddHours(24);

            if (selectedDate.Date == minAllowed.Date)
            {
                timeSlots = timeSlots.Where(timeSlot =>
                {
                    var time = DateTime.ParseExact(timeSlot, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                    return time >= minAllowed.TimeOfDay;
                }).ToList();
            }

            // Filter by doctor's open hours for the selected weekday
            if (openResourceTimeForSelectedDate != null)
            {
                var openFrom = openResourceTimeForSelectedDate.TimeFrom.TimeOfDay;
                var openUntil = openResourceTimeForSelectedDate.TimeUntil.TimeOfDay;

                timeSlots = timeSlots.Where(timeSlot =>
                {
                    var time = DateTime.ParseExact(timeSlot, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                    return time >= openFrom && time < openUntil;
                }).ToList();
            }

            return timeSlots;
        }

        private ServiceMedimaxGetResourceTimeListResponse.ResourceTime? GetOpenResourceTimeForSelectedWeekday(List<ServiceMedimaxGetResourceTimeListResponse.ResourceTime> resourceTimes)
        {
            if (selectedResourceId == null || selectedDate == DateTime.MinValue)
                return null;

            // .NET: DayOfWeek enum: Sunday=0, Monday=1, ..., Saturday=6
            // ResourceTime.Weekday: 1=Monday, ..., 7=Sunday
            int selectedWeekday = ((int)selectedDate.DayOfWeek == 0) ? 7 : (int)selectedDate.DayOfWeek;

            return resourceTimes
                .Where(rt => rt.ResourceId == selectedResourceId.Value && rt.Type == 0 && rt.Weekday == selectedWeekday)
                .OrderBy(rt => rt.TimeFrom.TimeOfDay)
                .FirstOrDefault();
        }

        // HANDLE PAYMENT METHOD CHANGE
        private void OnPaymentMethodChanged(ChangeEventArgs e)
        {
            formModel.PaymentMethod = e.Value.ToString();
            isInsuranceSelected = formModel.PaymentMethod == "insurance";
        }

        // CANCEL BOOKING
        private void CancelBooking()
        {
            NavigationManager.NavigateTo("/senalogin");
        }
    }
}
