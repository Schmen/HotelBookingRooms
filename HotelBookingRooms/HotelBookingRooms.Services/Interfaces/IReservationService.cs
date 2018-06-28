using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using HotelBookingRooms.ViewModels.ReservationVM;
using HotelBookingRooms.ViewModels.PaginationVM;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation GetReservation(int id);
        bool AddReservation(CreateReservationVM Reservation);
        bool EditReservation(int id, Reservation Reservation);
        bool DeleteReservation(int id);
        IEnumerable<Reservation> GetReservations(int productPage = 1);
        IEnumerable<Reservation> GetUserReservations(string userName);
        bool AddReservations(List<Reservation> reservations);
        ReservationsListViewModel GetReservation2(int productPage);
    }
}
