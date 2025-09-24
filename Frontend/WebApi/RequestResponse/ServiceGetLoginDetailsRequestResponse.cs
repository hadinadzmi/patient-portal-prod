using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceGetLoginDetailsRequest : ServiceBaseWebRequest //send NRIC (PatientId) and Password to EMR
    {
        public string PatientNric { get; set; }
        public string PatientPassword { get; set; }
    }

    public class ServiceGetLoginDetailsResponse : ServiceBaseWebResponse //EMR response with Patient NRIC,Name, and Patient Id if login is successful
    {
        public Guid PatId { get; set; }
        public string PatName { get; set; }
        public string PatNRIC { get; set; }
        public string PatMobileNum { get; set; } // Add this line
        public string PatDOB { get; set; } // Add this line
    }
}