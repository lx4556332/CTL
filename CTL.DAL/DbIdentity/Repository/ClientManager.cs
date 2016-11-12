using CTL.DAL.DbIdentity.Entity;
using CTL.DAL.DbIdentity.Interfaces;

namespace CTL.DAL.DbIdentity.Repository
{
    public class ClientManager : IClientManager
    {
        public IdentityContext Database { get; set; }

        public ClientManager(IdentityContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
