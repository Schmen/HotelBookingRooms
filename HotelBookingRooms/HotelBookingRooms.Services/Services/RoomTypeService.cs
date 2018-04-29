using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingRooms.Services.Services
{
    public class RoomTypeService : IRoomTypeService
    {

        private readonly ApplicationDbContext<User, Role, int> _db;

        private readonly IUnitOfWork _uow;

        public RoomTypeService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }

        public bool AddRoomType(RoomType room)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoomType(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditRoomType(int id, RoomType room)
        {
            throw new NotImplementedException();
        }

        public RoomType GetRoomType(int id)
        {
            return _db.RoomType.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            return _db.RoomType;
        }

        public IEnumerable<RoomType> GetRoomTypesForSpecificHotel(int id)
        {
            try
            {
                var results = _db.RoomType.Where(r => r.HotelId == id);
                return results;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
