using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    public class ProblemRepository: Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext) _context;

        public IEnumerable<Problem> GetAllProblems()
        {
            return _appContext.Problems.OrderBy(p => p.Id).ToList();
        }
    }
}
