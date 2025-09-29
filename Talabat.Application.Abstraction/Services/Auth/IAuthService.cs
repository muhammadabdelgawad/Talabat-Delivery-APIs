using System.Security.Claims;
using Talabat.Application.Abstraction.Models.Auth;
using Talabat.Application.Abstraction.Models.Common;

namespace Talabat.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> loginAsync(LoginDto model);
        Task<UserDto> RegisterAsync(RegisterDto model);
        Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<AddressDto> GetUserAddressAsync(ClaimsPrincipal claimsPrincipal); 
    }
}
