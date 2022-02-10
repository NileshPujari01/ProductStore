using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models;
using ProductStore.Application.Models.Request;
using ProductStore.Application.Models.Response;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions;
using ProductStore.Infrastructure.Persistence;

namespace ProductStore.Application.Services
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly ProductStoreDataContext _dataContext;

        public DataService(
            ILogger<DataService> logger,
            IProductCategoryRepository productCategoryRepository,
            IProductImagesRepository productImagesRepository,
            IProductsRepository productsRepository,
            IMapper mapper,
            ProductStoreDataContext dataContext
            )
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productImagesRepository = productImagesRepository;
            _productsRepository = productsRepository;
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ProductCategoryResponse> GetProductCategories(ProductCategoryRequest categoryRequest)
        {
            var productCategoriesData = await _productCategoryRepository.GetByIdAsync(categoryRequest.ProductCategoryId);

            var productCategories = new List<ProductCategoryResponseItems>();

            productCategories.Add(new ProductCategoryResponseItems
            {
                ProductCategoryId = productCategoriesData.ProductCategoryId,
                ProductCategoryName = productCategoriesData.ProductCategoryName
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
            //var productsData = await _productsRepository.GetAllAsync();

            //var products = productsData.Select(s => new ProductsResponseItems()
            //{
            //    ProductId= s.ProductId,
            //    ProductName = s.ProductName,
            //    ProductCategory = s.ProductCategory,
            //    ProductPrice = s.ProductPrice,
            //    ProductRating = s.ProductRating
            //});

            //return new ProductsResponse
            //{
            //    Products = products
            //};

            var productData = from p in _dataContext.Products
                              from pc in _dataContext.ProductCategory.Where(x => x.ProductCategoryId == p.ProductCategory).DefaultIfEmpty()
                              from pi in _dataContext.ProductImages.Where(x => x.ProductId == p.ProductId).DefaultIfEmpty()
                              select new
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  ProductCategory = pc.ProductCategoryId,
                                  ProductPrice = p.ProductPrice,
                                  ProductRating = p.ProductRating,
                                  ProductImage = pi.ProductImageName,
                                  ProductCategoryName = pc.ProductCategoryName
                              };

            var products = productData.Select(x => new ProductsResponseItems
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductCategory = x.ProductCategory,
                ProductPrice = x.ProductPrice,
                ProductRating = x.ProductRating,
                ProductImageLink = x.ProductImage,
                ProductCategoryName = x.ProductCategoryName
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

        public async Task<CreateProductResponse> CreateProduct(ProductRequest productRequest)
        {
            var request = _mapper.Map<ProductsEntity>(productRequest);
            var dbResponse = await _productsRepository.AddAsync(request);
            var response = _mapper.Map<CreateProductResponse>(dbResponse);
            return response;
        }

        public async Task<CreateProductResponse> UpdateProduct(ProductRequest productRequest)
        {
            var entity = await _productsRepository.GetByIdAsync(productRequest.ProductId);
            entity.ProductName = productRequest.ProductName;
            entity.ProductRating = productRequest.ProductRating;
            entity.ProductPrice = productRequest.ProductPrice;
            entity.ProductCategory = productRequest.ProductCategory;
            await _productsRepository.UpdateAsync(entity);
            return new CreateProductResponse { ProductName = entity.ProductName };
        }

        public async Task<DeleteProductResponse> DeleteProduct(int productId)
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
            return new DeleteProductResponse { IsProductDeleted = status };
        }
    }
}
