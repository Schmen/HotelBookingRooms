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

namespace HotelBookingRooms.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService IRoomService;

        public RoomController(IRoomService IRoomService)
        {
            this.IRoomService = IRoomService;

        }

        public IActionResult Index()
        {
            var rooms = IRoomService.GetAllRooms();
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
    }
}