using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceGetTenantDetailsRequest : ServiceBaseWebRequest
    {
        // Add any additional properties if needed
    }

    public class ServiceGetTenantDetailsResponse : ServiceBaseWebResponse
    {
        public List<TenantDto> TenantList { get; set; }
    }

    public class TenantDto
    {
        public long TenantId { get; set; }
        public string TenantName { get; set; }
        public long CustomerId { get; set; }
        public long RecordState { get; set; }
    }

}
