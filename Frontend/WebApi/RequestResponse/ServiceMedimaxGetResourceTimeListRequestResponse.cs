using Patient_Portal.WebApi.Models;
using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetResourceTimeListRequest : ServiceBaseWebRequest
    {
        public Guid[] ResourceIdList { get; set; }
    }

    public class ServiceMedimaxGetResourceTimeListResponse : ServiceBaseWebResponse
    {
        public List<ResourceTime> ResourceTimeList { get; set; }

        public class ResourceTime
        {
            public Guid ResourceTimeId { get; set; }
            public Guid ResourceId { get; set; } // Dr punya Id
            public int Type { get; set; } // 0 = Open, 1 = Close
            public int? Weekday { get; set; } // 1 = Monday, 2 = Tuesday, 3 = Wednesday, 4 = Thursday, 5 = Friday, 6 = Saturday, 7 = Sunday
            public DateTimeOffset TimeFrom { get; set; }
            public DateTimeOffset TimeUntil { get; set; }
            public long TenantId { get; set; }
        }
    }
}