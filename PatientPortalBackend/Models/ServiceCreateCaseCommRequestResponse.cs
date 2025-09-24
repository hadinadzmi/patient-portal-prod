using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class ServiceCreateCaseCommRequest : ServiceBaseWebRequest
    {
        public CaseComm CaseCommRecord { get; set; }
    }

    public class ServiceCreateCaseCommResponse: ServiceBaseWebResponse
    {
    }
}