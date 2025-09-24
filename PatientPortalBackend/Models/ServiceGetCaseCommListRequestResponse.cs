using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class ServiceGetCaseCommListRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
        public List<int> TopicList { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class ServiceGetCaseCommListResponse : ServiceBaseWebResponse
    {
        public List<CaseComm> CaseCommList { get; set; }
        public long LatestCaseDataUniqueId { get; set; }
    }
}