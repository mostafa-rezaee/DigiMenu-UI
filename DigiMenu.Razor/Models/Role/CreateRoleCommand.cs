namespace DigiMenu.Razor.Models.Role
{
    public class CreateRoleCommand
    {
        public string Title { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}
