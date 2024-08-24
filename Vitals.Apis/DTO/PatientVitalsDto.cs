using Vitals.Core.Entities;

namespace Vitals.Apis.DTO
{
    public class PatientVitalsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string VitalTypes { get; set; }
        public string VitalValues { get; set; }
        public DateTime VitalDate { get; set; }
    }
}
