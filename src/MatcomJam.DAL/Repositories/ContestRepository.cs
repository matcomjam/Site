using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MatcomJamDAL.Repositories
{
    class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Contest> GetAllContests()
        {
            return _appContext.Contests.OrderBy(c => c.ContestId).ToList();
        }
    }
}
