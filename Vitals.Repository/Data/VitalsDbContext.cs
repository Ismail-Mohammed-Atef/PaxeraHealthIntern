using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vitals.Core.Entities;

namespace Vitals.Repository.Data
{
    public class VitalsDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-O0QCD23\\SQLDEVELOPER ; Database = PatientVitals ; Trusted_Connection=True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Entry> Entry { get; set; }
        public DbSet<VitalReadings> VitalReadings { get; set; }
        public DbSet<LabReadings> LabReadings { get; set; }
        public DbSet<Medications_Readings> Medications_Readings { get; set; }
        public DbSet<PrescriptsReadings> PrescriptsReadings { get; set; }
        public DbSet<AllergiesReadings> AllergiesReadings { get; set; }
        public DbSet<HistoryReadings> HistoryReadings { get; set; }
        public DbSet<ProblemsReadings> ProblemsReadings { get; set; }
        public DbSet<MedicalDocuments> MedicalDocuments { get; set; }
        public DbSet<PatientVitals> PatientVitals { get; set; }


    }
}
