using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using MatcomJamDAL.Models.MyModel;
using MatcomJamDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class SyncServerRepository : Repository<SyncServer>, ISyncServerRepository
    {
        public SyncServerRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<SyncServer> GetAllSyncServers()
        {
            throw new NotImplementedException();
        }

        public bool SaveSyncServer(SyncServer model)
        {
            var sync = _appContext.SyncServers.Find(model.Id);
            if (sync == null)
            {
                sync = new SyncServer()
                {
                    Id = model.Id,
                    Ip = model.Ip,
                    Port = model.Port,
                    Name = model.Name,
                    URL_Get = model.URL_Get,
                    URL_Post = model.URL_Post
                };
                _appContext.SyncServers.Add(sync);
            }
            else
            {
                sync.Ip = model.Ip;
                sync.Port = model.Port;
                sync.Name = model.Name;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteSyncServerById(int id)
        {
            throw new NotImplementedException();
        }

        public SyncServer GetSyncServer(int id)
        {
            var r = new Random();
            var syncList = _appContext.SyncServers.ToList();
            //cambiar a un metodo
            int index = r.Next(syncList.Count);
            return syncList[index];
        }

        public int GetSyncServerCount(Filter filter)
        {
            throw new NotImplementedException();
        }
    }
}
