using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels;
using HotelBookingRooms.ViewModels.RoomTypeVM;
using HotelBookingRooms.ViewModels.RoomVM;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingRooms.Web.Controllers
{
    public class RoomTypeController : Controller
    {

        private readonly IHotelService IHotelService;
        private readonly IRoomService IRoomService;
        private readonly IRoomTypeService IRoomTypeService;

        public RoomTypeController(IRoomService IRoomService, IRoomTypeService IRoomTypeService, IHotelService IHotelService)
        {
            this.IRoomService = IRoomService;
            this.IRoomTypeService = IRoomTypeService;
            this.IHotelService = IHotelService;
        }

        public IActionResult Index()
        {
            var roomTypes = IRoomTypeService.GetRoomTypes().ToList();
            return View(roomTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Hotels = IHotelService.GetHotels().ToList();
            return View(new CreateRoomTypeVM());
        }

        [HttpPost]
        public IActionResult Create(CreateRoomTypeVM roomType)
        {

            RoomType type = new RoomType()
            {
                HotelId = roomType.HotelId,
                Name = roomType.Name,
                Area = roomType.Area,
                PriceSeasonNumber = Convert.ToDecimal(roomType.PriceStandardNumber),
                PriceStandardNumber = Convert.ToDecimal(roomType.PriceStandardNumber),
                NumberOfBeds = roomType.NumberOfBeds,
                NumberOfPeople = roomType.NumberOfPeople,
                Description = roomType.Description,

            };

            if (IRoomTypeService.AddRoomType(type))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        //[HttpPost]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var roomType = IRoomTypeService.GetRoomType((int)Id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? Id)
        {
            var roomType = IRoomTypeService.GetRoomType((int)Id);
            if (roomType == null)
            {
                return NotFound();
            }
            try
            {
                IRoomTypeService.DeleteRoomType((int)Id);
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

            var room = IRoomTypeService.GetRoomType((int)id);

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

            ViewBag.Hotels = IHotelService.GetHotels().ToList();

            var roomType = IRoomTypeService.GetRoomType((int)id);

            EditRoomTypeVM editRoomTypeVM = new EditRoomTypeVM()
            {
                HotelId = roomType.HotelId,
                Name = roomType.Name,
                Area = roomType.Area,
                PriceSeasonNumber = roomType.PriceStandardNumber,
                PriceStandardNumber = roomType.PriceStandardNumber,
                NumberOfBeds = roomType.NumberOfBeds,
                NumberOfPeople = roomType.NumberOfPeople,
                Description = roomType.Description,

            };

            if (roomType == null)
            {
                return NotFound();
            }

            return View(editRoomTypeVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(int? id, EditRoomTypeVM editRoomTypeVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (IRoomTypeService.EditRoomType((int)id, editRoomTypeVM) == false)
                {
                    ViewBag.Error = true;
                    return View(editRoomTypeVM);
                }
            }

            var roomType = IRoomTypeService.GetRoomType((int)id);

            EditRoomTypeVM vm = new EditRoomTypeVM()
            {
                HotelId = roomType.HotelId,
                Name = roomType.Name,
                Area = roomType.Area,
                PriceSeasonNumber = roomType.PriceStandardNumber,
                PriceStandardNumber = roomType.PriceStandardNumber,
                NumberOfBeds = roomType.NumberOfBeds,
                NumberOfPeople = roomType.NumberOfPeople,
                Description = roomType.Description,

            };

            ViewBag.Hotels = IHotelService.GetHotels().ToList();
            ViewBag.Error = false;

            return View(vm);
        }
    }
}