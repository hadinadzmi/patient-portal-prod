using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceGetPatientDocumentRequest : ServiceBaseWebRequest
    {
        public Guid PatNRIC { get; set; }
	}

    public class ServiceGetPatientDocumentResponse : ServiceBaseWebResponse
    {
        public List<PatientDocument> DocumentList { get; set; }
	}
}