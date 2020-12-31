using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Samples.Classes
{
    public class Constants
    {
        public static class ClaimTypes
        {
            public const string Name = "ClaimTypes.Name";
            public const string NextRefreshUtc = "ClaimTypes.NextRefreshUtc";
        }

        public static class AuthorizationPolicies
        {
            public const string RefreshAuthRequirement = "AuthorizationPolicies.RefreshAuthRequirement";
        }
    }
}
