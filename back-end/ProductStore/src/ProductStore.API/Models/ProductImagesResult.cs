namespace ProductStore.API.Models
{
    public class ProductImagesResult
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
