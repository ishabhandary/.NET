using System;
using System.Collections.Generic;

namespace AIRecommendation.DataLoader
{
    public class User
    {
        public int UserId { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<BookUserRating> ratings { get; set; } = new List<BookUserRating>();

        public void PrintDetails()
        {
            Console.WriteLine($"\nUserId:{UserId}, Age:{Age}, City:{City}, State:{State}, Country:{Country}");
        }
    }
}