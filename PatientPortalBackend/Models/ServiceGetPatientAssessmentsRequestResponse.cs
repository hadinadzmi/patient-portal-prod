using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceGetPatientAssessmentsRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
        public List<int> AssessmentStates { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }

    public class ServiceGetPatientAssessmentsResponse : ServiceBaseWebResponse
    {
        public List<PatientAssessment> AssessmentList { get; set; } 
    }
}
