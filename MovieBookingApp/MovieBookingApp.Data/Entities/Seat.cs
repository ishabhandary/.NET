using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Seat
    {
        public char RowId { get; set; }

        public int SeatId { get; set; }

        public long TicketId { get; set; }

        public int ScreenId { get; set; }
    }
}
