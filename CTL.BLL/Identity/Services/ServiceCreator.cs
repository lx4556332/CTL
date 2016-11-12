using CTL.BLL.Identity.Interfaces;
using CTL.DAL.DbIdentity.Repository;

namespace CTL.BLL.Identity.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
