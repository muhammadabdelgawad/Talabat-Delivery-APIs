using Microsoft.EntityFrameworkCore;
using Talabat.Infrastructure.Persistence;
using Talabat.Infrastructure.Persistence.Data;
namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            #region Configure Services

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices(builder.Configuration);

            #endregion

            var app = builder.Build();

            #region UpdateDatabase

            using var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            var loggerFactory= services.GetRequiredService<ILoggerFactory>();

            try
            {
                var pendingMigratuiions = dbContext.Database.GetPendingMigrations();
                if (pendingMigratuiions.Any())
                    await dbContext.Database.MigrateAsync();
                 
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred during migrations");

            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();

            app.MapControllers();

            app.Run();
        }
    }
}
