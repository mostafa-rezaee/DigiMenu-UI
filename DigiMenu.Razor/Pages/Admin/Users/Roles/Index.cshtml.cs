using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models.Product;
using DigiMenu.Razor.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web.Mvc;

namespace DigiMenu.Razor.Pages.Admin.Users.Roles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public void OnGet(long userId)
        {
            
        }
    }
}
