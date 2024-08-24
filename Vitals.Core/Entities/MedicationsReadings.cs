using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class Medications_Readings
    {
        [Key]
        public string UId { get; set; }

        [ForeignKey("Entry")]
        public string EntryId { get; set; }
        public string? Name { get; set; }
        public string? Directions { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Status { get; set; }
        public string? Quantity { get; set; }
        public string? MedCode { get; set; }
        public string? NotedDate { get; set; }
        public string? Comment { get; set; }

    }
}
