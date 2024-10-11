
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Profile
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [DisplayName("نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string LastName { get; set; }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Username { get; set; }

        [DisplayName("نصویر پروفایل")]
        [Infrastructure.CustomValidation.FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile? Avatar { get; set; }

        public async Task OnGet()
        {
            var user = await _userService.GetCurrentUser();
            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                Username = user.Username;

            }
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userService.EditUserCurrent(new Models.User.EditUserModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Avatar = Avatar
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
