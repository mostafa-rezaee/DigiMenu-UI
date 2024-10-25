using DigiMenu.Razor.Infrastructure.CustomValidation;
using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Admin.Users
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
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

        [Display(Name = "عکس آواتار")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? AvatarImage { get; set; }

        [Display(Name = "فعال باشد؟")]
        public bool IsActive { get; set; }

        public async Task OnGet(long id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                RedirectToPage("Index");
            }
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            IsActive = user.IsActive;
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _userService.EditUser(new Models.User.EditUserCommand { 
                Id = id,
                FirstName = FirstName,
                LastName = LastName,
                AvatarImage = AvatarImage,
                IsActive = IsActive,
                Username = Username
            });

            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
