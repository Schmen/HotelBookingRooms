using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.RoomVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IRoomTypeService
    {
        RoomType GetRoomType(int id);
        bool AddRoomType(RoomType room);
        bool EditRoomType(int id, EditRoomTypeVM room);
        bool DeleteRoomType(int id);
        IEnumerable<RoomType> GetRoomTypes();
        IEnumerable<RoomType> GetRoomTypesForSpecificHotel(int hotelId);
    }
}
