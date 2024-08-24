using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class VitalReadings
    {
        [Key]
        public string UId { get; set; }

        [ForeignKey("Entry")]
        public string? EntryId { get; set; }
        public Types? TypeOfVital { get; set; }
        public string? Value { get; set; }
        public string? Units { get; set; }
        public DateTime? NotedDate { get; set; }
        public string? Comment { get; set; }

    }
}
