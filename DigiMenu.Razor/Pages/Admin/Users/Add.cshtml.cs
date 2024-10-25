using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Users
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public AddModel(IUserService userService)
        {
            _userService = userService;
        }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} الزامیست")]
        [MinLength(6, ErrorMessage = "طول رمزعبور باید از 6 کاراکتر بیشتر باشد")]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userService.CreateUser(new Models.User.CreateUserCommand { 
                FirstName = FirstName, 
                LastName = LastName, 
                Username = Username,
                Password = Password
            });

            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
