using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Request-property for getting service units to a department.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetServiceUnitListRequest : ServiceBaseRequest
    {
        [DataMember]
        public ServiceUnit ServiceUnit { get; set; }

        [DataMember]
        public bool LoadActiveRecords { get; set; }

	    [DataMember]
	    public bool LoadInactiveRecords { get; set; }

        [DataMember]
        public bool LoadDeletedRecords { get; set; }

        [DataMember]
        public List<long> ServiceUnitIdList { get; set; }

        [DataMember]
        public List<long> DepartmentIdList { get; set; }

	    public ServiceGetServiceUnitListRequest()
	    {
	        LoadActiveRecords = true;
	        LoadInactiveRecords = true;
	    }

    }

    /// <summary>
    /// Response-property: getting service units to a department (small-object).
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetServiceUnitListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<ServiceUnit> ServiceUnitList { get; set; }
    } 
}
