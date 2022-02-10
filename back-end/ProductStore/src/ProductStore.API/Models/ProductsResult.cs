namespace ProductStore.API.Models
{
    public class ProductsResult
    {
        public IEnumerable<ProductsResponseItems> Products { get; set; }
    }

    public class ProductsResponseItems
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}