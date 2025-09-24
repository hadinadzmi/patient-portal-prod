using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class PatientMeasurement
    {
        public Guid MeasurementId { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? MeasurementType { get; set; }
        public Guid AssessmentId { get; set; }
        
        //Extensions
        public string MeasurementTypeName { get; set; }
        public List<MeasurementValue> Values { get; set; }
        public int TriageScore { get; set; }
    }

    public class MeasurementValue
    {
        public long PkId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Value { get; set; }
        public Guid? MediaId { get; set; } //If not null -> Image/Thumbail is filled, 
        public Guid MeasurementId { get; set; }
        public Guid ParameterId { get; set; }

        //Extensions
        public byte[] Image { get; set; }
        public byte[] Thumbnail { get; set; }
        public string ParameterText { get; set; }
    }
}