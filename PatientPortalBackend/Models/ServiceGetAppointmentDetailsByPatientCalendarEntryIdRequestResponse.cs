using System;
using System.Collections.Generic;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels;

namespace PatientPortalBackend.Models
{
    public class ServiceGetAppointmentDetailsByPatientCalendarEntryIdRequest : ServiceBaseWebRequest
    {
        public List<Guid> PatientCalendarEntryIdList { get; set; }
    }


    public class ServiceGetAppointmentDetailsByPatientCalendarEntryIdResponse : ServiceBaseWebResponse
    {
        public List<AppointmentDetailsForUser> PatientCalendarEntryDetails { get; set; }
    }

    public class AppointmentDetailsForUser
    {
        public Guid PatientCalendarEntryID { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
    }
}
