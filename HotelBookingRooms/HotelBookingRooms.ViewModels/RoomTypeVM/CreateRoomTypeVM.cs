using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBookingRooms.ViewModels.RoomTypeVM
{
    public class CreateRoomTypeVM
    {
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Room name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [StringLength(60)]
        public string Area { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "PriceStandardNumber is required")]
        [DataType(DataType.Currency)]
        public decimal PriceStandardNumber { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "PriceSeasonNumber is required")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal PriceSeasonNumber { get; set; }

        [Required(ErrorMessage = "NumberOfPeople is required")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "NumberOfBeds is required")]
        public int NumberOfBeds { get; set; }
        
        [Required(ErrorMessage = "Status is required")]
        [StringLength(200)]
        public string Description { get; set; }
        

    }
}
