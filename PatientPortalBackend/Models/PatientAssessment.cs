using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortalBackend.Models
{
    public class PatientAssessment
    {
        //DB properties
        public long PkId { get; set; }
        public Guid AssessmentId { get; set; }
        public int CalculatedTriageScore { get; set; }
        public int? TriageScore { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset? AssessmentTimeStarted { get; set; }
        public DateTimeOffset? AssessmentTimeSent { get; set; }
        public DateTimeOffset? AssessmentTimeAnswered { get; set; }
        public DateTimeOffset? AssessmentTimeClosed { get; set; }
        public int? AssessmentState { get; set; }
        public DateTimeOffset? AssessmentTimeClosedByDoc { get; set; }
        public Guid PatientId { get; set; }
        public Guid UnitId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
        public string Culture { get; set; }
        public decimal? TimeOffset { get; set; }
        public int? Accuracy { get; set; }

        //Extension Properties
        //public string UnitName { get; set; }
        public string AssessmentStateText { get; set; }
    }
}