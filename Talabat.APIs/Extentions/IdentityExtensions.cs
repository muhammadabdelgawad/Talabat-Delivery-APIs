using Microsoft.AspNetCore.Identity;
using Talabat.Application.Abstraction.Services.Auth;
using Talabat.Application.Services.Auth;
using Talabat.Domain.Entities.Identity;
using Talabat.Infrastructure.Persistence._Identity;

namespace Talabat.APIs.Extentions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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
             })
                 .AddEntityFrameworkStores<StoreIdentityDbConetxt>();


            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            services.AddScoped(typeof(Func<IAuthService>), (serviceProvider =>
            {
                return () => serviceProvider.GetService<IAuthService>();
            }));

            return services;
        }
    }
}
