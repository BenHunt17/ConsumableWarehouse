using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsumableWarehouse.Application
{
    public interface IDataContext
    {
        public DbSet<Wishlist> Wishlists { get; }

        public DbSet<AffiliateProduct> AffiliateProducts { get; }

        public DbSet<ProductCategory> ProductCategories { get; }

        public DbSet<Partner> Partners { get; }

        public void Commit();
    }
}
