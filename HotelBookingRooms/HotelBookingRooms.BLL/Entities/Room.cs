using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        
        public int Number { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }

        [ForeignKey("RoomType")]
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
