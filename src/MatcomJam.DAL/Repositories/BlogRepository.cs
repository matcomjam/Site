using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using MatcomJamDAL.Models.MyModel;

namespace MatcomJamDAL.Repositories
{
    class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(DbContext context) : base(context)
        { }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Blog> GetAllBlogs(Filter filter, int page, int limit)
        {
            //return _appContext.Blogs.OrderBy(b => b.Id).Skip((page - 1) * limit).Take(limit).ToList();
            return _appContext.Blogs.Where(b => Search(filter, b)).OrderBy(b => b.Id).Skip((page - 1) * limit).Take(limit).ToList();
        }

        bool Search(Filter filter, Blog b)
        {
            if (string.IsNullOrEmpty(filter?.Pattern)) return true;
            var query = filter.Pattern.ToLower();
            return b.Id.ToString().ToLower().IndexOf(query) != -1 ||
                   b.Title.ToLower().IndexOf(query) != -1 ||
                   b.Description.ToLower().IndexOf(query) != -1 ||
                   b.UserName.ToLower().IndexOf(query) != -1;
        }

        public int GetBlogCount(Filter filter)
        {
            return _appContext.Blogs.Count(b => Search(filter, b));
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
                    UserId = model.UserId,
                    UserName = model.UserName
                };
                try
                {
                    _appContext.Blogs.Add(blog);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
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
