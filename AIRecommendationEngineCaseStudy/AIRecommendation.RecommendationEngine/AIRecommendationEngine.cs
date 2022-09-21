using AIRecommendation.DataLoader;
using AIRecommendation.RatingsAggregator;
using AIRecommendation.Recommender;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIRecommendation.DataCache;

namespace AIRecommendation.RecommendationEngine
{
    public class AIRecommendationEngine
    {
        //private IDataLoader dataLoader;

        private IRatingsAggregator ratingsAggregator;

        private IRecommender recommender;

        private BookDetails bookDetails;

        private Thread loadThread;

        private Object lock1 = new Object();

        public AIRecommendationEngine()
        {
            /* dataLoader = new CSVDataLoader();
             bookDetails = new BookDetails();
             loadThread = new Thread(() =>
             {
                 bookDetails = dataLoader.Load();
             }
             );
             loadThread.Start();

             ratingsAggregator = new RatingAggregator();
             recommender = new PearsonRecommender(); */

            bookDetails = new BookDetails();
            BooksDataService booksDataService = new BooksDataService();
            loadThread = new Thread(() =>
            {
                bookDetails = booksDataService.GetBookDetails();
            }
            );
            loadThread.Start();

            ratingsAggregator = new RatingAggregator();
            recommender = new PearsonRecommender();
        }
        public List<Book> Recommend(Preference preference, int limit)
        {
            List<Book> books = new List<Book>();

            loadThread.Join();

            Console.WriteLine($"\nThere are {bookDetails.Users.Count} users, {bookDetails.Books.Count} books and {bookDetails.Ratings.Count} ratings.");

            Stopwatch sw = Stopwatch.StartNew();
            Dictionary<string, List<int>> dict = ratingsAggregator.Aggregate(bookDetails, preference);
            //Console.WriteLine(sw.ElapsedMilliseconds);

            /*foreach (var pair in dict)
            {
                Console.Write(pair.Key + ":");
                foreach (var item in pair.Value)
                {
                    Console.WriteLine(" " + item);
                }
            }
            Console.WriteLine("-----------------------------------------------------");*/

            List<int> baseData = new List<int>();

            if (dict.ContainsKey(preference.ISBN))
            {
                baseData = dict[preference.ISBN];
                dict.Remove(preference.ISBN);
            }
            else
            {
                Console.WriteLine("There are no ratings for this book with the specified preference.");
                return books;
            }

            /*Console.WriteLine("Base data is:");
            foreach(int i in baseData)
            {
                Console.WriteLine(i);
            }*/

            Dictionary<string, double> correlation = new Dictionary<string, double>();

            sw = Stopwatch.StartNew();
            Parallel.ForEach(dict.Keys, key =>
            {
                /* Console.WriteLine("Other data is:");
                 foreach (int j in dict[key])
                 {
                     Console.WriteLine(j);
                 }*/

                double r = recommender.GetCorrelation(baseData, dict[key]);
                if (r.Equals(double.NaN))
                {
                    r = -1;
                }
                //Console.WriteLine(r);
                lock (lock1)
                {
                    correlation.Add(key, r);
                }
            });
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.WriteLine(correlation.Count);

            IOrderedEnumerable<KeyValuePair<string, double>> orderedEnumerable = correlation.OrderByDescending(key => key.Value);

            /*int ii = 0;
            ii = 0;
            foreach (var pair in orderedEnumerable)
            {
                int i = bookDetails.Books.FindIndex(b=>b.ISBN==pair.key);
                if (i != -1)
                {
                bookDetails.Books[i].PrintDetails();
                Console.WriteLine(pair.Value);
                ii++;
                if (ii == 15)
                    break;
                }
            }*/
            int count = 0;

            foreach (KeyValuePair<string, double> pair in orderedEnumerable)
            {
                int i = bookDetails.Books.FindIndex(b => b.ISBN == pair.Key);
                if (i != -1)
                {
                    books.Add(bookDetails.Books[i]);
                    count++;
                    if (count % 1000 == 0)
                    {
                        Console.WriteLine(count);
                    }
                    if (count == limit)
                    {
                        break;
                    }
                }
            }

            return books;
        }
    }
}
