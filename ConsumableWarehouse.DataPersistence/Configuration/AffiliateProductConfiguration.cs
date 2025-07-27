using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsumableWarehouse.DataPersistence.Configuration
{
    internal class AffiliateProductConfiguration : IEntityTypeConfiguration<AffiliateProduct>
    {
        public void Configure(EntityTypeBuilder<AffiliateProduct> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(99);

            builder.Property(x => x.AffiliateLink).HasMaxLength(999);
        }
    }
}
