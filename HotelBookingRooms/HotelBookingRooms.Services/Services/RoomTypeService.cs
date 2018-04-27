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
    public class RoomTypeService : IRoomTypeService
    {

        private readonly ApplicationDbContext<User, Role, int> _db;

        private readonly IUnitOfWork _uow;

        public RoomTypeService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }

        public bool AddtRoomType(Room room)
        {
            throw new NotImplementedException();
        }

        public bool AddtRoomType(RoomType room)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoomType(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditRoomType(int id, Room room)
        {
            throw new NotImplementedException();
        }

        public bool EditRoomType(int id, RoomType room)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            return _db.RoomType;
        }

        public IEnumerable<RoomType> GetRoomTypesForSpecificHotel(int hotelId)
        {
            var roomTypes = _db.RoomType.Where(r => r.HotelId == hotelId);
            return roomTypes;
        }

        RoomType IRoomTypeService.GetRoomType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
