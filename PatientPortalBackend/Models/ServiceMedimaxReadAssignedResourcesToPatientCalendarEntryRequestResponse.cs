using System;
using System.Collections.Generic;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxReadAssignedResourcesToPatientCalendarEntryRequest : ServiceBaseWebRequest
    {
        public List<Guid> ResourceId { get; set; }
        //public long UserId { get; set; } // Added UserId
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
