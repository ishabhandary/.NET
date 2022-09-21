using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Show
    {
        public int ShowId { get; set; }

        public DateTime ShowTime { get; set; }

        public double Cost { get; set; }

        public long MovieId { get; set; }

        public int ScreenId { get; set; }
    }
}
