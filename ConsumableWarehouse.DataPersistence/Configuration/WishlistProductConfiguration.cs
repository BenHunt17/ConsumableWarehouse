using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsumableWarehouse.DataPersistence.Configuration
{
    internal class WishlistProductConfiguration : IEntityTypeConfiguration<WishlistProduct>
    {
        public void Configure(EntityTypeBuilder<WishlistProduct> builder)
        {
            builder.Property(x => x.Comment).HasMaxLength(999);
        }
    }
}
