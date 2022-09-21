using System.Collections.Generic;

namespace AIRecommendation.DataLoader
{
    public class BookDetails
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public List<User> Users { get; set; } = new List<User>();

        public List<BookUserRating> Ratings { get; set; } = new List<BookUserRating>();
    }
}