using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class SolutionRepository:Repository<Solution>, ISolutionRepository
    {
        public SolutionRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

    }
}
