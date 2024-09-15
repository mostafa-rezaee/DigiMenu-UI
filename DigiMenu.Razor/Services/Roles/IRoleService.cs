using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.Role;

namespace DigiMenu.Razor.Services.Roles
{
    public interface IRoleService
    {
        Task<RoleModel?> GetRoleById(long id);
        Task<List<RoleModel>?> GetRoles();

        Task<ApiResult?> CreateRole(CreateRoleCommand command);
        Task<ApiResult?> UpdateRole(EditRoleCommand command);
    }
}
