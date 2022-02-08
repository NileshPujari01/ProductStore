using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;

namespace ProductStore.Domain.Configurations
{
    public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.ToTable("product_category");
            builder.HasKey(e => e.ProductCategoryId);
            builder.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            builder.Property(e => e.ProductCategoryName).HasColumnName("product_category_name");
        }
    }
}
