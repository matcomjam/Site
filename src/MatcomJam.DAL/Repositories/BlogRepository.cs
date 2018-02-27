using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MatcomJamDAL.Repositories
{
    class BlogRepository:Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _appContext.Blogs.OrderBy(b => b.Id).ToList();
        }
    }
}
