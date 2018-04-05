using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status name is required")]
        [StringLength(40)]
        public string Name { get; set; }
    }
}
