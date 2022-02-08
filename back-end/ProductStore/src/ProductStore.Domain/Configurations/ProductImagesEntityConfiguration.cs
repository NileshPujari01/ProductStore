using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;

namespace ProductStore.Domain.Configurations
{
    public class ProductImagesEntityConfiguration : IEntityTypeConfiguration<ProductImagesEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImagesEntity> builder)
        {
            builder.ToTable("product_images");
            builder.HasKey(e => e.ProductImageId);
            builder.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            builder.Property(e => e.ProductId).HasColumnName("product_id");
            builder.Property(e => e.ProductImageName).HasColumnName("image_name");
        }
    }
}
