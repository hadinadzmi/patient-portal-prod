using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxGetPatientDocumentsRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
    }

    public class ServiceMedimaxGetPatientDocumentsResponse : ServiceBaseWebResponse
    {
        public List<PatientDocument> DocumentList { get; set; } 
    }
}
