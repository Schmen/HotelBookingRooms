using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelBookingRooms.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService IRoomService;
        private readonly IRoomTypeService IRoomTypeService;

        public RoomController(IRoomService IRoomService, IRoomTypeService IRoomTypeService)
        {
            this.IRoomService = IRoomService;
            this.IRoomTypeService = IRoomTypeService;
        }

        public IActionResult Index()
        {
            var rooms = IRoomService.GetRooms();
            return View(rooms);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var room = IRoomService.GetRoom((int)id);

            if (room == null)
            {
                return NotFound();
            }
            
            return View(room);
        }

        [HttpGet, ActionName("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = IRoomService.GetRoom((int)id);

            ViewBag.RoomTypes = IRoomTypeService
                .GetRoomTypesForSpecificHotel(room.RoomType.HotelId)
                    .ToList();

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id, RoomNumber, FloorNumber, RoomTypeID")] Room room)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    IRoomService.EditRoom((int)id, room);
                    return RedirectToAction("Edit",(int)id);
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }

            return View(room);
        }
    }
}