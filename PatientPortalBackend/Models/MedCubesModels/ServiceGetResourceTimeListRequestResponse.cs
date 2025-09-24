using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service GetResourceTimeList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    public partial class ServiceGetResourceTimeListRequest : ServiceBaseRequest
    {
        [DataMember]
        public ResourceTime ResourceTimeRecord { get; set; }

        [DataMember]
        public List<Guid> ResourceIdList { get; set; }

        [DataMember]
        public List<int> ResourceTimeTypeList { get; set; }

        [DataMember]
        public DateTimeOffset? DateTimeFrom { get; set; }

        [DataMember]
        public DateTimeOffset? DateTimeTo { get; set; }

        [DataMember]
        public long ServiceUnitId { get; set; }
    }   


	/// <summary>
	/// Responseclass for the service GetResourceTimeList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    public partial class ServiceGetResourceTimeListResponse : ServiceBaseResponse
    {        
        [DataMember]
        public List<ResourceTime> ResourceTimeList { get; set; }
    }   
}
