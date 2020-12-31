using AspNetCore_Samples.Classes;
using AspNetCore_Samples.Data;
using AspNetCore_Samples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AspNetCore_Samples.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserManager(IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider serviceProvider,
            ILogger<UserManager<ApplicationUser>> logger,
            ApplicationDbContext context)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, serviceProvider, logger)
        {
            _context = context;
        }

        public string GetFullName(ClaimsPrincipal principal)
        {
            if (principal.Claims.Any(c => c.Type == Constants.ClaimTypes.Name))
            {
                return principal.Claims.Single(c => c.Type == Constants.ClaimTypes.Name).Value;
            }
            return string.Empty;
        }

        public DateTime GetNextRefreshUtc(ClaimsPrincipal principal)
        {
            DateTime nextRefreshUtc = DateTime.Now;
            if (principal.Claims.Any(c => c.Type == Constants.ClaimTypes.NextRefreshUtc))
            {
                nextRefreshUtc = Convert.ToDateTime(principal.Claims.Single(c => c.Type == Constants.ClaimTypes.NextRefreshUtc).Value);
            }
            return nextRefreshUtc;
        }
    }
}
