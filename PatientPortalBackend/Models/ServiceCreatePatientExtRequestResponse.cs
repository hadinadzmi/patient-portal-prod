using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientPortalBackend.Models.MedCubesModels;

namespace PatientPortalBackend.Models
{
    public class ServiceCreatePatientExtRequest : ServiceBaseWebRequest
    {
        public PatientExt Patient { get; set; }
    }

    public class ServiceCreatePatientExtResponse : ServiceBaseWebResponse
    {
        public Guid PatientIdCreated { get; set; }

        public Guid? ExistingPatientId { get; set; }
    }
}
