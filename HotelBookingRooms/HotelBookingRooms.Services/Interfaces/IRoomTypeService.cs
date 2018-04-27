using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IRoomTypeService
    {
        RoomType GetRoomType(int id);
        bool AddtRoomType(RoomType room);
        bool EditRoomType(int id, RoomType room);
        bool DeleteRoomType(int id);
        IEnumerable<RoomType> GetRoomTypes();
        IEnumerable<RoomType> GetRoomTypesForSpecificHotel(int hotelId);
    }
}
