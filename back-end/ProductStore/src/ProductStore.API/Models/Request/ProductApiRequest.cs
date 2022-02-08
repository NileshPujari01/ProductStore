namespace ProductStore.API.Models.Request
{
    public class ProductApiRequest
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
    }
}
