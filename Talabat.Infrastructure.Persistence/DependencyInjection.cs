using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Domain.Contracts.Presistence.DbIntializers;
using Talabat.Domain.Contracts.Presistence.UnitOfWork;
using Talabat.Infrastructure.Persistence._Data;
using Talabat.Infrastructure.Persistence._Identity;
namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
                         options.UseLazyLoadingProxies()
                                .UseSqlServer(configuration.GetConnectionString("StoreConnection")));

            services.AddScoped<IStoreDbIntializer, StoreDbInitializer>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));

            services.AddDbContext<StoreIdentityDbConetxt>(options =>
                         options.UseLazyLoadingProxies()
                                .UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            return services;

        }
    }
}
