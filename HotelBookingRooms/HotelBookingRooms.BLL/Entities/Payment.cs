using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static HotelBookingRooms.BLL.Entities.Cart;

namespace HotelBookingRooms.BLL.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to give first line")]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Please give me your addres")]
        public string Line1 { get; set; }
        [Required(ErrorMessage = "Please give me your addres")]
        public string Line2 { get; set; }

        
        [Required(ErrorMessage = "Fill In Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill In City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Fill In State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Fill In Zip")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Fill In Country")]
        public string Country { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
