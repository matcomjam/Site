using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.Interfaces;
using CodeFirstDatabase;
using MatcomJamDAL.Models.MyModel;

namespace DAL
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }




    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly MJDbContext _context;
        private readonly IAccountManager _accountManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(MJDbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
        {
            _accountManager = accountManager;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts");

                const string adminRoleName = "administrator";
                const string userRoleName = "user";

                await EnsureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
                await EnsureRoleAsync(userRoleName, "Default user", new string[] { });

                await CreateUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "admin@ebenmonney.com", "+1 (123) 000-0000", new string[] { adminRoleName });
                await CreateUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "user@ebenmonney.com", "+1 (123) 000-0001", new string[] { userRoleName });

                _logger.LogInformation("Inbuilt account generation completed");
            }

            if (!await _context.Problems.AnyAsync())
            {
                Problem p1 = new Problem
                {
                    Title = "A + B",
                    Tag = "Ad-Hoc",
                    Description = "<b>Add</b> integer a to integer b",
                    MemoryLimit = 20,
                    TimeLimit = 1
                };

                Problem p2 = new Problem
                {
                    Title = "Hello World",
                    Tag = "Ad-Hoc",
                    Description = "Print Hello World"
                };

                _context.Problems.Add(p1);
                _context.Problems.Add(p2);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }

            if (!await _context.Contests.AnyAsync())
            {
                Contest c1 = new Contest
                {
                    Title = "Copa Matcom 2017-2018",
                    Description = "Se hara por equipos etc etc"
                };

                Contest c2 = new Contest
                {
                    Title = "Clasificatorias para Concurso Local ACM-ICPC 2017-2018",
                    Description = "Se hara individual etc etc"
                };

                _context.Contests.Add(c1);
                _context.Contests.Add(c2);
                await _context.SaveChangesAsync();
            }

            if (!await _context.Blogs.AnyAsync())
            {
                Blog b1 = new Blog
                {
                    Title = "Tutorial A+B ",
                    Description = "esta es la descripción de <b>A + B</b>"
                };

                Blog b2 = new Blog
                {
                    Title = "Otro Tutorial",
                };

                _context.Blogs.Add(b1);
                _context.Blogs.Add(b2);
                await _context.SaveChangesAsync();
            }

            if (!await _context.Languages.AnyAsync())
            {
                var l1 = new Language
                {
                    Name = "CSHARP"
                };
                var l2 = new Language
                {
                    Name = "PYTHON"
                };

                _context.Languages.Add(l1);
                _context.Languages.Add(l2);
                await _context.SaveChangesAsync();
            }

            _logger.LogInformation("Seeding initial data completed");
        }



        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
            {
                ApplicationRole applicationRole = new ApplicationRole(roleName, description);

                var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

                if (!result.Item1)
                    throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");
            }
        }

        private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

            if (!result.Item1)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");


            return applicationUser;
        }
    }
}
