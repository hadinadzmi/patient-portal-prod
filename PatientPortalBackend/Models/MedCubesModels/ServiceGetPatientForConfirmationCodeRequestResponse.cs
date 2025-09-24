using System;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public class ServiceGetPatientForConfirmationCodeRequest : ServiceBaseRequest
    {
        [DataMember]
        public string PatIdNum { get; set; }
        [DataMember]
        public string PatMobileNum { get; set; }
        [DataMember]
        public string RequestType { get; set; } // Added this line
    }

    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public class ServiceGetPatientForConfirmationCodeResponse : ServiceBaseResponse
    {
        [DataMember]
        public Patient PatientRecord { get; set; }
    }
}
