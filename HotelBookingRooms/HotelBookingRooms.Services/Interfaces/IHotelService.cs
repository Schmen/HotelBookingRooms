using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();
        Hotel GetHotel(int id);
        bool AddHotel(Hotel hotel);
        bool EditHotel(int id, Hotel hotel);
        bool DeleteHotel(int id);
    }
}
