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
        private readonly IHotelService IHotelService;
        private readonly IRoomService IRoomService;
        private readonly IRoomTypeService IRoomTypeService;

        public RoomController(IRoomService IRoomService, IRoomTypeService IRoomTypeService, IHotelService IHotelService)
        {
            this.IRoomService = IRoomService;
            this.IRoomTypeService = IRoomTypeService;
            this.IHotelService = IHotelService;
        }

        public IActionResult Index()
        {
            var rooms = IRoomService.GetRooms();
            return View(rooms);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Hotels = IHotelService.GetHotels().ToList();
            var newRoom = new CreateRoomVM();
            return View(newRoom);
        }

        [HttpPost]
        public IActionResult Create([Bind("RoomNumber, FloorNumber, RoomTypeId, HotelId")] CreateRoomVM room)
        {
            if(IRoomService.AddRoom(room))
            {
                return RedirectToAction("Index");
            }
            return View();
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
                if(IRoomService.EditRoom((int)id, room) == true)
                {
                    return RedirectToAction("Edit",(int)id);
                }
                else
                {
                    return View((int)id);
                    // Make sth ?
                }
            }
            return View(room);
        }

        public JsonResult GetRoomTypesList(int id)
        {
            var RoomTypeList = IRoomTypeService
                                 .GetRoomTypesForSpecificHotel(id)
                                    .ToList();

            RoomTypeList.Insert(0, new RoomType { Id = 0, Name = "Please select roomtype" });
            var selectedList = new SelectList(RoomTypeList, "Id", "Name");
            return Json(selectedList);
        }
    }
}