using System;
using System.Globalization;

namespace PatientPortalBackend.Models
{
    public class ServiceCreatePatientAppointmentRequest : ServiceBaseWebRequest
    {
        //public string HospitalLocationId { get; set; } //SeriesDefinition
        public int SpecialtyId { get; set; } //Speciality
        //public int DoctorId { get; set; } //AbstractBackupSeq
        public string AppointmentDateTimeStr { get; set; }
        public DateTime AppointmentDateTime
        {
            get
            {
                if (DateTime.TryParse(AppointmentDateTimeStr, out var dt))
                    return dt;
                throw new InvalidOperationException("Invalid AppointmentDateTimeStr format.");
            }
        }
        public string Name { get; set; } // Name
        public Guid PatientId { get; set; } // buat cukup syarat
        //public string PtNRIC { get; set; } // AbstractBackupNo
        //public DateTimeOffset? PtDob { get; set; } // PlanningStateDateTime
        //public int CountryCode { get; set; } // AppointmentMode
        //public string PtMobileNum { get; set; } // Npo
        //public int PaymentMethod { get; set; } // PlanningState
        public string AdditionalMsg { get; set; } // AdditionalInfo
        public Guid MedimaxResourceId { get; set; } // ResourceId
        public long MedimaxServiceUnitId { get; set;  } //ServiceUnitId
    }

    public class ServiceCreatePatientAppointmentResponse : ServiceBaseWebResponse
    {
        public Guid PatientId { get; set; }
    }
}