using ProductStore.Application.Models;
using ProductStore.Application.Models.Request;
using ProductStore.Application.Models.Response;

namespace ProductStore.Application.Interfaces
{
    public interface IDataService
    {
        Task<ProductCategoryResponse> GetProductCategories();
        Task<ProductCategoryResponse> GetProductCategoryById(ProductCategoryRequest categoryRequest);
        Task<ProductImagesResponse> GetProductImages();
        Task<ProductsResponse> GetProducts();
        Task<SetProductRatingResponse> SetProductRating(SetProductRatingRequest ratingRequest);
        Task<CreateProductResponse> CreateProduct(ProductRequest productRequest);
        Task<CreateProductResponse> UpdateProduct(ProductRequest productRequest);
        Task<DeleteProductResponse> DeleteProduct(int productId);
    }
}
