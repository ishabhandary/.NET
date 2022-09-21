using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AIRecommendation.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public void loadUsers(BookDetails bookDetails)
        {
            char[] charsToTrim = { '"' };

            StreamReader streamReader = new StreamReader("C:\\Users\\Admin\\Documents\\AIRecommendationEngineCaseStudy\\AIRecommendation.DataLoader\\SampleData\\BX-Users.csv");

            streamReader.ReadLine();

            while (!streamReader.EndOfStream)
            {
                string[] userDetails = streamReader.ReadLine().Split(';');
                User user = new User();
                try
                {
                    user.UserId = int.Parse(userDetails[0].Trim(charsToTrim));
                    if (!(userDetails[2] == "NULL"))
                    {
                        user.Age = int.Parse(userDetails[2].Trim(charsToTrim));
                    }
                    string[] location = userDetails[1].Split(',');
                    user.City = location[0].Trim(charsToTrim);
                    user.State = location[1].Trim();
                    user.Country = location[2].Trim(charsToTrim);
                }
                catch (Exception e)
                {

                }
                bookDetails.Users.Add(user);
            }
        }

        public void loadBooks(BookDetails bookDetails)
        {
            char[] charsToTrim = { '"' };

            StreamReader streamReader = new StreamReader("C:\\Users\\Admin\\Documents\\AIRecommendationEngineCaseStudy\\AIRecommendation.DataLoader\\SampleData\\BX-Books.csv");

            streamReader.ReadLine();

            while (!streamReader.EndOfStream)
            {
                string[] books = streamReader.ReadLine().Split(';');
                Book book = new Book();
                try
                {
                    book.ISBN = books[0].Trim(charsToTrim);
                    book.BookTitle = books[1].Trim(charsToTrim);
                    book.BookAuthor = books[2].Trim(charsToTrim);
                    book.YearOfPublication = int.Parse(books[3].Trim(charsToTrim));
                    book.Publisher = books[4].Trim(charsToTrim);
                    book.ImageUrlSmall = books[5].Trim(charsToTrim);
                    book.ImageUrlMedium = books[6].Trim(charsToTrim);
                    book.ImageUrlLarge = books[7].Trim(charsToTrim);
                }
                catch (Exception e)
                {

                }
                bookDetails.Books.Add(book);
            }
        }
        public void loadRatings(BookDetails bookDetails)
        {
            char[] charsToTrim = { '"' };

            StreamReader streamReader = new StreamReader("C:\\Users\\Admin\\Documents\\AIRecommendationEngineCaseStudy\\AIRecommendation.DataLoader\\SampleData\\BX-Book-Ratings.csv");

            streamReader.ReadLine();

            while (!streamReader.EndOfStream)
            {
                string[] ratings = streamReader.ReadLine().Split(';');
                BookUserRating rating = new BookUserRating();
                try
                {
                    rating.UserId = int.Parse(ratings[0].Trim(charsToTrim));
                    rating.ISBN = ratings[1].Trim(charsToTrim);
                    rating.Rating = int.Parse(ratings[2].Trim(charsToTrim));
                }
                catch (Exception e)
                {

                }
                bookDetails.Ratings.Add(rating);
            }
        }

        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();

            Parallel.Invoke(() => loadUsers(bookDetails), () => loadBooks(bookDetails), () => loadRatings(bookDetails));

            return bookDetails;
        }
    }
}
