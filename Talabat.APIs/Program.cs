using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Extentions;
using Talabat.APIs.Middlewares;
using Talabat.Application;
using Talabat.Domain.Entities.Identity;
using Talabat.Infrastructure;
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
                                     var errors = actionContext.ModelState.Where(p => p.Value!.Errors.Count > 0)
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
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;

                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            #endregion

            var app = builder.Build();

            # region DatabaseInitializer
            await app.InitializeDbAsync();

            #endregion

           
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
