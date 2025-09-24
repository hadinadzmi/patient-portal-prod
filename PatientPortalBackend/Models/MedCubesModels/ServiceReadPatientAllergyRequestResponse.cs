using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    [KnownType(typeof(Models.PatientAllergy))]
    public partial class ServiceReadPatientAllergyRequest : ServiceBaseRequest
    {
        [DataMember]
        public Guid PatientId { get; set; }

        [DataMember]
        public bool GetPivot { get; set; }
    }

    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    [KnownType(typeof(Models.PatientAllergy))]
    public partial class ServiceReadPatientAllergyResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<MedCubesModels.PatientAllergy> PatientAllergyRecordList { get; set; }
    }
}
