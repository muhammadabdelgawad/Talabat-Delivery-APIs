using Talabat.Domain.Contracts.Presistence;
using Talabat.Infrastructure.Persistence;

namespace Talabat.APIs.Extentions
{
    public static class InitializerExtentions
    {
        public static async Task<WebApplication> InitializeStoreContextAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var storeContextInitializer = services.GetRequiredService<IStoreDbIntializer>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await storeContextInitializer.IntializeAsync();
                await storeContextInitializer.SeedAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migrations or data seeding ");

            }
            return app;
        }
    }
}
