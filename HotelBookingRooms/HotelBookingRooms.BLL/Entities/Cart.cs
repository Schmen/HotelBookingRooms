using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelBookingRooms.BLL.Entities
{
    public class Cart
    {
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Room Room { get; set; }
            public DateTime? ChkIn { get; set; }
            public DateTime? ChkOut { get; set; }
        }

        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Room room, DateTime? chkIn, DateTime? chkOut)
        {
            CartLine line = lineCollection
                .Where(p => p.Room.Id == room.Id)
                .FirstOrDefault();

            if(line==null)
            {
                lineCollection.Add(new CartLine
                {
                    Room = room,
                    ChkIn = chkIn,
                    ChkOut = chkOut
                });

            }
            else
            {
                //line.Quantity += quantity;
            }
        }

        public void RemoveLine(Room room)
        {
            lineCollection.RemoveAll(l => l.Room.Id == room.Id);
        }

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(r => r.Room.RoomType.PriceStandardNumber * Convert.ToInt32(r.ChkOut.Value.Day - r.ChkIn.Value.Day));

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
