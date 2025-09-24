using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxDeletePatientAppointmentRequest : ServiceBaseWebRequest
    {
        public string PkId { get; set; }
        public string CancelReason { get; set; }
    }

    public class ServiceMedimaxDeletePatientAppointmentResponse : ServiceBaseWebResponse
    {
        public bool IsDeleted { get; set; }
    }
}
