using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace DigiMenu.Razor.Pages.Profile
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        [DisplayName("نام و نام خانوادگی")]
        public string FullName { get; set; }

        [DisplayName("شماره موبایل")]
        public string MobileNumber { get; set; }

        public void OnGet()
        {
        }
    }
}
