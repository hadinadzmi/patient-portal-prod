using System;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxUpdatePatientAppointmentRequest : ServiceBaseWebRequest
    {
        public long PkIdToUpdate { get; set; }
        public Guid PatientCalendarEntryID { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public string UpdateReason { get; set; }
    }

    public class ServiceMedimaxUpdatePatientAppointmentResponse : ServiceBaseWebResponse
    {
        public bool IsUpdated { get; set; }
    }
}
