using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceGetConfirmationCodeRequest : ServiceBaseWebRequest
    {
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirthStr { get; set; }

        public DateTime DateOfBirth
        {
            get
            {
                DateTime dt;
                if(DateTime.TryParseExact(DateOfBirthStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                //if (DateTime.TryParse(DateOfBirthStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    return dt;
                }
                return DateTime.MinValue;
            }
        }
    }

    public class ServiceGetConfirmationCodeResponse : ServiceBaseWebResponse
    {
        public Guid PatientId { get; set; }
    }
}
