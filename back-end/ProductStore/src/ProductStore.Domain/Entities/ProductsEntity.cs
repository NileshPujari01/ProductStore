namespace ProductStore.Domain.Entities
{
    public class ProductsEntity
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int ProductRating { get; set; }
    }
}
