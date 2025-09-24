using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceGetPatientDocumentsRequest : ServiceBaseRequest
    {
        [DataMember]
        public Guid PatientId { get; set; }
    }

    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceGetPatientDocumentsResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<DocumentInfo> DocumentInfoList { get; set; }
    }
}
