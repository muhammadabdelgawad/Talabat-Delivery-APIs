using AutoMapper;
using Talabat.Application.Abstraction.DTOs.Products;
using Talabat.Application.Abstraction.Models.Basket;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Domain.Entities;
using Talabat.Domain.Entities.Basket;

namespace Talabat.Application.Maping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductToReturnDto>()
                  .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name))
                  .ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name))
                  .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureUlrResolver>());   
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();

            CreateMap<Basket, BasketItemDto>().ReverseMap();
            CreateMap<BasketItemDto, Basket>().ReverseMap();
        
        
        }
    }
}
 