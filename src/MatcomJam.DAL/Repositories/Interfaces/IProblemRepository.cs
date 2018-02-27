using System.Collections;
using System.Collections.Generic;
using CodeFirstDatabase;

namespace DAL.Repositories.Interfaces
{
    public interface IProblemRepository:IRepository<Problem>
    {
        IEnumerable<Problem> GetAllProblems();
    }
}