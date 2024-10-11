using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DigiMenu.Razor.Models.User
{
    public class EditUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
