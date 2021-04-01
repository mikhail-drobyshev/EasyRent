using System;
using System.Collections.Generic;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.AppDataInit
{
    public static class DataInit
    {

        public static void DropDatabase(AppDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
        }

        public static void MigrateDatabase(AppDbContext ctx)
        {
            ctx.Database.Migrate();
        }
        
        // public static void SeedAppData(AppDbContext ctx)
        // {
        //     var ptypeFlat = new PropertyType()
        //     {
        //         PropertyTypeValue = "Flat"
        //     };
        //     var ptypeHouse = new PropertyType()
        //     {
        //         PropertyTypeValue = "House"
        //     };
        //     var ptypeShare = new PropertyType()
        //     {
        //         PropertyTypeValue = "PropertyShare"
        //     };
        //     
        //     
        //     ctx.SaveChanges();
        // }

        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var role = new AppRole();
            role.Name = "Admin";
            var res = roleManager.CreateAsync(role).Result;
            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    Console.WriteLine($"Role is not created {error.Description}");

                }
            }

            var user = new AppUser();
            user.Email = "admin@midrob.com";
            user.Firstname = "Mikhail";
            user.Lastname = "Drobyshev";
            user.UserName = user.Email;
            res = userManager.CreateAsync(user, "!23Qwe").Result;
            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    Console.WriteLine($"User is not created {error.Description}");

                }
            }

            res = userManager.AddToRoleAsync(user, "Admin").Result;
            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    Console.WriteLine($"User is not created {error.Description}");

                }
            }

            res = userManager.UpdateAsync(user).Result;
            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                {
                    Console.WriteLine($"User is not created {error.Description}");

                }
            }
        }
        
    }
}