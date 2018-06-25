using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.ViewModels.CartVM
{
    public class CartSummaryVM
    {
        private Cart cart;

        public CartSummaryVM(Cart cartService)
        {
            cart = cartService;
        }

        //public IViewComponentResult Invoke()
        //{
        //    return ViewModels(cart);
        //}
    }
}
