namespace ProductStore.Application.Models.Request
{
    public class ProductRequest
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
    }
}
