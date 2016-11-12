using CTL.DAL.DbIdentity.Entity;
using System;

namespace CTL.DAL.DbIdentity.Interfaces
{
    public interface IClientManager: IDisposable
    {
        void Create(ClientProfile item);
    }
}
