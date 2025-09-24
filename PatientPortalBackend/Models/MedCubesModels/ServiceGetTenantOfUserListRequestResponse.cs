using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
	/// <summary>
	/// Request for the tenantofuser list service, includes the userid for which the list should be retrieved.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetTenantOfUserListRequest : ServiceBaseRequest
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public long CustomerId { get; set; }

        [DataMember]
        public long TenantId { get; set; }
    }

    /// <summary>
    /// Response for the tenantofuserlist service, includes the list of records.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetTenantOfUserListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<TenantOfUser> TenantOfUserList { get; set; }
    }
}