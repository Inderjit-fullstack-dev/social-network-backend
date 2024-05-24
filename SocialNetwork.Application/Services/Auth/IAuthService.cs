using SocialNetwork.Application.Requests;
using SocialNetwork.Application.Responses;

namespace SocialNetwork.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
    }
}
