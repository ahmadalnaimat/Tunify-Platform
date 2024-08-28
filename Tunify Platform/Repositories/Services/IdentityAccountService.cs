using Microsoft.AspNetCore.Identity;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityAccountService> _logger;
        private readonly JwtTokenService _jwtTokenService;

        public IdentityAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<IdentityAccountService> logger, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var userModel = new User
            {
                UserID = int.Parse(user.Id),
                Email = user.Email
            };

            var token = _jwtTokenService.CreateToken(userModel, roles);
            return token;
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
                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration");
                throw;
            }
        }
        public async Task<IdentityUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
