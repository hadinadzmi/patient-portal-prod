using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class CaseComm
    {
        public long PkId { get; set; }
        public long? ParentPkId { get; set; }
        public long CaseDataUniqueId { get; set; }
        public int? Topic { get; set; }
        public DateTimeOffset DateTimeSent { get; set; }
        public bool IsColored { get; set; }
        public string Text { get; set; }
        public string SendingUserFullName { get; set; }
        public long SendingUserId { get; set; }
    }
}