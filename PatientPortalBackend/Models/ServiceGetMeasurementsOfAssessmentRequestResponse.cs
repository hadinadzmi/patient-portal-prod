using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class ServiceGetMeasurementsOfAssessmentRequest : ServiceBaseWebRequest
    {
        public Guid AssessmentId { get; set; }
        public Guid? MeasurementTypeId { get; set; }
    }

    public class ServiceGetMeasurementsOfAssessmentResponse : ServiceBaseWebResponse
    {
        public List<PatientMeasurement> MeasurementList { get; set; }
    }
}