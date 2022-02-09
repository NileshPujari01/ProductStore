using AutoMapper;
using apiModel = ProductStore.API.Models;
using applicationModel = ProductStore.Application.Models;

namespace ProductStore.API.Mapping
{
    public class ProductStoreServiceProfile : Profile
    {
        public ProductStoreServiceProfile()
        {
            CreateMap<applicationModel.ProductCategoryResponseItems, apiModel.ProductCategoryResponseItems>();
            CreateMap<applicationModel.ProductCategoryResponse, apiModel.ProductCategoryResult>()
                .ForMember(dest => dest.ProductCategories, opt => opt.MapFrom(dest => dest.ProductCategories));

            CreateMap<applicationModel.ProductImagesResponseItems, apiModel.ProductImagesResponseItems>();
            CreateMap<applicationModel.ProductImagesResponse, apiModel.ProductImagesResult>()
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(dest => dest.ProductImages));

            CreateMap<applicationModel.ProductsResponseItems, apiModel.ProductsResponseItems>();
            CreateMap<applicationModel.ProductsResponse, apiModel.ProductsResult>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(dest => dest.Products));

            CreateMap<apiModel.Request.ProductRatingRequest, applicationModel.Request.SetProductRatingRequest>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(dest => dest.ProductId))
                .ForMember(dest => dest.ProductRating, opt => opt.MapFrom(dest => dest.ProductRating));

            CreateMap<applicationModel.Response.SetProductRatingResponse, apiModel.Response.ProductRatingResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(dest => dest.ProductId))
                .ForMember(dest => dest.ProductRating, opt => opt.MapFrom(dest => dest.ProductRating));

            CreateMap<apiModel.Request.ProductApiRequest, applicationModel.Request.ProductRequest>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(dest => dest.ProductId))
                .ForMember(dest => dest.ProductRating, opt => opt.MapFrom(dest => dest.ProductRating))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(dest => dest.ProductName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(dest => dest.ProductPrice))
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(dest => dest.ProductCategory));

            CreateMap<applicationModel.Response.CreateProductResponse, apiModel.Response.ProductApiResponse>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(dest => dest.ProductName));

            CreateMap<applicationModel.Response.DeleteProductResponse, apiModel.Response.ProductDeleteResponse>()
               .ForMember(dest => dest.IsProductDeleted, opt => opt.MapFrom(dest => dest.IsProductDeleted));
        }
    }
}
