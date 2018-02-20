using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

    }
}
