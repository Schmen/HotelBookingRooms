using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBookingRooms.Utilities
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) => 
            request.QueryString.HasValue 
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
}
