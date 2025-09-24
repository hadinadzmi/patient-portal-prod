using System;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
	/// <summary>
	/// Requestclass for the service GetPatientForPatientPortal.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public partial class ServiceGetPatientForPatientPortalRequest : ServiceBaseRequest
    {
        [DataMember]
        public string IdNumber { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string Email { get; set; }
    }   


	/// <summary>
	/// Responseclass for the service GetPatientForPatientPortal.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]	
    public partial class ServiceGetPatientForPatientPortalResponse : ServiceBaseResponse
    {
        [DataMember]
        public Patient PatientRecord { get; set; }
    }   
}
