using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingRooms.ViewModels.ReservationVM;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation GetReservation(int id);
        bool AddReservation(CreateReservationVM Reservation);
        bool EditReservation(int id, Reservation Reservation);
        bool DeleteReservation(int id);
        IEnumerable<Reservation> GetReservations();
    }
}
