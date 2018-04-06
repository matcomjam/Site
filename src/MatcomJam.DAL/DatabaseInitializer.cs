﻿

using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    Description = "Add integer a to integer b"
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
                    Title = "Bla bla bla"
                };

                Blog b2 = new Blog
                {
                    Title = "Mas babaaaa!!!",
                };

                _context.Blogs.Add(b1);
                _context.Blogs.Add(b2);
                await _context.SaveChangesAsync();
            }

            if (!await _context.Comments.AnyAsync())
            {
                Comment c = new Comment
                {
                    BlogId = 7008,
                    Description = "Acaba de insertarte",
                    UserId = "44065e3e-43d1-4666-b0b6-d4d47c9aba7e"
                };
                _context.Comments.Add(c);
                await _context.SaveChangesAsync();
            }

            #region check
            //if (!await _context.Customers.AnyAsync() && !await _context.ProductCategories.AnyAsync())
            //{
            //    _logger.LogInformation("Seeding initial data");

            //    Customer cust_1 = new Customer
            //    {
            //        Name = "Ebenezer Monney",
            //        Email = "contact@ebenmonney.com",
            //        Gender = Gender.Male,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };

            //    Customer cust_2 = new Customer
            //    {
            //        Name = "Itachi Uchiha",
            //        Email = "uchiha@narutoverse.com",
            //        PhoneNumber = "+81123456789",
            //        Address = "Some fictional Address, Street 123, Konoha",
            //        City = "Konoha",
            //        Gender = Gender.Male,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };

            //    Customer cust_3 = new Customer
            //    {
            //        Name = "John Doe",
            //        Email = "johndoe@anonymous.com",
            //        PhoneNumber = "+18585858",
            //        Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
            //        Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
            //        City = "Lorem Ipsum",
            //        Gender = Gender.Male,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };

            //    Customer cust_4 = new Customer
            //    {
            //        Name = "Jane Doe",
            //        Email = "Janedoe@anonymous.com",
            //        PhoneNumber = "+18585858",
            //        Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
            //        Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
            //        City = "Lorem Ipsum",
            //        Gender = Gender.Male,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };



            //    ProductCategory prodCat_1 = new ProductCategory
            //    {
            //        Name = "None",
            //        Description = "Default category. Products that have not been assigned a category",
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };



            //    Product prod_1 = new Product
            //    {
            //        Name = "BMW M6",
            //        Description = "Yet another masterpiece from the world's best car manufacturer",
            //        BuyingPrice = 109775,
            //        SellingPrice = 114234,
            //        UnitsInStock = 12,
            //        IsActive = true,
            //        ProductCategory = prodCat_1,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };

            //    Product prod_2 = new Product
            //    {
            //        Name = "Nissan Patrol",
            //        Description = "A true man's choice",
            //        BuyingPrice = 78990,
            //        SellingPrice = 86990,
            //        UnitsInStock = 4,
            //        IsActive = true,
            //        ProductCategory = prodCat_1,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow
            //    };



            //    Order ordr_1 = new Order
            //    {
            //        Discount = 500,
            //        Cashier = await _context.Users.FirstAsync(),
            //        Customer = cust_1,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow,
            //        OrderDetails = new List<OrderDetail>()
            //        {
            //            new OrderDetail() {UnitPrice = prod_1.SellingPrice, Quantity=1, Product = prod_1 },
            //            new OrderDetail() {UnitPrice = prod_2.SellingPrice, Quantity=1, Product = prod_2 },
            //        }
            //    };

            //    Order ordr_2 = new Order
            //    {
            //        Cashier = await _context.Users.FirstAsync(),
            //        Customer = cust_2,
            //        DateCreated = DateTime.UtcNow,
            //        DateModified = DateTime.UtcNow,
            //        OrderDetails = new List<OrderDetail>()
            //        {
            //            new OrderDetail() {UnitPrice = prod_2.SellingPrice, Quantity=1, Product = prod_2 },
            //        }
            //    };


            //    _context.Customers.Add(cust_1);
            //    _context.Customers.Add(cust_2);
            //    _context.Customers.Add(cust_3);
            //    _context.Customers.Add(cust_4);

            //    _context.Products.Add(prod_1);
            //    _context.Products.Add(prod_2);

            //    _context.Orders.Add(ordr_1);
            //    _context.Orders.Add(ordr_2);

            //    await _context.SaveChangesAsync();

            //    _logger.LogInformation("Seeding initial data completed");
            //}
            #endregion 
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
