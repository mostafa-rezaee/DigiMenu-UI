using DigiMenu.Razor.Models;
using DigiMenu.Razor.Models.User;

namespace DigiMenu.Razor.Services.Users
{
    public interface IUserService
    {
        Task<UserFilterResult?> GetUsersByFilter(UserFilterParams filterParams);
        Task<UserModel?> GetUserById(long id);
        Task<UserModel?> GetUserByUsername(string username);
        Task<UserModel?> GetCurrentUser();

        Task<ApiResult?> CreateUser(CreateUserCommand command);
        Task<ApiResult?> EditUser(EditUserCommand command);
        Task<ApiResult?> ChangePassword(ChangePasswordCommand command);
    }
}
