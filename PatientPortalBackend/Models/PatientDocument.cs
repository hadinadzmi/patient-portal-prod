using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortalBackend.Models
{
    public class PatientDocument
    {
        public long DocumentId { get; set; }
        public long DocumentType { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string DateTimeCreatedStr { get; set; }
        public Guid DocumentKey { get; set; }
        public int? Version { get; set; }
        public bool IsFinalized { get; set; }
    }
}
