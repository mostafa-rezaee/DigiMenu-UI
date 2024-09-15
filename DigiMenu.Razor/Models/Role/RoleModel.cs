namespace DigiMenu.Razor.Models.Role
{
    public class RoleModel : BaseModel
    {
        public string Title { get; set; }
        public List<Permissions> Permissions { get; set; }
    }

    public enum Permissions
    {
        ManageUsers = 1,
        ManageCategories = 2,
        ManagePageSettings = 3,
        ManageProducts = 4,
        ManageRoles = 5,
        ChangePassword = 6,
        ChangePrice = 7
    }
}
