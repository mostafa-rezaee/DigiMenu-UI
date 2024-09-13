using DigiMenu.Razor.Services.Authentications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthenticationService _authenticationService;
        public IndexModel(ILogger<IndexModel> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public async Task OnGet()
        {
            //var result = await _authenticationService.Login(
            //    new Models.Authentication.LoginCommand { 
            //    Username = "mostafa", Password= "123456"
            //}
            //);
        }
    }
}
