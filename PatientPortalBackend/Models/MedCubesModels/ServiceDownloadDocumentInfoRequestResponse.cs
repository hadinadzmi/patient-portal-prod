using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service DownloadDocumentInfo.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceDownloadDocumentInfoRequest : ServiceBaseRequest
    {
        [DataMember]
        public long DocumentId { get; set; }

        [DataMember]
        public byte[] DocumentPassword { get; set; }

        [DataMember]
        public bool IsDocumentInfoRecordAttached { get; set; }

        [DataMember]
        public bool DownloadDeletedRecord { get; set; }

        [DataMember]
        public Nullable<int> Version { get; set; }

    }

    /// <summary>
    /// Responseclass for the service DownloadDocumentInfo.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceDownloadDocumentInfoResponse : ServiceBaseResponse
    {
        [DataMember]
        public byte[] DocumentRecord { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public DocumentInfo DocumentInfoRecord { get; set; }
    }   
}
