﻿using HotelBookingRooms.BLL.Entities;
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
            //SeedRoomTypes(context);
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
            //If there is already any date of RoomType
            if (context.RoomType.Any()) return;
            List<RoomType> roomTypes = new List<RoomType>()
            {
                new RoomType(){HotelId = 1, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 1 }, // Jedynka dla jednego goscia z pojedynczym lozkiem.
                new RoomType(){HotelId = 1, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300, Bathroom = true, NumberOfBeds = 2, NumberOfPeople = 1 }, // Podwojny dla jednej osoby. Posiada dwa lozka, przeznaczone dla jednej osoby?
                new RoomType(){HotelId = 1, Area = "20 m2", PriceStandardNumber = 300, PriceSeasonNumber = 350 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Podwojny to pokoj dla dwoch osob z dwoma osobnymi lozkami
                new RoomType(){HotelId = 1, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400, Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Dwojka pokoj dwuosobowy z jednym dwuosobowym lozkiem.
                new RoomType(){HotelId = 1, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450, Bathroom = true, NumberOfBeds = 3, NumberOfPeople = 3 }, // Trojka dla 3 osob z 3 lozkami pojedynczymi.
                new RoomType(){HotelId = 1, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500, Bathroom = true, NumberOfBeds = 4, NumberOfPeople = 4 }, // Czworka dla 4 osob z 4 pojedynczymi lozkami.

                new RoomType(){HotelId = 2, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 1 }, // Jedynka dla jednego goscia z pojedynczym lozkiem.
                new RoomType(){HotelId = 2, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300, Bathroom = true, NumberOfBeds = 2, NumberOfPeople = 1 }, // Podwojny dla jednej osoby. Posiada dwa lozka, przeznaczone dla jednej osoby?
                new RoomType(){HotelId = 2, Area = "20 m2", PriceStandardNumber = 300, PriceSeasonNumber = 350 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Podwojny to pokoj dla dwoch osob z dwoma osobnymi lozkami
                new RoomType(){HotelId = 2, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400, Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Dwojka pokoj dwuosobowy z jednym dwuosobowym lozkiem.
                new RoomType(){HotelId = 2, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450, Bathroom = true, NumberOfBeds = 3, NumberOfPeople = 3 }, // Trojka dla 3 osob z 3 lozkami pojedynczymi.
                new RoomType(){HotelId = 2, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500, Bathroom = true, NumberOfBeds = 4, NumberOfPeople = 4 }, // Czworka dla 4 osob z 4 pojedynczymi lozkami.

                new RoomType(){HotelId = 3, Area = "10 m2" , PriceStandardNumber = 200, PriceSeasonNumber = 250 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 1 }, // Jedynka dla jednego goscia z pojedynczym lozkiem.
                new RoomType(){HotelId = 3, Area = "15 m2", PriceStandardNumber = 250, PriceSeasonNumber = 300, Bathroom = true, NumberOfBeds = 2, NumberOfPeople = 1 }, // Podwojny dla jednej osoby. Posiada dwa lozka, przeznaczone dla jednej osoby?
                new RoomType(){HotelId = 3, Area = "20 m2", PriceStandardNumber = 300, PriceSeasonNumber = 350 , Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Podwojny to pokoj dla dwoch osob z dwoma osobnymi lozkami
                new RoomType(){HotelId = 3, Area = "20 m2", PriceStandardNumber = 350, PriceSeasonNumber = 400, Bathroom = true, NumberOfBeds = 1, NumberOfPeople = 2 }, // Dwojka pokoj dwuosobowy z jednym dwuosobowym lozkiem.
                new RoomType(){HotelId = 3, Area = "30 m2", PriceStandardNumber = 400, PriceSeasonNumber = 450, Bathroom = true, NumberOfBeds = 3, NumberOfPeople = 3 }, // Trojka dla 3 osob z 3 lozkami pojedynczymi.
                new RoomType(){HotelId = 3, Area = "40 m2", PriceStandardNumber = 450, PriceSeasonNumber = 500, Bathroom = true, NumberOfBeds = 4, NumberOfPeople = 4 }, // Czworka dla 4 osob z 4 pojedynczymi lozkami.
            };
            foreach(var roomType in roomTypes)
            {
                context.Add(roomType);
            }
            context.SaveChanges();
        }
    }
}
