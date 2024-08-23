using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> Register(RegisterDto registerDto);
        Task<SignInResult> Login(LoginDto loginDto);
        Task Logout();
    }
}
