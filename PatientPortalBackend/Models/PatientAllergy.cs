using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class PatientAllergy
    {
        //public long PatientAllergyPkId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AdditionalText { get; set; }
        public string Description { get; set; }
        public int? AllergyState { get; set; }

        public PatientAllergy() { }

        public PatientAllergy(string code, string name, string additionalText, string description, int? allergyState)
        {
            Code = code;
            Name = name;
            AdditionalText = additionalText;
            Description = description;
            AllergyState = allergyState;
        }
    }
}
