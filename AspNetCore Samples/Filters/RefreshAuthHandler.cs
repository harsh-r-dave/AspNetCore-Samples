using AspNetCore_Samples.Models;
using AspNetCore_Samples.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AspNetCore_Samples.Filters
{
    public class RefreshAuthHandler : AuthorizationHandler<RefreshAuthRequirement>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RefreshAuthHandler(ApplicationUserManager userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RefreshAuthRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            var userTask = _userManager.GetUserAsync(context.User);
            var user = userTask.Result;

            DateTime refreshUtc = _userManager.GetNextRefreshUtc(context.User);
            if (refreshUtc <= DateTime.UtcNow)
            {
                var refreshTask = _signInManager.RefreshSignInAsync(user);
                refreshTask.Wait();

                var claimsTask = _signInManager.CreateUserPrincipalAsync(user);
                var httpContext = _httpContextAccessor.HttpContext;
                httpContext.User = claimsTask.Result;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
