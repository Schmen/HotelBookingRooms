﻿using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.ReservationVM;
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
        IEnumerable<Room> GetRoomsInHotel(int id);
        IEnumerable<Room> GetAvailableRoomsInSpecifiedHotel(SearchRoomVM vm);
        IEnumerable<Room> GetAvailableRoomsInAllObject(SearchRoomVM vm);
    }
}
