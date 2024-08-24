using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitals.Core.Entities;

namespace Vitals.Repository.Data.Configuartions
{
    internal class PatientVitalsConfigurations : IEntityTypeConfiguration<PatientVitals>
    {
        public void Configure(EntityTypeBuilder<PatientVitals> builder)
        {
            builder.Property(p => p.VitalTypes).HasConversion(ptypes => ptypes.ToString(), ptypes => (Types)Enum.Parse(typeof(Types), ptypes));
            builder.Property(p => p.UserId).IsRequired();

        }
    }
}
