using DigiMenu.Razor.Infrastructure.RazorPageUtilities;
using DigiMenu.Razor.Models.Product;
using DigiMenu.Razor.Models.User;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiMenu.Razor.Pages.Admin.Users
{
    public class IndexModel : BaseRazorFilter<UserFilterParams>
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserFilterResult Users { get; set; }
        public async Task OnGet()
        {
            Users = await _userService.GetUsersByFilter(FilterParams);
        }
    }
}
