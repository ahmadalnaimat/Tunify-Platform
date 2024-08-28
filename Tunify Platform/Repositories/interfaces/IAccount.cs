using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IAccount
    {
        Task<string> GenerateJwtToken(IdentityUser user);
        Task<IdentityResult> Register(RegisterDto registerDto);
        Task<SignInResult> Login(LoginDto loginDto);
        Task<IdentityUser> GetUserByUsername(string username);
        Task Logout();
    }
}
