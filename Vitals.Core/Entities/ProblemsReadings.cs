using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class ProblemsReadings
    {
        [Key]
        public string UId { get; set; }

        [ForeignKey("Entry")]
        public string? EntryId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? ProCode { get; set; }
        public string? ICD10 { get; set; }
        public string? NotedDate { get; set; }
        public string? Comment { get; set; }
    }
}
