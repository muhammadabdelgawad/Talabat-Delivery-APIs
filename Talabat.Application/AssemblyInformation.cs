using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Abstraction.Services.Products;
using Talabat.Application.Services;
using Talabat.Application.Services.Products;

namespace Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof());
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            return services;
        }
    }
}