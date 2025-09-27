using Talabat.Application.Abstraction.Models.Auth;

namespace Talabat.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> loginAsync(LoginDto model);
        Task<UserDto> RegisterAsync(RegisterDto model);
         
    }
}
