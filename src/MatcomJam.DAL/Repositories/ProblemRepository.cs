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
    public class ProblemRepository : Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Problem> GetAllProblems()
        {
            return _appContext.Problems.OrderBy(p => p.Id).ToList();
        }

        public bool SaveProblem(Problem model)
        {
            var problem = _appContext.Problems.Find(model.Id);
            if (problem == null)
            {
                problem = new Problem
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Tag = model.Tag
                };
                _appContext.Problems.Add(problem);
            }
            else
            {
                problem.Id = model.Id;
                problem.Title = model.Title;
                problem.Description = model.Description;
                problem.Tag = model.Tag;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteProblemById(int id)
        {
            var problem = _appContext.Problems.FirstOrDefault(p => p.Id == id);
            if (problem != null)
            {
                _appContext.Problems.Remove(problem);
            }
            return _appContext.SaveChanges() >= 1;
        }

        public Problem GetProblem(int id)
        {
            return _appContext.Problems.FirstOrDefault(p => p.Id == id);
        }
    }
}
