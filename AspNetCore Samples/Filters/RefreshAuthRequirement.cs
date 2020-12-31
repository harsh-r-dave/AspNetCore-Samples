using Microsoft.AspNetCore.Authorization;

namespace AspNetCore_Samples.Filters
{
    public class RefreshAuthRequirement : IAuthorizationRequirement
    {
        public RefreshAuthRequirement()
        {

        }
    }
}
