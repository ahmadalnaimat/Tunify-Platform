using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityAccountService> _logger;
        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<IdentityAccountService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            try
            {
                return await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration");
                throw;
            }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }
        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            try
            {
                var user = new IdentityUser { UserName = registerDto.Username, Email = registerDto.Email };
                return await _userManager.CreateAsync(user, registerDto.Password);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration");
                throw;
            }
        }
    }
}
