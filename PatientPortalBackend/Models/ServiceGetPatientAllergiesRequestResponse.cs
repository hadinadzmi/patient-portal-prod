using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class ServiceGetPatientAllergiesRequest : ServiceBaseWebRequest
    {
        public Guid PatientId { get; set; }
    }

    public class ServiceGetPatientAllergiesResponse : ServiceBaseWebResponse
    {
        public List<PatientAllergy> AllergyList { get; set; } 
    }
}
