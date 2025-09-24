using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class ServiceCreateWfMessageRequest : ServiceBaseWebRequest
    {
        public long TopicPkId { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
        public Guid PatientId { get; set; }
        public long SendingServiceUnitId { get; set; }
        public long SendingUserId { get; set; }
    }

    public class ServiceCreateWfMessageResponse : ServiceBaseWebResponse
    {

    }
}