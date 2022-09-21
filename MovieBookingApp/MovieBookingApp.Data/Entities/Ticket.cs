using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Ticket
    {
        public long TicketId { get; set; }

        public long BookingId { get; set; }
    }
}
