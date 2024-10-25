using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace DigiMenu.Razor.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class StatusCodeModel : PageModel
    {
        public string? ErrorMessage { get; set; }
        public void OnGet(int statusCode)
        {
            switch (statusCode)
            {
                case 403:
                    ErrorMessage = "شما برای انجام عملیات نیاز به دسترسی دارید";
                    break;
                default:
                    break;
            }
        }
    }
}
