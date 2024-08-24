using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class PatientVitals
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Types VitalTypes { get; set; }
        public string VitalValues { get; set; }
        public DateTime VitalDate { get; set; }

    }
}
