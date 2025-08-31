using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StoreConnection")));

            services.AddScoped<IStoreContextIntiializer, StoreContextInitializer>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));
            return services;

        }
    }
}
