using Microsoft.AspNetCore.Identity;

namespace HotelBookingRooms.BLL.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Address { get; set; }
        public string DocumentType { get; set; }
        public  int DocumentNumber { get; set; }
    }
}
