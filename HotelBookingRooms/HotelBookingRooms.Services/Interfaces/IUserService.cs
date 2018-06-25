using HotelBookingRooms.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Services.Interfaces
{
    public interface IUserService
    {
        String GetUser(string id);
        User GetUserByName(string name);
    }
}
