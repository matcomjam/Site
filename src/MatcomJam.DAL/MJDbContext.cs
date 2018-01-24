using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabase
{
    public class MJDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
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

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTeams)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserTeam>()
                .HasKey(ut => new { ut.UserId, ut.TeamID });

            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(ut => ut.TeamID);

            modelBuilder.Entity<Solution>()
                .HasOne(pcl => pcl.Contestant)
                .WithMany(c => c.Solutions)
                .HasForeignKey(pcl => pcl.ContestantId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solution>()
                .HasKey(pcl => new {pcl.ContestantId, pcl.LanguageId, pcl.ProblemContestId});

            modelBuilder.Entity<Solution>()
                .HasOne(pcl => pcl.Language)
                .WithMany(l => l.Solutions)
                .HasForeignKey(pcl => pcl.LanguageId);

            modelBuilder.Entity<Solution>()
                .HasOne(pcl => pcl.ProblemContest)
                .WithMany(p => p.Solutions)
                .HasForeignKey(pcl => pcl.ProblemContestId);

            modelBuilder.Entity<Comment>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(bu => bu.UserId)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasKey(bu => new {bu.UserId, bu.BlogId});

            modelBuilder.Entity<Comment>()
                .HasOne(bu => bu.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(bu => bu.BlogId);

            // TODO: Add some code here
        }
    }
}
