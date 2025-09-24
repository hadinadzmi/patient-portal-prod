using System;

namespace PatientPortalBackend.Models
{
    public class PatientAppointment
    {
        public string PkID { get; set; } // Unique identifier for the appointment
        public Guid PatientCalendarEntryID { get; set; } // Unique identifier for the appointment
        public DateTimeOffset StartDateTime { get; set; } // Start date and time of the appointment
        public DateTimeOffset? EndDateTime { get; set; } // End date and time of the appointment (optional)
        public string Name { get; set; } // Name of the appointment
        public string AdditionalInfo { get; set; } // Additional information (optional)
        public int Speciality { get; set; } // Speciality or department (optional)
        public int? PlanningState { get; set; } // Planning state of the appointment
        public string CancelReason { get; set; } // Reason for cancellation (optional)
        public string RecordState { get; set; } // Record state of the appointment
        public long? ServiceUnitId { get; set; }
    }
}
