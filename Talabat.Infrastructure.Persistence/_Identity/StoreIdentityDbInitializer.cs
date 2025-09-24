using Microsoft.AspNetCore.Identity;
using Talabat.Domain.Contracts.Presistence.DbIntializers;
using Talabat.Domain.Entities.Identity;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence._Identity
{
    public class StoreIdentityDbInitializer(StoreDbContext _dbContext ,UserManager<ApplicationUser> _userManager) : DbInitializer(_dbContext), IStoreIdentityInializer
    {
        public override async Task SeedAsync()
        {
            var user = new ApplicationUser
            {
                DisplayName = "Muhammad Abdelgawad",
                UserName = "muhammad.abdelgawad",
                Email = "muhammad@outlook.com",
                PhoneNumber = "01000000100"
            };

            await _userManager.CreateAsync(user, "Pa$$w0rd");

        }
    }
}
