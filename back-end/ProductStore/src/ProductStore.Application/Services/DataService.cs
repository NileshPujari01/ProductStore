using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models;
using ProductStore.Application.Models.Request;
using ProductStore.Application.Models.Response;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions;

namespace ProductStore.Application.Services
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public DataService(
            ILogger<DataService> logger,
            IProductCategoryRepository productCategoryRepository,
            IProductImagesRepository productImagesRepository,
            IProductsRepository productsRepository,
            IMapper mapper
            )
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productImagesRepository = productImagesRepository;
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryResponse> GetProductCategories()
        {
            var productCategoriesData = await _productCategoryRepository.GetAllAsync();

            var productCategories = productCategoriesData.Select(s => new ProductCategoryResponseItems()
            {
                ProductCategoryId = s.ProductCategoryId,
                ProductCategoryName = s.ProductCategoryName
            });

            return new ProductCategoryResponse
            {
                ProductCategories = productCategories
            };
        }

        public async Task<ProductImagesResponse> GetProductImages()
        {
            var productImagesData = await _productImagesRepository.GetAllAsync();

            var productImages = productImagesData.Select(s => new ProductImagesResponseItems()
            {
                ProductId = s.ProductId,
                ProductImageId = s.ProductImageId,
                ProductImageName = s.ProductImageName
            });

            return new ProductImagesResponse
            {
                ProductImages = productImages
            };
        }

        public async Task<ProductsResponse> GetProducts()
        {
            var productsData = await _productsRepository.GetAllAsync();

            var products = productsData.Select(s => new ProductsResponseItems()
            {
                ProductId= s.ProductId,
                ProductName = s.ProductName,
                ProductCategory = s.ProductCategory,
                ProductPrice = s.ProductPrice,
                ProductRating = s.ProductRating
            });

            return new ProductsResponse
            {
                Products = products
            };
        }

        public async Task<SetProductRatingResponse> SetProductRating(SetProductRatingRequest ratingRequest)
        {
            var entity = await _productsRepository.GetByIdAsync(ratingRequest.ProductId);
            entity.ProductRating = ratingRequest.ProductRating;
            await _productsRepository.UpdateAsync(entity);
            return new SetProductRatingResponse { ProductId = entity.ProductId, ProductRating = entity.ProductRating };
        }

        public async Task<string> CreateProduct(ProductRequest productRequest)
        {
            var request = _mapper.Map<ProductsEntity>(productRequest);
            var response = await _productsRepository.AddAsync(request);
            return response.ProductName;
        }

        public async Task<string> UpdateProduct(ProductRequest productRequest)
        {
            var entity = await _productsRepository.GetByIdAsync(productRequest.ProductId);
            entity.ProductName = productRequest.ProductName;
            entity.ProductRating = productRequest.ProductRating;
            entity.ProductPrice = productRequest.ProductPrice;
            entity.ProductCategory = productRequest.ProductCategory;
            await _productsRepository.UpdateAsync(entity);
            return entity.ProductName;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            bool status;
            try
            {
                var entity = await _productsRepository.GetByIdAsync(productId);
                await _productsRepository.DeleteAsync(entity);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
