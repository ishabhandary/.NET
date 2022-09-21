using System;

namespace AIRecommendation.DataLoader
{
    public class BookUserRating
    {
        public int Rating { get; set; }
        public string ISBN { get; set; }
        public int UserId { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"ISBN:{ISBN}, User ID:{UserId}, Rating:{Rating}.");
        }
    }
}