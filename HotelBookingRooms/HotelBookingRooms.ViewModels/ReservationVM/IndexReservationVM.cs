using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBookingRooms.ViewModels.ReservationVM
{
    public class IndexReservationVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "HotelId is required")]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Room is required")]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Display(Name = "ChkIn")]
        [Required(ErrorMessage = "ChkIn is required")]
        public DateTime? ChkIn { get; set; }

        [Display(Name = "ChkOut")]
        [Required(ErrorMessage = "ChkOut is required")]
        public DateTime? ChkOut { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
