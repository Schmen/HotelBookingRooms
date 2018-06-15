using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBookingRooms.ViewModels.ReservationVM
{
    public class SearchRoomVM
    {
        [Display(Name = "Hotel")]
        public Hotel Hotel { get; set; }
		//s
        [Display(Name = "Room")]
        [Required(ErrorMessage = "Room is required")]
        public Room Room { get; set; }

        [Display(Name = "ChkIn")]
        [Required(ErrorMessage = "ChkIn is required")]
        public DateTime? ChkIn { get; set; }

        [Display(Name = "ChkOut")]
        [Required(ErrorMessage = "ChkOut is required")]
        public DateTime? ChkOut { get; set; }

        [Display(Name = "NumberOfPeople")]
        [Required(ErrorMessage = "ChkOut is required")]
        public int NumberOfPeople { get; set; }

        [Display(Name = "NumberOfBeds")]
        [Required(ErrorMessage = "ChkOut is required")]
        public int NumberOfBeds { get; set; }
    }
}
