using Talabat.APIs.Extentions;
using Talabat.Application;
using Talabat.Infrastructure.Persistence;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            #region Configure Services

            builder.Services.AddControllers()
                             .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            #endregion

            var app = builder.Build();

            # region DatabaseInitializer
            await app.InitializeStoreContextAsync();
           
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
