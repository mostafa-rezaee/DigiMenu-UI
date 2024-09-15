namespace DigiMenu.Razor.Models.Role
{
    public class EditRoleCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<Permissions> Permissions { get; set; }
    }
}
