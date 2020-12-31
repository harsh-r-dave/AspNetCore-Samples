using AspNetCore_Samples.Classes;
using AspNetCore_Samples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCore_Samples.Factories
{
    // https://levelup.gitconnected.com/add-extra-user-claims-in-asp-net-core-web-applications-1f28c98c9ec6
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public AppClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
        IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
            // use DI to access custom services
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim(Constants.ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
            return principal;
        }
    }
}