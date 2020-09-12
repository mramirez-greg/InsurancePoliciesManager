using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gap.IPM.Infrastructure.Identity
{
    public class ApplicationIndentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
      
        public ApplicationIndentityDbContext(
            DbContextOptions<ApplicationIndentityDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions): base(options, operationalStoreOptions)
        {           
        }

    }
}
