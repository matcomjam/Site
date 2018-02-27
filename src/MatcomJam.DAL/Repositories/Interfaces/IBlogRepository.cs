using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> GetAllBlogs();
    }
}