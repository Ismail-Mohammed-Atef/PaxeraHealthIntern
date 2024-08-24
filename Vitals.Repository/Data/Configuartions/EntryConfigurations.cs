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
    internal class EntryConfigurations : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.Property(s => s.SectionType).HasConversion(s => s.ToString(), s => (Sections)Enum.Parse(typeof(Sections), s));

        }
    }
}
