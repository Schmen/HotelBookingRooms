using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBookingRooms.ViewModels
{
    public class CreateRoomVM
    {
        public int Id { get; set; }

        [DisplayName("Room number")]
        [Required(ErrorMessage = "Room number is required")]
        public int RoomNumber { get; set; }

        [DisplayName("Floor number")]
        [Required(ErrorMessage = "Floor number is required")]
        public int FloorNumber { get; set; }

        [DisplayName("room type")]
        public int? RoomTypeId { get; set; }
        public RoomType RoomType {get;set;}

        [DisplayName("hotel name")]
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
