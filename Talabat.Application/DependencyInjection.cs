using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Maping;
using Talabat.Application.Services;
namespace Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Fix: Use the correct overload of AddAutoMapper that accepts assembly types
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            services.AddScoped<ProductPictureUlrResolver>();
            return services;
        }
    }
}
