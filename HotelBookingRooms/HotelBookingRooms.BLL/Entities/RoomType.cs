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

        public string Name { get; set; }
        public string Area { get; set; }
        public string PriceStandardNumber { get; set; }
        public string PriceSeasonNumber { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfBeds { get; set; }
        public string Description { get; set; }


        public virtual Hotel Hotel { get; set; }
    }
}
