using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Core.Interfaces.UoW;
using HotelBookingRooms.BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelBookingRooms.ViewModels;
namespace HotelBookingRooms.Web.Controllers
{
    public class RoomController : BaseController
    {

        public RoomController(IUnitOfWork uow, ILoggerFactory loggerFactory) : base(uow, loggerFactory)
        {

        }
        public IActionResult Index()
        {
            var hotel = Uow.Repository<Hotel>().GetRange().ToList();
            var roomTypes = Uow.Repository<RoomType>().GetRange().ToList();
            var rooms = Uow.Repository<Room>().GetRange().ToList();

            for (int i = 0; i < roomTypes.Count(); i++)
            {
                for (int j = 0; j < hotel.Count(); j++)
                {
                    if (roomTypes[i].HotelId == hotel[j].Id)
                    {
                        roomTypes[i].Hotel = hotel[j];
                    }
                }

            }

            for (int i = 0; i<rooms.Count(); i++)
            {
                for(int j = 0; j < roomTypes.Count(); j++)
                {
                    if (rooms[i].RoomTypeID == roomTypes[i].Id)
                    {
                        rooms[i].RoomType = roomTypes[i];
                    }
                }

            }
            return View(rooms);
        }

        public IActionResult Details(int? id)
        {
            RoomRoomTypeVm vm = new RoomRoomTypeVm();
            vm.Room = Uow.Repository<Room>().GetRange(r => r.Id == id) as Room;
            vm.RoomType = Uow.Repository<RoomType>().GetRange(rt => rt.Id == vm.Room.RoomTypeID) as RoomType;
            vm.Hotel = Uow.Repository<Hotel>().GetRange(h => h.Id == vm.RoomType.HotelId) as Hotel;

            return View(vm);
        }
    }
}