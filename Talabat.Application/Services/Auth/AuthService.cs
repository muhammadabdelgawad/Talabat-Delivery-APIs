using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

            if (result.IsNotAllowed)  throw new UnAuthorizedException("Please Confirm Your Account");

            if (result.IsLockedOut) throw new UnAuthorizedException("Account Is Locked");

            if (!result.Succeeded) throw new UnAuthorizedException("Invalid Login");

            var reponse = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };
            return reponse;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto model)
        {
          
            var existingUser = await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                throw new ValidationException() { Errors = new[] { $"Email '{model.Email}' is already registered" } };
            }

            
            existingUser = await userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                throw new ValidationException() { Errors = new[] { $"Username '{model.UserName}' is already taken" } };
            }           

            var user = new ApplicationUser
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => $"{e.Code}: {e.Description}").ToList();
                
                throw new ValidationException()
                {
                    Errors = errors
                };
            }
            
            var response = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };
            return response;
        }
         
        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var rolesAsCalaim = new List<Claim>();
            
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
                rolesAsCalaim.Add(new Claim(ClaimTypes.Role, role.ToString()));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid,user.Id),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.GivenName,user.DisplayName!),
            }.Union(userClaims)
             .Union(rolesAsCalaim);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-256-bit-secrettttoowdiwdittttttttt"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(
                issuer: "TalabatIdentity",
                audience: "TalabatUsers",
                expires: DateTime.UtcNow.AddMinutes(15),
                claims: claims,
                signingCredentials: signingCredentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);  

        }

    }
}
        