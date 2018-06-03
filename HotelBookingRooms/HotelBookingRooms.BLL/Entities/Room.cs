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

        [Required(ErrorMessage = "Room number is required")]
        public int RoomNumber { get; set; }
        
        [Required(ErrorMessage = "Floor number is required")]
        public int FloorNumber { get; set; }
        
        [ForeignKey("RoomType")]
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
