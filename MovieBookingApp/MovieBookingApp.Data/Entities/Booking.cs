using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Booking
    {
        public long BookingId { get; set; }

        public long UserId { get; set; }

        public int ShowId { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
