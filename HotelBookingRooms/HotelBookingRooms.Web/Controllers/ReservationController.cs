﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels.ReservationVM;
using HotelBookingRooms.BLL.Entities;

namespace HotelBookingRooms.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService IReservationService;
        private readonly IRoomTypeService IRoomTypeService;

        public ReservationController(IReservationService IReservationService, IRoomTypeService IRoomTypeService)
        {
            this.IReservationService = IReservationService;
            this.IRoomTypeService = IRoomTypeService;
        }

        public IActionResult Index()
        {
            var reservations = IReservationService.GetReservations();
            var reservationsVM = new List<IndexReservationVM>();

            foreach(var map in reservations)
            {
                IndexReservationVM vm = new IndexReservationVM();
                AutoMapper.Mapper.Map(map, vm);
                reservationsVM.Add(vm);
            }
                

            return View(reservationsVM);
        }

        //[HttpPost]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var deleteReservation = IReservationService.GetReservation((int)Id);
            if (deleteReservation == null)
            {
                return NotFound();
            }
            return View(deleteReservation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? Id)
        {
            var deleteRoom = IReservationService.GetReservation((int)Id);
            if (deleteRoom == null)
            {
                return NotFound();
            }
            try
            {
                IReservationService.DeleteReservation((int)Id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Delete), new { id = Id, saveChangesError = true });
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = IReservationService.GetReservation((int)id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }


        [HttpGet, ActionName("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = IReservationService.GetReservation((int)id);

            ViewBag.RoomTypes = IRoomTypeService
                .GetRoomTypesForSpecificHotel(reservation.Room.RoomType.HotelId)
                    .ToList();

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id, RoomNumber, FloorNumber, RoomTypeID")] Reservation room)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Error = true;

            if (ModelState.IsValid)
            {
                if (IReservationService.EditReservation((int)id, room) == true)
                {
                    ViewBag.Error = false;
                }
            }

            var reservation = IReservationService.GetReservation((int)id);

            ViewBag.RoomTypes = IRoomTypeService
                .GetRoomTypesForSpecificHotel(reservation.Room.RoomType.HotelId)
                    .ToList();

            return View(reservation);
        }
    }
}