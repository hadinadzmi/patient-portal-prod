namespace PatientPortalBackend.Models
{
    public class ServiceGetMaxConfirmationCodeRequest : ServiceBaseWebRequest
    {
        public string patNRIC { get; set; }
        public string patMobileNum { get; set; }
        public string RequestType { get; set; }
        public string patAddressCountryCode { get; set; } // Add this property
    }

    public class ServiceGetMaxConfirmationCodeResponse : ServiceBaseWebResponse
    {
        public Guid patID { get; set; }
        public string patName { get; set; }
        public string patNRIC { get; set; }
        public string patMobileNum { get; set; }
        public string patAddressCountryCode { get; set; }
    }
}
