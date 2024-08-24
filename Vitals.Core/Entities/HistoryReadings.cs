using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class HistoryReadings
    {
        [Key]
        public string UId { get; set; }

        [ForeignKey("Entry")]
        public string? EntryId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Relation { get; set; }
        public string? Age { get; set; }
        public string? Status { get; set; }
        public string? NotedDate { get; set; }
        public string? Comment { get; set; }
    }
}
