using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public DateTime? ChkIn { get; set; }
        public DateTime? ChkOut { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
