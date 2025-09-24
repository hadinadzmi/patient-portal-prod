using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceRequestDocumentRequest : ServiceBaseWebRequest
    {
        public Guid PatNRIC { get; set; } // Identifies the patient for whom the documents are being requested
        public string DocumentId { get; set; } // Unique ID for each document options
        public string DocumentType { get; set; } // Specifies the type of document being requested (e.g., Discharge Summary = 1)
    }
    public class ServiceRequestDocumentResponse : ServiceBaseWebResponse
    {
        public string Link { get; set; } // URL to the document (iFrame)
        public bool IsLinkAvailable { get; set; } // If the document is available for viewing, this will be true
    }
}
