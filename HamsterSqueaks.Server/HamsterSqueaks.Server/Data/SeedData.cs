using HamsterSqueaks.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Data
{
    /// <summary>
    /// Used for seeding the database. See Curabis for inspiration.
    /// </summary>
    public class SeedData
    {
        //public static void Initialize(IServiceProvider serviceProvider, HamsterSqueaksDbContext dbContext, UserManager<HamsterSqueaksUser> userManager, RoleManager<ApplicationRole> roleManager)
        //{
        //    // ====================
        //    // Automatic migration
        //    // ====================
        //    dbContext.Database.Migrate();

        //    // ====================
        //    // Role seeds
        //    // ====================
        //    using (roleManager)
        //    {
        //        foreach (var roleName in CurabisRoles.Roles.Where(x => !roleManager.RoleExistsAsync(x).Result))
        //        {
        //            roleManager.CreateAsync(new ApplicationRole { Name = roleName }).Wait();
        //        }
        //    }

        //    // ====================
        //    // User seeds
        //    // ====================
        //    var user1 = new HamsterSqueaksUser { UserName = "martin_hammer@live.dk", Email = "martin_hammer@live.dk", EmailConfirmed = true };
        //    using (userManager)
        //    {
        //        if (!userManager.Users.Any())
        //        {
        //            userManager.CreateAsync(user1, "Password123!").Wait();
        //            userManager.AddToRoleAsync(user1, "admin").Wait();
        //        }
        //    }
        //}
    }
}
