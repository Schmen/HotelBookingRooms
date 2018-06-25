using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingRooms.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext<User, Role, int> _db;

        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }
        public string GetUser(string id)
        {
            //var user = _db.User.SingleOrDefault(u => u.Id == id);
            //return rooms;

            //var user = _db.Users.SingleOrDefault(u=>u.Email==)
            return null;
        }

        public User GetUserByName(string name)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserName == name);
            return user;
        }
    }
}
