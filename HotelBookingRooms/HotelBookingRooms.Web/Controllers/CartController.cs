using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingRooms.BLL.Entities;
using HotelBookingRooms.Services.Interfaces;
using HotelBookingRooms.Utilities;
using Microsoft.AspNetCore.Mvc;

using HotelBookingRooms.ViewModels.CartVM;
namespace HotelBookingRooms.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IHotelService IHotelService;
        private readonly IRoomService IRoomService;
        private readonly IRoomTypeService IRoomTypeService;

        public CartController(IRoomService IRoomService, IRoomTypeService IRoomTypeService)
        {
            this.IRoomService = IRoomService;
            this.IRoomTypeService = IRoomTypeService;
            //this.IHotelService = IHotelService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int Id, DateTime? chkIn, DateTime? chkOut, string returnUrl)
        {
            Room room = IRoomService.GetRoom(Id);

            if(room != null)
            {
                Cart cart = GetCart();
                cart.AddItem(room, chkIn, chkOut);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int roomId, string returnUrl)
        {
            Room room = IRoomService.GetRoom(roomId);

            if(room != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(room);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}