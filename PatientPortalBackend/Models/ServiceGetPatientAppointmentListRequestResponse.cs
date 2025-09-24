using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceGetPatientAppointmentListRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
    }

    public class ServiceGetPatientAppointmentListResponse : ServiceBaseWebResponse
    {
        public List<PatientAppointment> AppointmentList { get; set; }
    }
}
