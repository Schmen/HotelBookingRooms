using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.RoomVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IRoomService
    {
        //IEnumerable<Room> GetRooms();
        Room GetRoom(int id);
        bool AddRoom(CreateRoomVM room);
        bool EditRoom(int id, Room room);
        bool DeleteRoom(int id);
        IEnumerable<Room> GetRooms();
    }
}
