using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service GetResourceList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    [KnownType(typeof(Resource))]
    public partial class ServiceGetResourceListRequest : ServiceBaseRequest
    {
        [DataMember]
        public Resource ResourceRecord { get; set; }

        [DataMember]
        public List<long> ServiceUnitIdList { get; set; }

        [DataMember]
        public List<Guid> ResourceList { get; set; } 

        [DataMember]
        public bool FillAdditionalUserKey { get; set; }
    }   


	/// <summary>
	/// Responseclass for the service GetResourceList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.Appointment.Server.RequestResponse.Scheduler")]
    [KnownType(typeof(Resource))]
    public partial class ServiceGetResourceListResponse : ServiceBaseResponse
    {        
        [DataMember]
        public List<Resource> ResourceList { get; set; }
    }   
}
