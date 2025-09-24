using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PatientPortalBackend.Models.MedCubesModels.Core;

namespace PatientPortalBackend.Models.MedCubesModels
{
     [DataContract(Name = "MailContainer", Namespace = "MedCubes.Framework.Models")]
    public class MailContainer : DomainBaseModel 
    {
         // No Silverlight specific handling (e.g. onpropertychanged) because shall only be send inside a program (no gui)
         [DataMember]
         public string From { get; set; }

         [DataMember]
         public List<String> To { get; set; }

         [DataMember]
         public List<String> Cc { get; set; }

         [DataMember]
         public List<String> Bcc { get; set; }

         [DataMember]
         public Dictionary<string, byte[]> Attachments { get; set; }

         [DataMember]
         public string Subject { get; set; }

         [DataMember]
         public string Body { get; set; }

         #region Overrides of DomainBaseModel

         public override string GetHistoryKey()
         {
             return String.Empty;
         }

         #endregion
    }
}
