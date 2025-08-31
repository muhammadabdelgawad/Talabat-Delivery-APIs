using Microsoft.Extensions.DependencyInjection;
using Talabat.Application.Maping;
namespace Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
          //   services.AddAutoMapper(typeof(MappingProfile));
           services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            return services;
        }
    }
}
