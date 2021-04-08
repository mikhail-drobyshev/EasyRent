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
        
        public static void SeedAppData(AppDbContext ctx)
        {
            var ctypeFlat = new PropertyType()
            {
                PropertyTypeValue = "Flat"
            };
            var ctypeHouse = new PropertyType()
            {
                PropertyTypeValue = "House"
            };
            var ctypeShare = new PropertyType()
            {
                PropertyTypeValue = "FlatShare"
            };
            var genderMale = new Gender()
            {
                GenderValue = "Male"
            };
            var genderFemale = new Gender()
            {
                GenderValue = "Female"
            };
            var genderOther = new Gender()
            {
                GenderValue = "Other"
            };


            ctx.PropertyTypes.Add(ctypeFlat);
            ctx.PropertyTypes.Add(ctypeHouse);
            ctx.PropertyTypes.Add(ctypeShare);
            ctx.Genders.Add(genderMale);
            ctx.Genders.Add(genderFemale);
            ctx.Genders.Add(genderOther);

            ctx.SaveChanges();
        }


        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>();
            var role = new AppRole {Name = "Admin"};
            roles.Add(role);
            role = new AppRole {Name = "Host"};
            roles.Add(role);
            role = new AppRole {Name = "Tenant"};
            roles.Add(role);
            IdentityResult res;
            foreach (var userRole in roles)
            {
                res = roleManager.CreateAsync(userRole).Result;
                if (!res.Succeeded)
                {
                    foreach (var error in res.Errors)
                    {
                        Console.WriteLine($"Role is not created {error.Description}");
            
                    }
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