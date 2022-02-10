namespace ProductStore.Application.Models
{
    public class ProductsResponse
    {
        public IEnumerable<ProductsResponseItems> Products { get; set; }
    }

    public class ProductsResponseItems
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
    }
}
