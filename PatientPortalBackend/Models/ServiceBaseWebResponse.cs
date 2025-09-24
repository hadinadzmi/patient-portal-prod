using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class ServiceBaseWebResponse
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
