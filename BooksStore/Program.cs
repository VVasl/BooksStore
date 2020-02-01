using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data;
using BooksStore.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BooksStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<StoreUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var appDbContext = services.GetRequiredService<BooksStoreContext>();
                    DataBaseInitializer.SeedData(userManager, rolesManager, appDbContext).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }


        //private static void SeedDb(IWebHost host)
        //{
        //    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
        //        seeder.SeedAsync().Wait();
        //    }
        //}


        //public static void Main(string[] args)
        //{
        //    var host = CreateHostBuilder(args).Build();

        //    SeedDb(host);

        //    host.Run();
        //}

        //private static void SeedDb(IHost host)
        //{
        //    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var seeder = scope.ServiceProvider.GetService<DataBaseInitializer>();

        //        seeder.InitializeAsync().Wait();
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
