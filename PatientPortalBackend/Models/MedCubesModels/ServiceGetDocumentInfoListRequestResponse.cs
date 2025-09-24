using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Requestclass for the service GetDocumentInfoList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceGetDocumentInfoListRequest : ServiceBaseRequest
    {
        /// <summary>
        /// Either this property or the property 'PrimaryParentKey' must be set.
        /// </summary>
        [DataMember]
        public List<string> PrimaryParentKeyList { get; set; }

        [DataMember]
        public string PrimaryParentKey { get; set; }

        [DataMember]
        public string SecondaryParentKey { get; set; }

        [DataMember]
        public int? Status { get; set; }

        [DataMember]
        public List<int> StatusList { get; set; }

        [DataMember]
        public string MimeType { get; set; }

        [DataMember]
        public string AdditionalDocRelation { get; set; }

        [DataMember]
        public string FulltextSearchExpression { get; set; }

        [DataMember]
        public List<long> FilterForDocumentInfoIds { get; set; }

        [DataMember]
        public bool IncludeDeletedDocuments { get; set; }

        [DataMember]
        public List<int> DocumentTypeIdList { get; set; }

        [DataMember]
        public bool SkipFinalized { get; set; }
 
        [DataMember]
        public bool SkipUnfinalized { get; set; }

        [DataMember]
        public bool CheckApprovedByAnotherUser { get; set; }

        //[DataMember]
        //public Models.DocumentInfo DocumentInfoRecord { get; set; }
    }

    /// <summary>
    /// Responseclass for the service GetDocumentInfoList.
    /// </summary>
    [DataContract(Namespace = "http://MedCubes.DocumentSystem.Server.RequestResponse.DocumentInfo")]
    public partial class ServiceGetDocumentInfoListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<DocumentInfoWrapper> DocumentInfoWrapperList { get; set; }
    }  
}
