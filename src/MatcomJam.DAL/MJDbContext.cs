using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabase
{
    class MJDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<ProblemContest> ProblemContests { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Language> Languages { get; set; }

        public MJDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: Add some code here
        }
    }
}
