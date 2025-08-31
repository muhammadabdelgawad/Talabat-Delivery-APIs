using AutoMapper;
using Talabat.Application.Abstraction.DTOs.Products;
using Talabat.Domain.Entities;

namespace Talabat.Application.Maping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                  .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name))
                  .ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name));
        }
    }
}
