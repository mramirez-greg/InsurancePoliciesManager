using Gap.IPM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gap.IPM.Infrastructure.Persistence.Configurations
{
    public class CoverageTypeConfiguration : IEntityTypeConfiguration<CoverageType>
    {
        public void Configure(EntityTypeBuilder<CoverageType> builder)
        {
            builder.Property(t => t.CoverageTypeName)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
