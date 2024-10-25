using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Services.Authentications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages.Admin
{

    public class IndexModel : BaseRazorPage
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
            
        }
    }
}
