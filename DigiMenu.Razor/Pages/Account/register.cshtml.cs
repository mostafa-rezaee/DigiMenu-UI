using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Authentications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Account
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class registerModel : BaseRazorPage
    {
        private readonly IAuthenticationService _authenticationService;

        public registerModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} الزامیست")]
        public string FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "{0} الزامیست")]
		public string LastName { get; set; }

		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "{0} الزامیست")]
		public string Username { get; set; }

		[Display(Name = "رمزعبور")]
		[Required(ErrorMessage = "{0} الزامیست")]
        [MinLength(6, ErrorMessage = "طول رمزعبور باید از 6 کاراکتر بیشتر باشد")]
        public string Password { get; set; }

		[Display(Name = "تکرار رمزعبور")]
		[Required(ErrorMessage = "{0} الزامیست")]
        [Compare("Password", ErrorMessage = "رمزعبور و تکرار آن یکسان نیستند")]
		public string ConfirmPassword { get; set; }


		public IActionResult OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
            var result = await _authenticationService.Register(new Models.Authentication.RegisterCommand() { 
                Username = Username,
                Password = Password,
                ConfirmPassword  = ConfirmPassword
            });
            //if (result.IsSuccess == false)
            //{
            //    ModelState.AddModelError(nameof(FirstName), result.MetaData.Message);
            //    return Page();
            //}
            return RedirectAndShowAlert(result, RedirectToPage("login"));
        }
    }
}
