using Microsoft.AspNetCore.Identity;
using Talabat.Application.Abstraction.Models.Auth;
using Talabat.Application.Abstraction.Services.Auth;
using Talabat.Application.Exceptions;
using Talabat.Domain.Entities.Identity;

namespace Talabat.Application.Services.Auth
{
    public class AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)  : IAuthService
    {
        public async Task<UserDto> loginAsync(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null) throw new UnAuthorizedException("Invalid Login");

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, true);

            if (result.IsNotAllowed) throw new UnAuthorizedException("Please Confirm Your Account");

            if (result.IsLockedOut) throw new UnAuthorizedException("Account Is Locked");

            if (!result.Succeeded) throw new UnAuthorizedException("Invalid Login");

            var reponse = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = "Will Be Soon"
            };
            return reponse;
        }

        

        public Task<RegisterDto> RegisterAsync(RegisterDto model)
        {
            throw new NotImplementedException();
        }
    }
}
