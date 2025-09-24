using PatientPortalBackend.Models.MedCubesModels;
using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetResourceIdListRequest : ServiceBaseWebRequest
    {
        public long? TenantId { get; set; }
    }


    public class ServiceMedimaxGetResourceIdListResponse : ServiceBaseWebResponse
    {
        public List<Resource> ResourceDetails { get; set; }
    }
}
