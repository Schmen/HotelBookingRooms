using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IPaymentService
    {
        bool AddPayment(Payment payment);

    }
}
