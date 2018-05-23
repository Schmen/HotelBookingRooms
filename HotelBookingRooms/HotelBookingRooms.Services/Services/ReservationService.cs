﻿using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels.ReservationVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingRooms.Services.Services
{
    public class ReservationService: IReservationService
    {
        private readonly ApplicationDbContext<User, Role, int> _db;

        private readonly IUnitOfWork _uow;

        public ReservationService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }

        public bool DeleteReservation(int id)
        {
            try
            {
                var Room = _uow.Repository<Reservation>().Get(r => r.Id == id);
                _uow.Repository<Reservation>().Delete(Room);
                _uow.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditReservation(int id, Reservation Reservation)
        {
            try
            {
                //var newReservation = GetReservation(id);
                //newReservation.Id = Reservation.Id;
                //newReservation.FloorNumber = Reservation.FloorNumber;
                //newReservation.RoomNumber = Reservation.RoomNumber;
                //newReservation.RoomTypeID = Reservation.RoomTypeID;
                //_uow.Repository<Room>().Update(newReservation);
                //_uow.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Reservation GetReservation(int id)
        {
            var reservation = _db.Reservation
                    .Include(x => x.Hotel)
                    .Include(x => x.Room)
                        .ThenInclude(x => x.RoomType)
                    .Include(x => x.User)
                    .Include(x => x.Status)
                    .SingleOrDefault(x => x.Id == id);

            return reservation;
        }



        public IEnumerable<Reservation> GetReservations()
        {
            // _uow.Repository<Room>().GetRange(null, true, null, null, null, r => r.RoomType, h=>h.RoomType.Hotel).ToList() ;
            var reservations = _db.Reservation
                .Include(x=>x.Hotel)
                .Include(x=>x.Room)
                .Include(x=>x.User)
                .Include(x=>x.Status)
                .ToList();

            return reservations;
        }



        public bool AddReservation(CreateReservationVM vm)
        {
            try
            {
                Room room = new Room()
                {
                    //RoomNumber = vm.RoomNumber,
                    //FloorNumber = vm.FloorNumber,
                    //RoomType = _db.RoomType.SingleOrDefault(rt => rt.Id == vm.RoomTypeId)
                };
                //room.RoomType.HotelId = (int)vm.HotelId; // Dont need HotelId cause I got this id from roomtype property

                _db.Room.Add(room);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //throw new System.ArgumentException("While adding rooms", "Cannot add room");
                return false;
            }
        }

    }
}
