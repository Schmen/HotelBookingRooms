using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.ViewModels
{
    public class RoomRoomTypeVm
    {
        public Room Room { get; set; }
        public RoomType RoomType { get; set; }
        public Hotel Hotel { get; set; }

    }
}
