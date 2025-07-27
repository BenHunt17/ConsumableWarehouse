using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsumableWarehouse.DataPersistence.Configuration
{
    internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasIndex(x => x.CompanyName).IsUnique();

            builder.Property(x => x.CompanyName).HasMaxLength(99);

            builder.Property(x => x.ContactEmailAddress).HasMaxLength(99);

            builder.Property(x => x.ContactPhoneNumber).HasMaxLength(20);
        }
    }
}
