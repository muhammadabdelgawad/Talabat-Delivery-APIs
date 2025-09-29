using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Entities.Identity;

namespace Talabat.Application.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<ApplicationUser> FindUserWithAddress(this UserManager<ApplicationUser> userManager,
            ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Where(u => u.Email == email)
                                              .Include(u => u.Address )
                                              .FirstOrDefaultAsync();
             
            return user!;
        }
    }
}
