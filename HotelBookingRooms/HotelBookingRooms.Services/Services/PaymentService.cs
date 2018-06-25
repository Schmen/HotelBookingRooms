using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.DAL.EF;
using HotelBookingRooms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Services
{
    public class PaymentService:IPaymentService
    {
        private readonly ApplicationDbContext<User, Role, int> _db;

        private readonly IUnitOfWork _uow;

        public PaymentService(IUnitOfWork uow, ApplicationDbContext<User, Role, int> db)
        {
            this._uow = uow;
            this._db = db;
        }


        public bool AddPayment(Payment payment)
        {
            try
            {
                _db.Payment.Add(payment);
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

