using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceVerifyMobileNumberRequest : ServiceBaseWebRequest
    {
        public string MobileNumber { get; set; }
    }
    public class ServiceVerifyMobileNumberResponse : ServiceBaseWebResponse
    {
        public string PatientId { get; set; }
        public string OTPNumber { get; set; }
    }
}
