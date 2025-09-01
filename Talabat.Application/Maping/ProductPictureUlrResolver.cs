using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Application.Abstraction.DTOs.Products;
using Talabat.Domain.Entities;

namespace Talabat.Application.Maping
{
    internal class ProductPictureUlrResolver(IConfiguration configuration) : IValueResolver<Product, ProductToReturnDto, string?>
    {
      

        public string? Resolve(Product source, ProductToReturnDto destination, string? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["Urls:ApiBaseUrl"]}/{source.PictureUrl}";

            return string.Empty;
            
        }
    }
}
