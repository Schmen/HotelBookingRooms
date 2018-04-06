using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelBookingRooms.DAL.EF
{
    public static class Seed
    {
        public static void RunSeed(DbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            // Seed operations
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                Role role = new Role();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync ("Worker").Result)
            {
                Role role = new Role();
                role.Name = "Worker";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                
            }

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                Role role = new Role();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;

            }
        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                User user = new User();
                user.UserName = "Admin";
                user.Email = "Admin@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Admin@localhost").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }


            if (userManager.FindByNameAsync("Worker").Result == null)
            {
                User user = new User();
                user.UserName = "Worker";
                user.Email = "Worker@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Worker@localhost").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Worker").Wait();
                }
            }

            if (userManager.FindByNameAsync("User").Result == null)
            {
                User user = new User();
                user.UserName = "User";
                user.Email = "User@localhost";

                IdentityResult result = userManager.CreateAsync(user, "User@localhost").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
    }
}
