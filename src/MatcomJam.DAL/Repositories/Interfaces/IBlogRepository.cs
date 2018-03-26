using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetAllBlogs(int page = 1, int limit = 4);
        bool SaveBlog(Blog blog);
        bool DeleteBlog(int blog);
        Blog GetBlog(int d);
        int GetBlogCount();
    }
}