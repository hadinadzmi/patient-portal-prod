using PatientPortalBackend.Models.MedCubesModels.Core;
using System.Runtime.Serialization;

namespace PatientPortalBackend.Models.MedCubesModels
{
    public partial class ServiceGetMaxLoginDetailsRequest : ServiceBaseRequest
    {
        [DataMember]
        public string IdNumber { get; set; }



        [DataMember]
        public string Password { get; set; }
    }


    /// <summary>
    /// Responseclass for the service GetPatientForPatientPortal.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.PatientManagement.Server.RequestResponse.Patient")]
    public partial class ServiceGetMaxLoginDetailsResponse : ServiceBaseResponse
    {
        [DataMember]
        public Patient PatientRecord { get; set; }
    }
}
