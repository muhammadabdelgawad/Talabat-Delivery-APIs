using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Abstraction.Services.Products;
using Talabat.Application.Maping;
using Talabat.Application.Services;
using Talabat.Application.Services.Products;

namespace Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(MappingProfile));
           
            return services;
        }
    }
}
