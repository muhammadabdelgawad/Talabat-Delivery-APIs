using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Abstraction.Services.Basket;
using Talabat.Application.Maping;
using Talabat.Application.Services;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Infrastructure.Persistence.Repositories.Baskets;
namespace Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            services.AddScoped<ProductPictureUlrResolver>();
            services.AddScoped(typeof(Func<IBasketService>), (serviceProvider) =>
            {
                var _mapper = serviceProvider.GetRequiredService<IMapper>();
                var _configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var _basketRepository = serviceProvider.GetRequiredService<IBasketRepository>();
                return () => new BasketService(_basketRepository,_mapper, _configuration);
            });
                
                return services;
        }
    }
}
