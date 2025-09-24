using System;

namespace PatientPortalBackend.Models
{
    public class ServiceUpdatePatientAppointmentStatusRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
        public Guid PatientCalendarEntryId { get; set; }
        public int PlanningState { get; set; }
        public bool IsCheckIn { get; set; }
        public bool IsCancel { get; set; }
    }

    public class ServiceUpdatePatientAppointmentStatusResponse : ServiceBaseWebResponse
    {
    }
}