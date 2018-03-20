using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetAllBlogs();
        bool SaveBlog(Blog blog);
        bool DeleteBlog(int blog);
        Blog GetBlog(int d);
    }
}