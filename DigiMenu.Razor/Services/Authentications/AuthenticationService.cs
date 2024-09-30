using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Authentication;

namespace DigiMenu.Razor.Services.Authentications
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthenticationService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
        {
            var requestResult = await _httpClient.PostAsJsonAsync("authentication/login", command);
            return await requestResult.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
        }

        public async Task<ApiResult?> Logout()
        {
            try
            {
                var requestResult = await _httpClient.PostAsync("authentication/logout", null);
                return await requestResult.Content.ReadFromJsonAsync<ApiResult>();
            }
            catch (Exception)
            {

                return ApiResult.Error();
            }
            
        }

        public async Task<ApiResult<LoginResponse>?> RefreshToken()
        {
            var refreshToken = _contextAccessor.HttpContext.Request.Cookies["refreshToken"];
            var requestResult = await _httpClient.PostAsync($"authentication/refreshToken?refreshToken={refreshToken}", null);
            return await requestResult.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
        }

        public async Task<ApiResult?> Register(RegisterCommand command)
        {
            var requestResult = await _httpClient.PostAsJsonAsync("authentication/register", command);
            return await requestResult.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
