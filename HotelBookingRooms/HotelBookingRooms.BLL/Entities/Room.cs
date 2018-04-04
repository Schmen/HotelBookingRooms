using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    class Room
    {
        public int Number { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
