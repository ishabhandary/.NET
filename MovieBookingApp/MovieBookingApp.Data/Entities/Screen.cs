using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Screen
    {
        public int ScreenId { get; set; }
        public int TheatreId { get; set; }
        public string ScreenName { get; set; }

    }
}
