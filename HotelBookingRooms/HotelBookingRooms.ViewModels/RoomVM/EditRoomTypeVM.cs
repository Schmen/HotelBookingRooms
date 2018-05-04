using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBookingRooms.ViewModels.RoomVM
{
    public class EditRoomTypeVM
    {

        [DisplayName("HotelId")]
        public int HotelId { get; set; }

        [DisplayName("Roomtype name")]
        [Required(ErrorMessage = "Roomtype name is required")]
        public string Name { get; set; }

        [DisplayName("Area")]
        [Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }

        [DisplayName("Price standard")]
        [Required(ErrorMessage = "PriceStandardNumber is required")]
        public decimal PriceStandardNumber { get; set; }

        [DisplayName("Price season")]
        [Required(ErrorMessage = "Price season is required")]
        public decimal PriceSeasonNumber { get; set; }

        [DisplayName("Number of beds")]
        [Required(ErrorMessage = "Number of beds is required")]
        public int NumberOfBeds { get; set; }

        [DisplayName("Number of people")]
        [Required(ErrorMessage = "Number of people is required")]
        public int NumberOfPeople { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
