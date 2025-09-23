using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Contracts.Presistence;
namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                         options.UseLazyLoadingProxies()
                         .UseSqlServer(configuration.GetConnectionString("StoreConnection")));

            services.AddScoped<IStoreContextIntiializer, StoreContextInitializer>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));
          
            return services;

        }
    }
}
