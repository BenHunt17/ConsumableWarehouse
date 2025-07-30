using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application
{
    public interface IDataContext
    {
        public DbSet<Wishlist> Wishlists { get; }

        public DbSet<AffiliateProduct> AffiliateProducts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public void Commit();
    }
}
