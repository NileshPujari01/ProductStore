using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Configurations;
using ProductStore.Domain.Entities;

namespace ProductStore.Infrastructure.Persistence
{
    public class ProductStoreDataContext : DbContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        public ProductStoreDataContext(
            DbContextOptions<ProductStoreDataContext> options, 
            IConnectionStringProvider connectionStringProvider) : base(options)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<ProductCategoryEntity> ProductCategory { get; set; }
        public DbSet<ProductImagesEntity> ProductImages { get; set; }
        public DbSet<ProductsEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionStringProvider.GetConnectionString());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImagesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsEntityConfiguration());
        }
    }
}
