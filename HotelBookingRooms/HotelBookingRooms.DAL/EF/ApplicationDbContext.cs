using System;
using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingRooms.DAL.EF
{
    public class ApplicationDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ConnectionStringDto _connectionStringDto;

        // Table properties e.g
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }


        public ApplicationDbContext(ConnectionStringDto connectionStringDto)
        {
            _connectionStringDto = connectionStringDto;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionStringDto.ConnectionString); // for provider SQL Server 
            // optionsBuilder.UseMySql(_connectionStringDto.ConnectionString); //for provider My SQL 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
        }
    }
}