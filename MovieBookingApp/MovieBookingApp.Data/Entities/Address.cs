using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string HouseNo { get; set; }

        public string City { get; set; }

        public string StreetName { get; set; }

        public string State { get; set; }

        public int PinCode { get; set; }

    }
}
