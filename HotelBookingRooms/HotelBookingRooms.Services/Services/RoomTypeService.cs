using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.RoomVM;
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

        public bool AddRoomType(RoomType roomType)
        {
            try
            {
                //RoomType type = new RoomType()
                //{
                //    Area = vm.RoomNumber,
                //    Description = vm.FloorNumber,
                //    HotelId = _db.RoomType.SingleOrDefault(rt => rt.Id == vm.RoomTypeId)
                //    Name =
                //    NumberOfBeds =
                //    NumberOfPeople =
                //    PriceSeasonNumber =
                //    PriceStandardNumber =
                //};
                //room.RoomType.HotelId = (int)vm.HotelId; // Dont need HotelId cause I got this id from roomtype property

                _db.RoomType.Add(roomType);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //throw new System.ArgumentException("While adding rooms", "Cannot add room");
                return false;
            }
        }

        public bool DeleteRoomType(int id)
        {
            try
            {
                var type = _uow.Repository<RoomType>().Get(r => r.Id == id);
                _uow.Repository<RoomType>().Delete(type);
                _uow.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditRoomType(int id, EditRoomTypeVM roomType)
        {
            try
            {
                var newRoom = GetRoomType(id);
                newRoom.Area = roomType.Area;
                newRoom.Description = roomType.Description;
                newRoom.HotelId = roomType.HotelId;
                newRoom.Name = roomType.Name;
                newRoom.NumberOfBeds = roomType.NumberOfBeds;
                newRoom.NumberOfPeople = roomType.NumberOfPeople;
                newRoom.PriceSeasonNumber = roomType.PriceSeasonNumber;
                newRoom.PriceStandardNumber = roomType.PriceStandardNumber;

                _uow.Repository<RoomType>().Update(newRoom);
                _uow.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public RoomType GetRoomType(int id)
        {
            return _db.RoomType.Include(r=>r.Hotel).SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            return _db.RoomType.Include(r=>r.Hotel);
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
