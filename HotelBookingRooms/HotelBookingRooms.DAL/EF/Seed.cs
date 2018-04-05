using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingRooms.DAL.EF
{
    public static class Seed
    {
        public static void RunSeed(DbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            // Seed operations
            SeedRoles(roleManager);
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

    }
}
