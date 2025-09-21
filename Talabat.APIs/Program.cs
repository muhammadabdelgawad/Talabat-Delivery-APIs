using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Extentions;
using Talabat.APIs.Middlewares;
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
                             .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly)
                             .ConfigureApiBehaviorOptions(option =>
                             {
                                 option.SuppressModelStateInvalidFilter = false;
                                 option.InvalidModelStateResponseFactory = (actionContext) =>
                                 {
                                     var errors =actionContext.ModelState.Where(p => p.Value!.Errors.Count > 0)
                                      .Select(p => new ValidationError()
                                      {
                                          Field = p.Key,
                                          Errors = p.Value!.Errors.Select(e => e.ErrorMessage)
                                      });
                                     return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = errors });
                                 };
                             });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            #endregion

            var app = builder.Build();

            # region DatabaseInitializer
            await app.InitializeStoreContextAsync();

            #endregion

           
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
