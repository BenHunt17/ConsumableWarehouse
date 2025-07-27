using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsumableWarehouse.DataPersistence.Configuration
{
    internal class FreeTextProductConfiguration : IEntityTypeConfiguration<FreeTextProduct>
    {
        public void Configure(EntityTypeBuilder<FreeTextProduct> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(99);
        }
    }
}
