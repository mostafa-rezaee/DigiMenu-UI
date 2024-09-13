namespace DigiMenu.Razor.Models.Authentication
{
    public class RegisterCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
