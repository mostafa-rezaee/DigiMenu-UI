namespace DigiMenu.Razor.Models.User
{
    public class UserFilterModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string AvatarName { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserFilterParams : BaseFilterParam
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class UserFilterResult : BaseFilter<UserFilterModel, UserFilterParams> { }

    public class CreateUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class EditUserCommand
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IFormFile? AvatarImage { get; set; }
    }

    public class ChangePasswordCommand
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
