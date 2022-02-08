using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Configurations;
using ProductStore.Domain.Entities;

namespace ProductStore.Infrastructure.Persistence
{
    public class ProductStoreDataContext : DbContext
    {
        public ProductStoreDataContext(DbContextOptions<ProductStoreDataContext> options) : base(options)
        {

        }

        public DbSet<ProductCategoryEntity> ProductCategory { get; set; }
        public DbSet<ProductImagesEntity> ProductImages { get; set; }
        public DbSet<ProductsEntity> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImagesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsEntityConfiguration());
        }
    }
}
