using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelBookingRooms.Web.Controllers
{
    public class HotelController : BaseController
    {
        public HotelController(IUnitOfWork uow, ILoggerFactory loggerFactory) : base(uow, loggerFactory)
        {

        }

        public IActionResult Index()
        {
            var hotels = Uow.Repository<Hotel>().GetRange();
            return View(hotels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var hotels = Uow.Repository<Hotel>().GetRange();
            return View(new Hotel());
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            Uow.Repository<Hotel>().Add(hotel);
            Uow.Save();
            return View();
        }

        [HttpPost]
        public IActionResult Create(int Id)
        {
            var deleteHotel = Uow.Repository<Hotel>().Get(Id);
            Uow.Repository<Hotel>().Delete(deleteHotel);
            Uow.Save();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult Delete(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var deleteHotel = Uow.Repository<Hotel>().Get((int)Id);
            if(deleteHotel == null)
            {
                return NotFound();
            }
            return View(deleteHotel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? Id)
        {
            var deleteHotel = Uow.Repository<Hotel>().Get((int)Id);
            if (deleteHotel == null)
            {
                return NotFound();
            }
            try
            {
                Uow.Repository<Hotel>().Delete(deleteHotel);
                Uow.Save();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction(nameof(Delete), new { id = Id, saveChangesError = true });
            }
        }

        public IActionResult Edit(int Id, Hotel hotel)
        {
            if(Id != hotel.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    var deleteHotel = Uow.Repository<Hotel>().Get(Id);
                    Uow.Repository<Hotel>().Delete(deleteHotel);
                    Uow.Save();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Unable to update your database"); // Log Error
                }
            }
            return View(hotel);

        }
    }
}