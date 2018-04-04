using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class RoomType
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string PriceStandardNumber { get; set; }
        public string PriceSeasonNumber { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfBeds { get; set; }
        public string Description { get; set; }
    }
}
