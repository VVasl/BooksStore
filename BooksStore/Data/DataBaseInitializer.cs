using BooksStore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class DataBaseInitializer
    {
        //UserManager<StoreUser> userManager;
        //RoleManager<IdentityRole> roleManager;
        //BooksStoreContext appContext;

        //public DataBaseInitializer(UserManager<StoreUser> _userManager, RoleManager<IdentityRole> _roleManager,
        //    BooksStoreContext _appContext)
        //{
        //    userManager = _userManager;
        //    roleManager = _roleManager;
        //    appContext = _appContext;
        //}

        //public static async Task InitializeAsync(UserManager<StoreUser> userManager, RoleManager<IdentityRole> roleManager,
        //  BooksStoreContext appContext)
        //{
        //    //public async Task InitializeAsync()
        //    //{
        //    BooksStoreContext appDbContext = appContext;
        //    string adminEmail = "administrator123@gmail.com";
        //    string adminPassword = "Admin123";

        //    if (await roleManager.FindByNameAsync("admin") == null)
        //    {
                
        //        await roleManager.CreateAsync(new IdentityRole("admin"));
        //    }

        //    if (await roleManager.FindByNameAsync("customer") == null)
        //    {
        //        await roleManager.CreateAsync(new IdentityRole("customer"));
        //    }
            
        //    if (await userManager.FindByNameAsync(adminEmail) == null)
        //    {
        //        StoreUser admin = new StoreUser()
        //        {
        //            FirstName = "Vika",
        //            LastName ="Vasl",
        //            Email = adminEmail,
        //            UserName = adminEmail
        //        };
        //        IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(admin, "admin");
        //        }
        //        if (result != IdentityResult.Success)
        //        {
        //            throw new InvalidOperationException("Could not create user in Seeding");
        //        }
        //    }
        //    appContext.SaveChanges();
        //}

        public static async Task SeedData(UserManager<StoreUser> userManager, RoleManager<IdentityRole> roleManager, BooksStoreContext ctx)
        {
            SeedRoles(roleManager);
            await SeedUsersAsync(userManager, ctx);
        }

        private static async Task SeedUsersAsync(UserManager<StoreUser> userManager, BooksStoreContext ctx)
        {
            string adminEmail = "administrator13@gmail.com";
            string adminPassword = "Admin13";
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                StoreUser admin = new StoreUser()
                {
                    FirstName = "Viktoriia",
                    LastName = "Vasyltsiv",
                    Email = adminEmail,
                    UserName = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    NormalizedUserName = adminEmail.ToUpper()
            };

                IdentityResult result = userManager.CreateAsync(admin, adminPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }

                if (!ctx.Users.Any(u => u.UserName == admin.UserName))
                {
                    var password = new PasswordHasher<StoreUser>();
                    var hashed = password.HashPassword(admin, adminPassword);
                    admin.PasswordHash = hashed;
                    var userStore = new UserStore<StoreUser>(ctx);
                    await userStore.CreateAsync(admin);
                    await userStore.AddToRoleAsync(admin, "Admin");
                }
            }

            string userEmail = "user1@gmail.com";
            string userPassword = "User1";

            if ( userManager.FindByEmailAsync(userEmail).Result == null)
            {
                StoreUser user = new StoreUser()
                {
                    FirstName = "Vika",
                    LastName = "Vasl",
                    Email = userEmail,
                    UserName = userEmail,
                    NormalizedEmail = userEmail.ToUpper(),
                    NormalizedUserName = userEmail.ToUpper()
                };

                IdentityResult result = userManager.CreateAsync(user, userPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }



                if (!ctx.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<StoreUser>();
                    var hashed = password.HashPassword(user, "password");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<StoreUser>(ctx);
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "User");
                }
            }

            ctx.SaveChanges();
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
