using Gap.IPM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gap.IPM.Infrastructure.Persistence.Configurations
{
    public class CustomerInsurancePolicyConfiguration : IEntityTypeConfiguration<CustomerInsurancePolicy>
    {
        public void Configure(EntityTypeBuilder<CustomerInsurancePolicy> builder)
        {
            builder.Property(t => t.CustomerId)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.InsurancePolicyId)
               .IsRequired();
            
        }
    }
}
