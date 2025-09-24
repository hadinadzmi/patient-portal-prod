using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceBaseWebRequest
    {
        public string TenantKey { get; set; }
        public string UserNamePatientPortal { get; set; }
        public string PasswordEncStr { get; set; }
    }
}
