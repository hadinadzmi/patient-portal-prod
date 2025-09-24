using System;
using System.Collections.Generic;

namespace PatientPortalBackend.Models
{
    public class ServiceMedimaxDownloadPatientDocumentRequest : ServiceBaseWebRequest
    {
        public long DocumentId { get; set; }
        public int? Version { get; set; }
        public Guid? DocumentKey { get; set; }
        public bool IsDocumentInfoRecordAttached { get; set; } = true;
        public byte[] DocumentPassword { get; set; }
    }

    public class ServiceMedimaxDownloadPatientDocumentResponse : ServiceBaseWebResponse
    {
        public byte[] DocumentContent { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
    }
}
