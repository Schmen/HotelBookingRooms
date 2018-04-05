using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class RoomType
    {
        [Key]
        public int  Id { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        
        [StringLength(40)]
        [Required(ErrorMessage = "Room name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Area is required")]
        [StringLength(60)]
        public string Area { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "PriceStandardNumber is required")]
        public decimal PriceStandardNumber { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "PriceSeasonNumber is required")]
        public decimal PriceSeasonNumber { get; set; }
        
        [Required(ErrorMessage = "NumberOfPeople is required")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "NumberOfBeds is required")]
        public int NumberOfBeds { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(200)]
        public string Description { get; set; }
        
        public virtual Hotel Hotel { get; set; }
    }
}
