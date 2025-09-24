using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryRequest : ServiceBaseWebRequest
    {
        public Guid[] ResourceId { get; set; } // Changed to array
    }


    public class ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryResponse : ServiceBaseWebResponse
    {
        public List<PatientCalendarEntryDetails> PatientCalendarEntryId { get; set; }
    }

    public class PatientCalendarEntryDetails
    {
        public Guid ResourceId { get; set; }
        public Guid PatientCalendarEntryId { get; set; }
    }
}
