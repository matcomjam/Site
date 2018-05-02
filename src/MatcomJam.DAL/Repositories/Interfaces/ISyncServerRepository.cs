using System.Collections.Generic;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories.Interfaces
{
    public interface ISyncServerRepository
    {
        IEnumerable<SyncServer> GetAllSyncServers();
        bool SaveSyncServer(SyncServer model);
        bool DeleteSyncServerById(int id);
        SyncServer GetSyncServer(int id);
        int GetSyncServerCount(Filter filter);
    }
}
