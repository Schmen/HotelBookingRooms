using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomBookingRooms.Services.Services
{
    public class RoomService: IRoomService
    {
        private readonly ApplicationDbContext<User, Role, int> _db;
        
        private readonly IUnitOfWork _uow;

        public RoomService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }
        
        public bool DeleteRoom(int id)
        {
            try
            {
                var Room = _uow.Repository<Room>().Get(r => r.Id == id);
                _uow.Repository<Room>().Delete(Room);
                _uow.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EditRoom(int id, Room Room)
        {
            try
            {
                var newRoom = GetRoom(id);
                newRoom.Id = Room.Id;
                newRoom.FloorNumber = Room.FloorNumber;
                newRoom.RoomNumber = Room.RoomNumber;
                newRoom.RoomTypeID = Room.RoomTypeID;
                _uow.Repository<Room>().Update(newRoom);
                _uow.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Room GetRoom(int id)
        {
            try
            {
                var room = _db.Room
                        .Include(x => x.RoomType)
                         .ThenInclude(h => h.Hotel)
                        .SingleOrDefault(x => x.Id == id);
                return room;
                //_uow.Repository<Room>().Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public IEnumerable<Room> GetRooms()
        {
            // Upgrade biblioteki po majowce
            // Z ponizszej linijki bd mogl pobrac zagniezdzone dane z tabel
            //var roomTypes = _uow.Repository<RoomType>().GetRange(null, true, null, null, null, r=>r.Hotel);
            var rooms = _db.Room.Include(x => x.RoomType).ThenInclude(h => h.Hotel).ToList();// _uow.Repository<Room>().GetRange(null, true, null, null, null, r => r.RoomType, h=>h.RoomType.Hotel).ToList() ;
            return rooms;
        }



        public bool AddRoom(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
