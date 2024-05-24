using Microsoft.AspNetCore.Identity;
using SocialNetwork.Application.Requests;
using SocialNetwork.Application.Responses;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Helpers;
using SocialNetwork.Infrastructure.Jwt;

namespace SocialNetwork.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? throw new Exception(Utility.GetValue("InCorrectEmailOrPassword"));
                
                bool isPasswordMatched = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!isPasswordMatched)
                {
                    throw new Exception(Utility.GetValue("InCorrectEmailOrPassword"));
                }

                var roles = await _userManager.GetRolesAsync(user);

                UserData userData = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = roles
                };

                // else login
                var result = new AuthResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    LookingFor = user.LookingFor,
                    Token = _jwtService.CreateToken(userData)
                };

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var existingUserByUsername = await _userManager.FindByNameAsync(request.UserName);
                if (existingUserByUsername != null)
                {
                    throw new Exception(Utility.GetValue("UsernameTaken"));
                }

                var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email);
                if (existingUserByEmail != null)
                {
                    throw new Exception(Utility.GetValue("EmailTaken"));
                }

                if (!await _roleManager.RoleExistsAsync(Utility.GetValue("User")))
                {
                    var role = new AppRole { Name = Utility.GetValue("User") };
                    await _roleManager.CreateAsync(role);
                }

                var user = new AppUser
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    LookingFor = request.LookingFor
                };

                var userResult = await _userManager.CreateAsync(user, request.Password);

                if (userResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Utility.GetValue("User"));
                }

                var result = new AuthResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    LookingFor = user.LookingFor,
                    Token = "abc"
                };

                return result;

            }
            catch
            {
                throw;
            }
        }
    }
}
