using Microsoft.AspNet.Identity.EntityFramework;

namespace CTL.DAL.DbIdentity.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
