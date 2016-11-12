using CTL.DAL.DbIdentity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CTL.DAL
{
    public class IdentityContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(string conectionString): base(conectionString)
        {

        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
