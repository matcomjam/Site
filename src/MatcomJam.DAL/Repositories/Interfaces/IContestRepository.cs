using System.Collections;
using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IContestRepository:IRepository<Contest>
    {
        IEnumerable<Contest> GetAllContests();
    }
}