using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceVerifyConfirmationCodeRequest : ServiceBaseWebRequest
    {
        public string PatientId { get; set; }
        public string ConfirmationCode { get; set; }
        public bool OnlyReturnFirstName { get; set; }
    }

    public class ServiceVerifyConfirmationCodeResponse : ServiceBaseWebResponse
    {
        public string PatientName { get; set; }
    }
}
