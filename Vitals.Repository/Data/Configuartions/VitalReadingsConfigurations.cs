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
    internal class VitalReadingsConfigurations : IEntityTypeConfiguration<VitalReadings>
    {
        public void Configure(EntityTypeBuilder<VitalReadings> builder)
        {
            builder.Property(v => v.TypeOfVital).HasConversion(v => v.ToString(), v => (Types)Enum.Parse(typeof(Types), v));

        }
    }
}
