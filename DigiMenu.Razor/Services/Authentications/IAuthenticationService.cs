using DigiMenu.Razor.Infrastructure;
using DigiMenu.Razor.Models.Authentication;

namespace DigiMenu.Razor.Services.Authentications
{
    public interface IAuthenticationService
    {
        Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
        Task<ApiResult?> Register(RegisterCommand command);
        Task<ApiResult<LoginResponse>?> RefreshToken();
        Task<ApiResult?> Logout();
    }
}
