using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    class BlogRepository:Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

    }
}
