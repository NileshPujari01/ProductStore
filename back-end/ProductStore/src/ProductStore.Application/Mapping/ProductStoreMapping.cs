using AutoMapper;
using applicationModel = ProductStore.Application.Models;
using entityModel = ProductStore.Domain.Entities;

namespace ProductStore.Application.Mapping
{
    public class ProductStoreMapping: Profile
    {
        public ProductStoreMapping()
        {
            CreateMap<applicationModel.Request.ProductRequest, entityModel.ProductsEntity>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(dest => dest.ProductId))
                .ForMember(dest => dest.ProductRating, opt => opt.MapFrom(dest => dest.ProductRating))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(dest => dest.ProductPrice))
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(dest => dest.ProductCategory))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(dest => dest.ProductName));
        }
    }
}
