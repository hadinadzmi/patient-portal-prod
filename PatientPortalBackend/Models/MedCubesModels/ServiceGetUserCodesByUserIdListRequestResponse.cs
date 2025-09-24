using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
        [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
        public class ServiceGetUserCodesByUserIdListRequest : ServiceBaseRequest
        {
            [DataMember]
            public List<long> UserIdList { get; set; }

            [DataMember]
            public long CustomerId { get; set; }

            [DataMember]
            public long TenantId { get; set; }
        }

    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetUserCodesByUserIdListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<UserCodeDto> UserCodeDtoList { get; set; }
    }

    
}
