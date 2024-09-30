using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Authentications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages.Account
{
    public class logoutModel : BaseRazorPage
    {
        private readonly IAuthenticationService _authenticationService;

        public logoutModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await _authenticationService.Logout();
            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Delete("token");
                HttpContext.Response.Cookies.Delete("refresh-token");

            }
            return RedirectAndShowAlert(result, RedirectToPage("../Index"));
        }
    }
}
