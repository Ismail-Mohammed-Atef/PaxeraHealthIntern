using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class AllergiesReadings
    {
        [Key]
        public string UId { get; set; }

        [ForeignKey("Entry")]
        public string? EntryId { get; set; }
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public string? Stat { get; set; }
        public string? Reaction { get; set; }
        public string? Severity { get; set; }
        public string? NotedDate { get; set; }
        public string? Comment { get; set; }

    }
}
