using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.ViewModels.ReservationVM
{
    public class TransactionCompleteVM
    {
        public ICollection<Reservation> booked { get; set; }
        public Payment paid { get; set; }
    }
}
