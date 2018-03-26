using System.Collections;
using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IProblemRepository:IRepository<Problem>
    {
        IEnumerable<Problem> GetAllProblems(int page = 1, int limit = 4);
        bool SaveProblem(Problem model);
        bool DeleteProblemById(int id);
        Problem GetProblem(int id);
        int GetProblemCount();
    }
}