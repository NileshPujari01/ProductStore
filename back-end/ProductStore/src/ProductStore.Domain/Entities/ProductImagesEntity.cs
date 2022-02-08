namespace ProductStore.Domain.Entities
{
    public class ProductImagesEntity
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string? ProductImageName { get; set; }
    }
}
