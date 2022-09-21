using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.RatingsAggregator;
using AIRecommendation.RecommendationEngine;
using AIRecommendation.DataLoader;
using System.Diagnostics;

namespace AIRecommendation.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AIRecommendationEngine recommendationEngine = new AIRecommendationEngine();

            int age = 25, limit = 7;
            string state = "tirol", isbn = "014062080X";
            //Console.WriteLine("Optimized");
            Console.Write("Enter User Age:");
            age = int.Parse(Console.ReadLine());

            Console.Write("Enter the User's State:");
            state = Console.ReadLine();

            Console.Write("Enter the Book ISBN:");
            isbn = Console.ReadLine();

            Console.Write("Enter the number of books to recommend:");
            limit = int.Parse(Console.ReadLine());

            Preference preference = new Preference { Age = age, ISBN = isbn, State = state };
            Stopwatch sw = Stopwatch.StartNew();
            List<Book> books;

            try
            {
                books = recommendationEngine.Recommend(preference, limit);
                if (books.Count > 0)
                {
                    Console.WriteLine($"\nThe {books.Count} books which are most similar to the given book are:\n");
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.Write("Book " + (i + 1) + ":  ");
                        books[i].PrintDetails();
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine("Finally:" + sw.ElapsedMilliseconds);

        }
    }
}
