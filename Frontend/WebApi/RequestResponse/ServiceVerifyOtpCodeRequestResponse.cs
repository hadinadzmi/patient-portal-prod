using PatientPortalBackend.Models;
using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceVerifyOtpCodeRequest : ServiceBaseWebRequest
    {
        public string PatientId { get; set; }
        public string OtpCodeInput { get; set; }
    }
    public class ServiceVerifyOtpCodeResponse : ServiceBaseWebResponse
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
