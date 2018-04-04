using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public DateTime? ChkIn { get; set; }
        public DateTime? ChkOut { get; set; }

        public virtual User User{ get; set; }
        public virtual Room Room { get; set; }
        public virtual Status Status { get; set; }
    }
}
