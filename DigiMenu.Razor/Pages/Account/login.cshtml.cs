using DigiMenu.Razor.Models;
using DigiMenu.Razor.Services.Authentications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Razor.Pages.Account
{
	[BindProperties]
	[ValidateAntiForgeryToken]
    public class loginModel : PageModel
    {
		private readonly IAuthenticationService _authenticationService;

        public loginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "{0} الزامیست")]
		public string Username { get; set; }

		[Display(Name = "رمزعبور")]
		[Required(ErrorMessage = "{0} الزامیست")]
		[MinLength(6, ErrorMessage = "طول رمزعبور باید از 6 کاراکتر بیشتر باشد" )]
		public string Password { get; set; }

		public string RedirectTo { get; set; }

		public IActionResult OnGet(string redirectTo)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
			RedirectTo = redirectTo;
            return Page();
        }

		public async Task<IActionResult> OnPost()
		{
			var result = await _authenticationService.Login(new Models.Authentication.LoginCommand() { 
				Username = Username,
				Password = Password
			});
			if (result.IsSuccess == false)
			{
				ModelState.AddModelError(nameof(Username), result.MetaData.Message);
				return Page();
			}
			if (result.Data != null)
			{
                var token = result.Data.Token;
				var refreshToken = result.Data.RefreshToken;
				HttpContext.Response.Cookies.Append("token", token);
                HttpContext.Response.Cookies.Append("refresh-token", token);
            }
			if (!string.IsNullOrWhiteSpace(RedirectTo))
			{
				return LocalRedirect(RedirectTo);
			}
			return Redirect("/");
		}
    }
}
