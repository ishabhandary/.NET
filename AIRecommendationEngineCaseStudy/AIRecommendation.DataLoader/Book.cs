using System;
using System.Collections.Generic;

namespace AIRecommendation.DataLoader
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public string ImageUrlSmall { get; set; }
        public string ImageUrlMedium { get; set; }
        public string ImageUrlLarge { get; set; }

        public List<BookUserRating> ratings { get; set; } = new List<BookUserRating>();

        public void PrintDetails()
        {
            Console.WriteLine($"ISBN:{ISBN}, Book Title:{BookTitle}, Book Author:{BookAuthor}, Publisher:{Publisher}, Year of Publication:{YearOfPublication}, Image Url Small:{ImageUrlSmall}, Image Url Medium:{ImageUrlMedium}, Image Url Large:{ImageUrlLarge}");
        }
    }
}