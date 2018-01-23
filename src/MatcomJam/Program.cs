// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuickApp.Helpers;
using DAL;
using CodeFirstDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuickApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddJsonFile("appsettings.Development.json", optional: true)
            //    .Build();

            //var builder = new DbContextOptionsBuilder<MJDbContext>();

            //builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("MatcomJam"));
            //builder.UseOpenIddict();


            //var db = new MJDbContext(builder.Options);
            //return new ApplicationDbContext(builder.Options);
           



            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var databaseInitializer = services.GetRequiredService<IDatabaseInitializer>();
                    databaseInitializer.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogCritical(LoggingEvents.INIT_DATABASE, ex, LoggingEvents.INIT_DATABASE.Name);
                }
            }

            //using (var db = new MJDbContext(builder.Options))
            //{
            //    var user = new User { Name = "jose", Email = "jcarlos.mtnz@gmail.com" };

            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

            host.Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
