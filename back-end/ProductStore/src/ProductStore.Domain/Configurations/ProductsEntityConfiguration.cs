using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;

namespace ProductStore.Domain.Configurations
{
    public class ProductsEntityConfiguration : IEntityTypeConfiguration<ProductsEntity>
    {
        public void Configure(EntityTypeBuilder<ProductsEntity> builder)
        {
            builder.ToTable("products");
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductId).HasColumnName("product_id");
            builder.Property(e => e.ProductName).HasColumnName("product_name");
            builder.Property(e => e.ProductCategory).HasColumnName("product_category");
            builder.Property(e => e.ProductPrice).HasColumnName("product_price");
            builder.Property(e => e.ProductRating).HasColumnName("product_rating");
        }
    }
}