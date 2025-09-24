using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
	/// <summary>
	/// Request for the tenantlist request, contains the customer id to filter the tenants.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    [KnownType(typeof(ServiceGetTenantListRequest))]
    public class ServiceGetTenantListRequest : ServiceBaseRequest
    {
        [DataMember]
        public long CustomerId { get; set; }

        [DataMember]
        public bool ShowActiveTenant { get; set; }

        [DataMember]
        public bool ShowInactiveTenant { get; set; }

        [DataMember]
        public bool ShowDeletedTenant { get; set; }

        [DataMember]
        public long TenantId { get; set; }

        [DataMember]
        public bool LoadImages { get; set; }


	    public ServiceGetTenantListRequest()
	    {
	        ShowActiveTenant = true;
	        ShowInactiveTenant = true;
	    }
    }

    /// <summary>
    /// Response for the gettenantlist service, contains a list of tenant dbos.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    [KnownType(typeof(ServiceGetTenantListResponse))]
    public class ServiceGetTenantListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<Tenant> TenantList { get; set; }
    } 
}
