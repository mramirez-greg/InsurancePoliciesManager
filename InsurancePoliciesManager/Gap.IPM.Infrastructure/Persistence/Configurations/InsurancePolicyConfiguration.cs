using Gap.IPM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gap.IPM.Infrastructure.Persistence.Configurations
{
    public class InsurancePolicyConfiguration : IEntityTypeConfiguration<InsurancePolicy>
    {
        public void Configure(EntityTypeBuilder<InsurancePolicy> builder)
        {
            builder.Property(e => e.Name)
               .HasMaxLength(50);
            builder.Property(e => e.Description)
               .HasMaxLength(200);

        }
    }
}
