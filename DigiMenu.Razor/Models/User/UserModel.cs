namespace DigiMenu.Razor.Models.User
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarName { get; set; }
        public bool IsActive { get; set; }
        public List<UserRoleModel> Roles { get; set; }
    }

    public class UserRoleModel
    {
        public long RoleId { get; set; }
        public string RoleTitle { get; set; }
    }
}
