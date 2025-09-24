using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MedCubes.Appointment.Server;
using MedCubes.Appointment.Server.Models.MedCubesModels;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
    /// <summary>
    /// Request for the popup list retrieval.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public partial class ServiceGetPopupEntryListRequest : ServiceBaseRequest
    {
        [DataMember]
        public string PopupKey { get; set; }

        //[DataMember]
        //public List<string> PopupKeyList { get; set; }

        //[DataMember]
        //public Guid PopupHeaderId { get; set; }

        //[DataMember]
        //public Nullable<long> PopupEntryCode { get; set; }

        //[DataMember]
        //public bool IgnorePopupHeader { get; set; }
    }

    /// <summary>
    /// Response for the popuplist retrieval.
    /// </summary>
    [DataContract(Namespace = "www.Ahcs.co/MedCubes/Wcf")]
    public partial class ServiceGetPopupEntryListResponse : ServiceBaseResponse
    {
        [DataMember]
        public List<PopupEntry> PopupEntryList { get; set; }
    }
}
