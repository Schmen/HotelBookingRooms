using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingRooms.Web.Controllers
{
    public class RoomTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}