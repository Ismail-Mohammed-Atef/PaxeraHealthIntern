using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitals.Core.Entities
{
    public class Entry
    {
        [Key]
        public string UId { get; set; }
        public string? Userid { get; set; }
        public Sections SectionType { get; set; }
        public string? SectionName { get; set; }
        public string? Description { get; set; }
        public string? Organization { get; set; }
        public string? Type { get; set; }
        public string? PathOfFile { get; set; }
        public DateTime? UploadedDate { get; set; }
        public string? source { get; set; }
        public List<VitalReadings> VitalReadings { get; set;}
        public List<AllergiesReadings> AllergiesReadings { get; set;}
        public List<Medications_Readings> Medications_Readings { get; set;}
        public List<HistoryReadings> HistoryReadings { get; set;}
        public List<LabReadings> LabReadings { get; set;}
        public List<ProblemsReadings> ProblemsReadings { get; set;}
        public List<PrescriptsReadings> PrescriptsReadings { get; set; }
        public List<MedicalDocuments> MedicalDocuments { get; set; }

    }
}
