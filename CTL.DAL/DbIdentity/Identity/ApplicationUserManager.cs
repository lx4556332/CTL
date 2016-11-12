using CTL.DAL.DbIdentity.Entity;
using Microsoft.AspNet.Identity;

namespace CTL.DAL.DbIdentity.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}
