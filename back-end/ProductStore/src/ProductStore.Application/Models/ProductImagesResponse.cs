namespace ProductStore.Application.Models
{
    public class ProductImagesResponse
    {
        public IEnumerable<ProductImagesResponseItems> ProductImages { get; set; }
    }

    public class ProductImagesResponseItems
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string? ProductImageName { get; set; }
    }
}
