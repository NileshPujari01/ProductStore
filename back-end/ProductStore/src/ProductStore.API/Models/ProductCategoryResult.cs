namespace ProductStore.API.Models
{
    public class ProductCategoryResult
    {
        public IEnumerable<ProductCategoryResponseItems> ProductCategories { get; set; }
    }

    public class ProductCategoryResponseItems
    {
        public int ProductCategoryId { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
