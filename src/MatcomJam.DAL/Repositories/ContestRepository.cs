using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CodeFirstDatabase;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MatcomJamDAL.Repositories
{
    class ContestRepository:Repository<Contest>, IContestRepository
    {
        public ContestRepository(DbContext context) : base(context)
        {
        }
        private MJDbContext _appContext => (MJDbContext)_context;

        public IEnumerable<Contest> GetAllContests(int page, int limit)
        {
            return _appContext.Contests.OrderBy(b => b.ContestId).Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool SaveContest(Contest model)
        {
            var contest = _appContext.Contests.Find(model.ContestId);
            if (contest == null)
            {
                contest = new Contest
                {
                    ContestId = model.ContestId,
                    Title = model.Title,
                    Description = model.Description,
                    Duration = model.Duration
                };
                _appContext.Contests.Add(contest);
            }
            else
            {
                contest.ContestId = model.ContestId;
                contest.Title = model.Title;
                contest.Description = model.Description;
                contest.Duration = model.Duration;
            }
            return _appContext.SaveChanges() >= 1;
        }

        public bool DeleteContestById(int id)
        {
            var contest = _appContext.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest != null)
            {
                _appContext.Contests.Remove(contest);
            }
            return _appContext.SaveChanges() >= 1;
        }

        public Contest GetContest(int id)
        {
            return _appContext.Contests.FirstOrDefault(c => c.ContestId == id);
        }

        public int GetContestCount()
        {
            return _appContext.Contests.Count();
        }
    }
}
