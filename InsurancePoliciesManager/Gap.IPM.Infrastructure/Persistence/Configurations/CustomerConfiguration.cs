using Gap.IPM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gap.IPM.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.CustomerId)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(e => e.FirstName)
              .HasMaxLength(200);
            builder.Property(e => e.LastName)
              .HasMaxLength(200);
            builder.Property(e => e.Address)
              .HasMaxLength(500);
            builder.Property(e => e.Phone)
              .HasMaxLength(20);
            builder.Property(e => e.City)
              .HasMaxLength(50);
            builder.Property(e => e.Region)
              .HasMaxLength(50);
            builder.Property(e => e.Country)
              .HasMaxLength(100);
            builder.Property(e => e.PostalCode)
              .HasMaxLength(10);


        }
    }
}
