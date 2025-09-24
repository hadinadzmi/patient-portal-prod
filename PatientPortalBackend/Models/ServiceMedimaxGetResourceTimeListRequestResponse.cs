using PatientPortalBackend.Models.MedCubesModels;
using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetResourceTimeListRequest : ServiceBaseWebRequest
    {
        public List<Guid> ResourceIdList { get; set; }
    }

    public class ServiceMedimaxGetResourceTimeListResponse : ServiceBaseWebResponse
    {
        public List<ResourceTime> ResourceTimeList { get; set; }
    }
}
