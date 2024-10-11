using DigiMenu.Razor.Infrastructure;
using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.User;

namespace DigiMenu.Razor.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult?> ChangePassword(ChangePasswordCommand command)
        {
            var result = await _httpClient.PutAsJsonAsync("user/changePassword", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> CreateUser(CreateUserCommand command)
        {
            var result = await _httpClient.PostAsJsonAsync("user", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> EditUser(EditUserCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Id.ToString()), "id");
            formData.Add(new StringContent(command.FirstName), "firstName");
            formData.Add(new StringContent(command.LastName), "lastName");
            if (command.AvatarImage != null)
                formData.Add(new StreamContent(command.AvatarImage.OpenReadStream()), "avatar");
            formData.Add(new StringContent(command.Username), "username");
            var result = await _httpClient.PutAsync("user", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> EditUserCurrent(EditUserModel command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.FirstName), "firstName");
            formData.Add(new StringContent(command.LastName), "lastName");
            if (command.Avatar != null)
                formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "avatar", command.Avatar.FileName);
            formData.Add(new StringContent(command.Username), "username");
            var result = await _httpClient.PutAsync("user/current", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UserModel?> GetCurrentUser()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<UserModel>>($"user/current");
            return result?.Data;
        }

        public async Task<UserModel?> GetUserById(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<UserModel>>($"user/{id}");
            return result?.Data;
        }

        public async Task<UserModel?> GetUserByUsername(string username)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<UserModel>>($"user/ubun/{username}");
            return result?.Data;
        }

        public async Task<UserFilterResult?> GetUsersByFilter(UserFilterParams filterParams)
        {
            var url = filterParams.GenerateBaseFilterUrl("user");
            if (!string.IsNullOrWhiteSpace(filterParams.Username))
            {
                url += $"&Username={filterParams.Username}";
            }
            if (!string.IsNullOrWhiteSpace(filterParams.FirstName))
            {
                url += $"&FirstName={filterParams.FirstName}";
            }
            if (!string.IsNullOrWhiteSpace(filterParams.LastName))
            {
                url += $"&LastName={filterParams.LastName}";
            }
            var result = await _httpClient.GetFromJsonAsync<ApiResult<UserFilterResult?>>(url);
            return result?.Data;
        }
    }
}
