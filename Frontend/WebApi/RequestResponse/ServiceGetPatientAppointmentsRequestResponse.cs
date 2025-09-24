using Patient_Portal.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceGetPatientAppointmentsRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
    }

    public class ServiceGetPatientAppointmentsResponse : ServiceBaseWebResponse
    {
        public List<PatientAppointment> AppointmentList { get; set; }
    }
}
