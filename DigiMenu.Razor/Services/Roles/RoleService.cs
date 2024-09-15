using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Role;

namespace DigiMenu.Razor.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult?> CreateRole(CreateRoleCommand command)
        {
            var result = await _httpClient.PostAsJsonAsync("role", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult?> UpdateRole(EditRoleCommand command)
        {
            var result = await _httpClient.PutAsJsonAsync("role", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<RoleModel?> GetRoleById(long id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<RoleModel>?>($"role/{id}");
            return result?.Data;
        }

        public async Task<List<RoleModel>?> GetRoles()
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<List<RoleModel>>?>("role");
            return result?.Data;
        }

        
    }
}
