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

        public bool SaveBlog(Blog model)
        {
            var blog = _appContext.Blogs.Find(model.Id);
            if (blog == null)
            {
                blog = new Blog
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                };
                _appContext.Blogs.Add(blog);
            }
            else
            {
                blog.Id = model.Id;
                blog.Title = model.Title;
                blog.Description = model.Description;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteBlog(int id)
        {
            var blog = _appContext.Blogs.FirstOrDefault(p => p.Id == id);
            if (blog != null)
            {
                _appContext.Blogs.Remove(blog);
            }
            return _appContext.SaveChanges() >= 1;
        }

        public Blog GetBlog(int id)
        {
            return _appContext.Blogs.FirstOrDefault(p => p.Id == id);
        }
    }
}
