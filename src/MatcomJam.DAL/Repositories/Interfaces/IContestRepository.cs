using System.Collections;
using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IContestRepository:IRepository<Contest>
    {
        IEnumerable<Contest> GetAllContests(int offset = 1, int limit = 4);
        bool SaveContest(Contest contest);
        bool DeleteContestById(int id);
        Contest GetContest(int id);
        int GetContestCount();
    }
}