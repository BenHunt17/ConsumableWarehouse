using ConsumableWarehouse.Application;
using ConsumableWarehouse.DataPersistence.Configuration;
using ConsumableWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsumableWarehouse.DataPersistence
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<AffiliateProduct> AffiliateProducts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public void Commit()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConsumableWarehouseDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WishlistConfiguration());

            modelBuilder.ApplyConfiguration(new WishlistProductConfiguration());

            modelBuilder.ApplyConfiguration(new FreeTextProductConfiguration());

            modelBuilder.ApplyConfiguration(new AffiliateProductConfiguration());

            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new PartnerConfiguration());
        }
    }
}
