using Patient_Portal.Core;

namespace PatientPortalBackend.Models
{
    public class ServiceBaseWebRequest
    {
        public string TenantKey { get; set; }
        public string UserNamePatientPortal { get; set; }
        public string PasswordEncStr { get; set; }

        public ServiceBaseWebRequest()
        {
            TenantKey = GlobalData.TenantKey;
            UserNamePatientPortal = GlobalData.PatientPortalUserName;
            PasswordEncStr = GlobalData.PwEncStr;
        }
    }
}
