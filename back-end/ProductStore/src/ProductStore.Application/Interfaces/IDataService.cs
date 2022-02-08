using ProductStore.Application.Models;
using ProductStore.Application.Models.Request;
using ProductStore.Application.Models.Response;

namespace ProductStore.Application.Interfaces
{
    public interface IDataService
    {
        Task<ProductCategoryResponse> GetProductCategories();
        Task<ProductImagesResponse> GetProductImages();
        Task<ProductsResponse> GetProducts();
        Task<SetProductRatingResponse> SetProductRating(SetProductRatingRequest ratingRequest);
        Task<string> CreateProduct(ProductRequest productRequest);
        Task<string> UpdateProduct(ProductRequest productRequest);
        Task<bool> DeleteProduct(int productId);
    }
}
