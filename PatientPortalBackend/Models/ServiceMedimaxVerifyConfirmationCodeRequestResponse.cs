using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxVerifyConfirmationCodeRequest : ServiceBaseWebRequest
    {
        public string PatientId { get; set; } // nric number
        public string ConfirmationCode { get; set; } // OTP code
        public string RequestType { get; set; } // RequestAppointment/ResetPassword/FirstTimeLogin?
        public string NewPassword { get; set; } // New password if RequestType is ResetPassword/FirstTimeLogin
    }


    public class ServiceMedimaxVerifyConfirmationCodeResponse : ServiceBaseWebResponse
    {
    }
}
