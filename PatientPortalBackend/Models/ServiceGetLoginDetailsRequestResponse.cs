using System;

namespace PatientPortalBackend.Models
{
    public class ServiceGetLoginDetailsRequest : ServiceBaseWebRequest
    {
        public string PatientNric { get; set; }
        public string PatientPassword { get; set; }

    }

    public class ServiceGetLoginDetailsResponse : ServiceBaseWebResponse
    {
        public Guid PatId { get; set; }
        public string PatName { get; set; }
        public string PatNRIC { get; set; }
        public string PatMobileNum { get; set; } // new
        public string PatDOB { get; set; } // new
    }
}
