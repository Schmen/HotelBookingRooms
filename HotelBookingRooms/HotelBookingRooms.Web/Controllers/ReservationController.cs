using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.ViewModels.ReservationVM;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.Utilities;
using DataAccessLayer.Core.Interfaces.UoW;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingRooms.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService IReservationService;
        private readonly IRoomTypeService IRoomTypeService;
        private readonly IHotelService IHotelService;
        private readonly IRoomService IRoomService;
        private readonly IPaymentService IPaymentService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService IUserService;

        public ReservationController(IReservationService IReservationService, 
            IRoomTypeService IRoomTypeService, IHotelService IHotelService,
            IRoomService IRoomService, IPaymentService IPaymentService,
            UserManager<User> userManager, IUserService IUserService) 
        {
            this._userManager = userManager;
            this.IReservationService = IReservationService;
            this.IRoomTypeService = IRoomTypeService;
            this.IHotelService = IHotelService;
            this.IRoomService = IRoomService;
            this.IPaymentService = IPaymentService;
            this.IUserService = IUserService;
        }

        //public ViewResult List(int productPage=1)
        //    => View(new ReservationListViewModel
        //    {
        //        Reservation
        //    })

        public IActionResult Index(int productPage = 1)
        {
            var reservations = IReservationService.GetReservations(productPage);
            var reservationsVM = new List<IndexReservationVM>();

            foreach(var map in reservations)
            {
                IndexReservationVM vm = new IndexReservationVM();
                AutoMapper.Mapper.Map(map, vm);
                reservationsVM.Add(vm);
            }
                

            return View(reservationsVM);
        }

        public IActionResult GetUserReservation()
        {

            if(User.Identity.IsAuthenticated==true)
            {
                var reservations = IReservationService.GetUserReservations(User.Identity.Name);
                var reservationsVM = new List<IndexReservationVM>();

                foreach (var map in reservations)
                {
                    IndexReservationVM vm = new IndexReservationVM();
                    AutoMapper.Mapper.Map(map, vm);
                    reservationsVM.Add(vm);
                }
                return View(reservationsVM);
            }

            return View("Index", null);
            
        }

        public IActionResult List(int productPage = 1)
        {
            var reservations = IReservationService.GetReservation2(productPage);
            return View(reservations);
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

        [HttpGet]
        public IActionResult SearchRoom()
        {
            SearchRoomVM vm = new SearchRoomVM();
            vm.ChkIn = System.DateTime.Now;
            vm.ChkOut = System.DateTime.Now;
            ViewBag.Hotels = IHotelService.GetHotels().ToList();
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchRoom([Bind("Hotel, Room, ChkIn, ChkOut, NumberOfPeople, NumberOfBeds")] SearchRoomVM vm)
        {
            if(vm.Hotel==null)
            {
                ViewBag.AvailableRooms = IRoomService.GetAvailableRoomsInAllObject(vm);
            }
            else
            {
                ViewBag.AvailableRooms = IRoomService.GetAvailableRoomsInSpecifiedHotel(vm);
            }

            ViewBag.Hotels = IHotelService.GetHotels().ToList();
            return View(vm);
        }

        [HttpGet]
        public ViewResult Checkout() => View(new Payment());

        [HttpPost]
        public ViewResult Checkout(Payment payment)
        {
            if (payment!= null)
            {
                var isAdded = IPaymentService.AddPayment(payment);
                List<Reservation> reservations = new List<Reservation>();
                var reservationCart = GetCart();
                var numberOfReservationRooms = reservationCart.Lines.Count();
                for(int i = 0; i < numberOfReservationRooms; i++)
                {
                    foreach(var r in reservationCart.Lines)
                    {
                        if (User.Identity.IsAuthenticated == false)
                        {
                            Reservation res = new Reservation()
                            {
                                HotelId = r.Room.RoomType.HotelId,
                                UserId = 1,
                                RoomId = r.Room.Id,
                                ChkIn = r.ChkIn,
                                ChkOut = r.ChkOut,
                                StatusId = 3,
                                PaymentId = payment.Id
                            };
                            reservations.Add(res);
                        }
                        else
                        {
                            var g = _userManager.GetUserName(HttpContext.User);
                            var user = IUserService.GetUserByName(g);

                            Reservation res = new Reservation()
                            {
                                HotelId = r.Room.RoomType.HotelId,
                                User = user,
                                Room = IRoomService.GetRoom(r.Room.Id),
                                ChkIn = r.ChkIn,
                                ChkOut = r.ChkOut,
                                StatusId = 3,
                                PaymentId = payment.Id
                            };
                            reservations.Add(res);
                        }
                    }
                }
                var isCorrect = IReservationService.AddReservations(reservations);
                if(isCorrect==true)
                {
                    TransactionCompleteVM vm = new TransactionCompleteVM()
                    {
                        booked = reservations,
                        paid = payment
                    };
                    Cart cart = GetCart();
                    cart.Clear();
                    return View("Complete", vm);
                }
            }
            return View();
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }




    }
}