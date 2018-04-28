using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingRooms.Services.Services
{
    public class HotelService: IHotelService
    {
        ApplicationDbContext<User, Role, int> _db;

        public HotelService(ApplicationDbContext<User, Role, int> db)
        {
            this._db = db;
        }

        public bool AddHotel(Hotel hotel)
        {
            try
            {
                _db.Add(hotel);
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }



        public bool DeleteHotel(int id)
        {
            try
            {
                var hotel = GetHotel(id);
                _db.Remove(hotel);
                _db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool EditHotel(int id, Hotel _hotel)
        {
            try
            {
                var hotel = GetHotel(id);
                hotel.Id = _hotel.Id;
                hotel.Name = _hotel.Name;
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public Hotel GetHotel(int id)
        {
            try
            {
                return _db.Hotel.Single(x => x.Id == id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<Hotel> GetHotels()
        {
            try
            {
                return _db.Hotel.ToList();
            }
            catch(Exception)
            {
                return new List<Hotel>();
            }
        }
    }
}
