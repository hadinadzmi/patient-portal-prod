// this is to communicate wth the Frontend
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server.Models;

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
