using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingRooms.DAL.EF
{
    public static class Seed
    {
        public static void RunSeed(ApplicationDbContext<User, Role, int> context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            // Seed operations
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedStatusses(context);
            SeedHotels(context);
            SeedRoomTypes(context);
            SeedRooms(context);
        }

        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                Role role = new Role();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Worker").Result)
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
                    userManager.AddToRoleAsync(user, "Worker").Wait();
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

        public static void SeedStatusses(ApplicationDbContext<User, Role, int> context)
        {
            if(context.Status.Any(r => r.Name == "Booked") == false)
            {
                context.Status.Add(new Status() { Name = "Booked" });
            }
            if (context.Status.Any(r => r.Name == "Cancelled") == false)
            {
                context.Status.Add(new Status() { Name = "Cancelled" });
            }
            if (context.Status.Any(r => r.Name == "Expected") == false)
            {
                context.Status.Add(new Status() { Name = "Expected" });
            }
            context.SaveChanges();
        }

        public static void SeedHotels(ApplicationDbContext<User, Role, int> context)
        {
            if (context.Hotel.Any(r => r.Name == "Hotel1") == false)
            {
                context.Hotel.Add(new Hotel() { Name = "Hotel1" });
            }
            if (context.Hotel.Any(r => r.Name == "Hotel2") == false)
            {
                context.Hotel.Add(new Hotel() { Name = "Hotel2" });
            }
            if (context.Hotel.Any(r => r.Name == "Hotel3") == false)
            {
                context.Hotel.Add(new Hotel() { Name = "Hotel3" });
            }
            context.SaveChanges();
        }

        public static void SeedRoomTypes(ApplicationDbContext<User, Role, int> context)
        {
            ////If there is already any date of RoomType
            if (context.RoomType.Any()) return;
            List<RoomType> roomTypes = new List<RoomType>()
            {
                // each RoomType belongs to the specified hotel
                new RoomType(){Name="Single", Description = "Room for one person with single bed", HotelId = 1, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250,  NumberOfBeds = 1, NumberOfPeople = 1 },
                new RoomType(){Name="Twin for sole us", Description = "Room for one person with two beds", HotelId = 1, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300,  NumberOfBeds = 2, NumberOfPeople = 1 }, 
                new RoomType(){Name="Double Room", Description = "Room for two people with one bed", HotelId = 1, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400,   NumberOfBeds = 1, NumberOfPeople = 2 },
                new RoomType(){Name="Triple", Description = "Room for three people with three single beds", HotelId = 1, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450,  NumberOfBeds = 3, NumberOfPeople = 3 }, 
                new RoomType(){Name="Quad", Description = "Room for four people with four single beds", HotelId = 1, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500,  NumberOfBeds = 4, NumberOfPeople = 4 },

                new RoomType(){Name="Single", Description = "Room for one person with single bed", HotelId = 2, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250,  NumberOfBeds = 1, NumberOfPeople = 1 },
                new RoomType(){Name="Twin for sole us", Description = "Room for one person with two beds", HotelId = 2, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300,  NumberOfBeds = 2, NumberOfPeople = 1 },
                new RoomType(){Name="Double Room", Description = "Room for two people with one bed", HotelId = 2, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400,   NumberOfBeds = 1, NumberOfPeople = 2 },
                new RoomType(){Name="Triple", Description = "Room for three people with three single beds", HotelId = 2, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450,  NumberOfBeds = 3, NumberOfPeople = 3 },
                new RoomType(){Name="Quad", Description = "Room for four people with four single beds", HotelId = 2, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500,  NumberOfBeds = 4, NumberOfPeople = 4 },

                new RoomType(){Name="Single", Description = "Room for one person with single bed", HotelId = 3, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250,  NumberOfBeds = 1, NumberOfPeople = 1 },
                new RoomType(){Name="Twin for sole us", Description = "Room for one person with two beds", HotelId = 3, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300,  NumberOfBeds = 2, NumberOfPeople = 1 },
                new RoomType(){Name="Double Room", Description = "Room for two people with one bed", HotelId = 3, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400,   NumberOfBeds = 1, NumberOfPeople = 2 },
                new RoomType(){Name="Triple", Description = "Room for three people with three single beds", HotelId = 3, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450,  NumberOfBeds = 3, NumberOfPeople = 3 },
                new RoomType(){Name="Quad", Description = "Room for four people with four single beds", HotelId = 3, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500,  NumberOfBeds = 4, NumberOfPeople = 4 },
            };
            foreach (var roomType in roomTypes)
            {
                context.Add(roomType);
            }
            context.SaveChanges();
        }

        public static void SeedRooms(ApplicationDbContext<User, Role, int> context)
        {
            if (context.Room.Any()) return;
            List<Room> rooms = new List<Room>()
            {
                new Room(){RoomNumber = 1, FloorNumber = 0, RoomTypeID = 1},
                new Room(){RoomNumber = 2, FloorNumber = 0, RoomTypeID = 2},
                new Room(){RoomNumber = 3, FloorNumber = 1, RoomTypeID = 3},
                new Room(){RoomNumber = 4, FloorNumber = 1, RoomTypeID = 4},
                new Room(){RoomNumber = 5, FloorNumber = 1, RoomTypeID = 5},

                new Room(){RoomNumber = 1, FloorNumber = 0, RoomTypeID = 6},
                new Room(){RoomNumber = 2, FloorNumber = 0, RoomTypeID = 7},
                new Room(){RoomNumber = 3, FloorNumber = 1, RoomTypeID = 8},
                new Room(){RoomNumber = 4, FloorNumber = 1, RoomTypeID = 9},
                new Room(){RoomNumber = 5, FloorNumber = 1, RoomTypeID = 10},

                new Room(){RoomNumber = 1, FloorNumber = 0, RoomTypeID = 11},
                new Room(){RoomNumber = 2, FloorNumber = 0, RoomTypeID = 12},
                new Room(){RoomNumber = 3, FloorNumber = 1, RoomTypeID = 13},
                new Room(){RoomNumber = 4, FloorNumber = 1, RoomTypeID = 14},
                new Room(){RoomNumber = 5, FloorNumber = 1, RoomTypeID = 15},
            };
            foreach (var room in rooms)
            {
                context.Add(room);
            }
            context.SaveChanges();
        }


    }
}
