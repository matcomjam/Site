using System.Collections.Generic;
using CodeFirstDatabase;
using MatcomJamDAL.Models.MyModel;

namespace DAL.Repositories.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetAllBlogs(Filter filter, int page = 1, int limit = 4);
        bool SaveBlog(Blog blog);
        bool DeleteBlog(int blog);
        Blog GetBlog(int d);
        int GetBlogCount(Filter filter);
    }
}