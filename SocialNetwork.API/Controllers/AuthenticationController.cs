using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Requests;
using SocialNetwork.Application.Services.Auth;

namespace SocialNetwork.API.Controllers
{
    public class AuthenticationController(IAuthService authService) : BaseController
    {
        private readonly IAuthService _authService = authService;

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var result = await _authService.LoginAsync(request);

                var response = new ApiResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ApiError(ex.Message);
                return BadRequest(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var result = await _authService.RegisterAsync(request);

                var response = new ApiResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new ApiError(ex.Message);
                return BadRequest(error);
            }
        }

    }
}
