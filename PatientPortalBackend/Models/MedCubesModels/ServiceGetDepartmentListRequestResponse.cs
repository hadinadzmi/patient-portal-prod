using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Request-property for getting departments to a customer and a tenant.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetDepartmentListRequest : ServiceBaseRequest
    {

        // insert properties here
        [DataMember]
        public Department Department { get; set; }

        [DataMember]
        public List<long> DepartmentPkList { get; set; }

        [DataMember]
        public bool ShowActiveDepartment { get; set; }

        [DataMember]
        public bool ShowInactiveDepartment { get; set; }

        [DataMember]
        public bool ShowDeletedDepartment { get; set; }


	    public ServiceGetDepartmentListRequest()
	    {
	        ShowActiveDepartment = true;
	        ShowInactiveDepartment = true;
	    }

    }

    /// <summary>
    /// Response-property: List of all departments to a customer and a tenant.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public class ServiceGetDepartmentListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<Department> DepartmentList { get; set; }
    }
}
