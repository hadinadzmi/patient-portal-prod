using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceSendNewPasswordRequest : ServiceBaseWebRequest
    {
        public string PatientId { get; set; }
        public string NewConfirmPassword { get; set; }
    }
    public class ServiceSendNewPasswordResponse : ServiceBaseWebResponse
    {
        //nothing here
    }
}
