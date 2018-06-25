using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
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
            SeedReservations(context);
        }

        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Annonymous").Result)
            {
                Role role = new Role();
                role.Name = "Annonymous";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

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
            if (userManager.FindByNameAsync("Annonymous").Result == null)
            {
                User user = new User();
                user.UserName = "Annonymous";
                user.Email = "Annonymous@localhost";

                IdentityResult result = userManager.CreateAsync(user, "Admin@localhost").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Annonymous").Wait();
                }
            }

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
                new RoomType(){Name="Dormitory", Description = "Room for ten people with ten single beds", HotelId = 4, Area = "120 m2", PriceStandardNumber = 1100, PriceSeasonNumber = 1200,  NumberOfBeds = 4, NumberOfPeople = 10 },
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

        public static void SeedReservations(ApplicationDbContext<User, Role, int> context)
        {
            if (context.Reservation.Any()) return;
            DateTime today = DateTime.Now;
            List<Reservation> reservations = new List<Reservation>()
            {
                new Reservation(){HotelId=1, RoomId=1, ChkIn = today, ChkOut = today.AddDays(1), StatusId = 1, UserId = 2 },
                new Reservation(){HotelId=1, RoomId=2, ChkIn = today, ChkOut = today.AddDays(2), StatusId = 1,  UserId = 2 },
                new Reservation(){HotelId=1, RoomId=3, ChkIn = today.AddDays(1), ChkOut = today.AddDays(3), StatusId = 2,  UserId = 2},
                new Reservation(){HotelId=1, RoomId=4, ChkIn = today.AddDays(3), ChkOut = today.AddDays(4), StatusId = 3,  UserId = 2 },
                
                new Reservation(){HotelId=2, RoomId=6, ChkIn = today, ChkOut = today.AddDays(1), StatusId = 1,  UserId = 3 },
                new Reservation(){HotelId=2, RoomId=7, ChkIn = today, ChkOut = today.AddDays(1), StatusId = 1,  UserId = 3  },
                new Reservation(){HotelId=2, RoomId=8, ChkIn = today.AddDays(2), ChkOut = today.AddDays(4), StatusId = 2,  UserId = 3  },
                new Reservation(){HotelId=2, RoomId=9, ChkIn = today.AddDays(4), ChkOut = today.AddDays(6), StatusId = 3,  UserId = 3  },
                
                new Reservation(){HotelId=3, RoomId=11, ChkIn = today, ChkOut = today.AddDays(1), StatusId = 1,  UserId = 4},
                new Reservation(){HotelId=3, RoomId=12, ChkIn = today, ChkOut = today.AddDays(1), StatusId = 1,  UserId = 4},
                new Reservation(){HotelId=3, RoomId=13, ChkIn = today.AddDays(4), ChkOut = today.AddDays(7), StatusId = 2,  UserId = 4 },
                new Reservation(){HotelId=3, RoomId=14, ChkIn = today.AddDays(7), ChkOut = today.AddDays(9), StatusId = 3,  UserId = 4 },

            };
            foreach (var reservation in reservations)
            {
                context.Add(reservation);
            }
            context.SaveChanges();
        }

    }
}
