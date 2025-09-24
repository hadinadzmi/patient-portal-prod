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
        public List<ResourceDetailDto> ResourceDetails { get; set; }
    }

    public class ResourceDetailDto
    {
        public Guid ResourceId { get; set; }
        public long ServiceUnitId { get; set; }
        public long? MainDataId { get; set; }
        public long? RecordState { get; set; }
        public string Name { get; set; }
    }
}
