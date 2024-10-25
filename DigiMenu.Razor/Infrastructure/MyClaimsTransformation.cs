using DigiMenu.Razor.Models.User;
using DigiMenu.Razor.Services.Users;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace DigiMenu.Razor.Infrastructure
{
    public class MyClaimsTransformation : IClaimsTransformation
    {
        private readonly IUserService _userService;

        public MyClaimsTransformation(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var claims = principal.Claims;

            var loggedInUser = await _userService.GetCurrentUser();
            AddLoggedInUserIdentity(principal, claims, loggedInUser);

            return principal;
        }

        private void AddLoggedInUserIdentity(ClaimsPrincipal principal, IEnumerable<Claim> claims, UserModel user)
        {
            var identity = principal.Identities.First() ?? new ClaimsIdentity();

            foreach (var role in user.Roles)
            {
                if (!principal.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == role.RoleTitle))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleTitle));
                }
            }

            // add remaining claims from input
            foreach (var claim in claims)
            {
                if (!principal.HasClaim(x => x.Type == claim.Type))
                {
                    identity.AddClaim(claim);
                }
            }
            if (!principal.Identities.Any())
                principal.AddIdentity(identity);
        }
    }
}
