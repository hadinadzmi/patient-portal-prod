using PatientPortalBackend.Models.MedCubesModels.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service GetPatientById.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public partial class ServiceGetPatientByIdRequest : ServiceBaseRequest
    {
        /// <summary>
        /// Primary id of the patient to be retrieved.
        /// </summary>
        [DataMember]
        public Guid PatientId { get; set; }
    }


    /// <summary>
    /// Responseclass for the service GetPatientById.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public partial class ServiceGetPatientByIdResponse : ServiceBaseResponse
    {
        /// <summary>
        /// A list containing the available patient data when a full model is requested.
        /// </summary>
        [DataMember]
        public List<Patient> PatientList { get; set; }
    }
}
