using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class MedicalDocuments
    {
        public int Id { get; set; }

        [ForeignKey("Entry")]
        public string? EntryId { get; set; }
        public string? filePath { get; set; }
        public string? FileType { get; set; }
        public string? Ofn { get; set; }
    }
}
