using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Mvc;


namespace HotelBookingRooms.Web.Controllers
{
    public class PaymentController : Controller
    {

        public ViewResult Checkout() => View(new Payment());
        
    }
}