using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsumableWarehouse.DataPersistence.Configuration
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasIndex(x => x.UserIdentityId).IsUnique();

            builder.Property(x => x.UserIdentityId).HasMaxLength(99);

            builder.Property(x => x.FirstName).HasMaxLength(99);

            builder.Property(x => x.LastName).HasMaxLength(99);

            builder.Property(x => x.Email).HasMaxLength(99);
        }
    }
}
