using System.Collections.Generic;

namespace MovieBookingApp.Data.Entities
{
    public class User
    {
        public long UserId { get; set; }

        public string LoginName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AddressId { get; set; }

    }
}
