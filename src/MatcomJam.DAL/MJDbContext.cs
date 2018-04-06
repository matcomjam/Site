using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;
using MatcomJamDAL.Models.MyModel;
using MatcomJamDAL.Models.MyModel.interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabase
{
    public class MJDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }

        //public DbSet<User> Users { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<ProblemContest> ProblemContests { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Code> Codes { get; set; }

        public MJDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

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
                .HasKey(pcl => new { pcl.ContestantId, pcl.LanguageId, pcl.ProblemContestId });

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
                .HasKey(ci => ci.Id); 

            modelBuilder.Entity<Comment>()
                .HasOne(bu => bu.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(bu => bu.BlogId);

            // TODO: Add some code here
        }

        //public override int SaveChanges()
        //{
        //    UpdateAuditEntities();
        //    return base.SaveChanges();
        //}


        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    UpdateAuditEntities();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}


        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    UpdateAuditEntities();
        //    return base.SaveChangesAsync(cancellationToken);
        //}


        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    UpdateAuditEntities();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}


        //private void UpdateAuditEntities()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


        //    foreach (var entry in modifiedEntries)
        //    {
        //        var entity = (IAuditableEntity)entry.Entity;
        //        DateTime now = DateTime.UtcNow;

        //        if (entry.State == EntityState.Added)
        //        {
        //            entity.CreatedDate = now;
        //            entity.CreatedBy = CurrentUserId;
        //        }
        //        else
        //        {
        //            base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //            base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //        }

        //        entity.UpdatedDate = now;
        //        entity.UpdatedBy = CurrentUserId;
        //    }
        //}
    }
}
