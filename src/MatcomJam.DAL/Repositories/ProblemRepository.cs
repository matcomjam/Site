using System.Collections.Generic;
using System.Linq;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using MatcomJamDAL.Models.MyModel;
using Microsoft.EntityFrameworkCore;

namespace MatcomJamDAL.Repositories
{
    public class ProblemRepository : Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Problem> GetAllProblems(Filter filter, int page, int limit)
        {
            ////var aux = _appContext.Problems.OrderBy(b => b.Id).Where(b=> b.Title)
            //return filter != null
            //    ? _appContext.Problems.Where(p => Search(filter.Pattern, p)).OrderBy(b => b.Id)
            //        .Skip((page - 1) * limit).Take(limit).ToList()
            //    : _appContext.Problems.OrderBy(b => b.Id).Skip((page - 1) * limit).Take(limit).ToList();

            return _appContext.Problems.Where(p => Search(filter, p)).OrderBy(p => p.Id)
                .Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool Search(Filter filter, Problem p)
        {
            if (string.IsNullOrEmpty(filter?.Pattern)) return true;
            var query = filter.Pattern.ToLower();
            return p.Id.ToString().ToLower().IndexOf(query) != -1 ||
                p.Title.ToLower().IndexOf(query) != -1 ||
                   p.Tag.ToLower().IndexOf(query) != -1;
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

        public int GetProblemCount(Filter filter)
        {
            return _appContext.Problems.Count(p => Search(filter, p));
        }
    }
}
