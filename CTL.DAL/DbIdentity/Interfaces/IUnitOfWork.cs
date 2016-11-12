using CTL.DAL.DbIdentity.Identity;
using CTL.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CTL.DAL.DbIdentity.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }

        Task SaveAsync();
    }
}
