namespace ProductStore.Application.Models
{
    public class ProductCategoryResponse
    {
        public IEnumerable<ProductCategoryResponseItems> ProductCategories { get; set; }
    }

    public class ProductCategoryResponseItems
    {
        public int ProductCategoryId { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
