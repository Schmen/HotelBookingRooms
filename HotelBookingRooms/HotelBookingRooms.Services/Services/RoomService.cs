using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.ReservationVM;
using HotelBookingRooms.ViewModels.RoomVM;
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
            catch (Exception)
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
            var room = _db.Room
                    .Include(x => x.RoomType)
                        .ThenInclude(h => h.Hotel)
                    .SingleOrDefault(x => x.Id == id);

            return room;
        }

        

        public IEnumerable<Room> GetRooms()
        {
            var rooms = _db.Room
                .Include(x => x.RoomType)
                .ThenInclude(h => h.Hotel)
                .ToList();// _uow.Repository<Room>().GetRange(null, true, null, null, null, r => r.RoomType, h=>h.RoomType.Hotel).ToList() ;

            return rooms;
        }

        public IEnumerable<Room> GetRoomsInHotel(int id)
        {
            var rooms = _db.Room
                .Include(x => x.RoomType)
                .ThenInclude(h => h.Hotel)
                .Where(h=>h.RoomType.Hotel.Id == id)
                .ToList();// _uow.Repository<Room>().GetRange(null, true, null, null, null, r => r.RoomType, h=>h.RoomType.Hotel).ToList() ;

            return rooms;
        }


        public bool AddRoom(CreateRoomVM vm)
        {
            try
            {
                Room room = new Room()
                {
                    RoomNumber = vm.RoomNumber,
                    FloorNumber = vm.FloorNumber,
                    RoomType = _db.RoomType.SingleOrDefault(rt => rt.Id == vm.RoomTypeId)
                };
                //room.RoomType.HotelId = (int)vm.HotelId; // Dont need HotelId cause I got this id from roomtype property

                _db.Room.Add(room);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //throw new System.ArgumentException("While adding rooms", "Cannot add room");
                return false;
            }
        }

        public IEnumerable<Room> GetAvailableRoomsInSpecifiedHotel(SearchRoomVM vm)
        {

            var availableRooms = _db.Room.Where(x => x.Reservations.Count(z => z.ChkIn >= vm.ChkIn) == 0
            && x.RoomType.NumberOfBeds == vm.NumberOfBeds
            && x.RoomType.NumberOfPeople == vm.NumberOfPeople
            && x.RoomType.Hotel == vm.Hotel)
            .Include(x => x.RoomType)
            .Include(x => x.RoomType.Hotel); // Zwraca wolne pokoje
            
            return availableRooms;
        }

        public IEnumerable<Room> GetAvailableRoomsInAllObject(SearchRoomVM vm)
        {

            var availableRooms = _db.Room.Where(x => x.Reservations.Count(z => z.ChkIn >= vm.ChkIn) == 0
            && x.RoomType.NumberOfBeds == vm.NumberOfBeds
            && x.RoomType.NumberOfPeople == vm.NumberOfPeople)
            .Include(x => x.RoomType)
            .Include(x => x.RoomType.Hotel); // Zwraca wolne pokoje

            return availableRooms;
        }
    }
}
