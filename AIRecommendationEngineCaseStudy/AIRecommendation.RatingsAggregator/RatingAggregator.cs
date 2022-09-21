using AIRecommendation.DataLoader;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace AIRecommendation.RatingsAggregator
{
    public class RatingAggregator : IRatingsAggregator
    {
        Object lock1 = new Object();
        Object lock2 = new Object();
        private bool isInRange(int age, int lowerAge, int upperAge)
        {
            if (age >= lowerAge && age <= upperAge)
            {
                return true;
            }

            return false;
        }

        public Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference)
        {
            List<User> users = bookDetails.Users;
            List<BookUserRating> ratings = bookDetails.Ratings;
            List<int> usersMatchedIds = new List<int>();
            int age = preference.Age;
            string state = preference.State;

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            NameValueCollection ageGroups = ConfigurationManager.AppSettings;

            int lowerAge = 0, upperAge = 0;

            foreach (string s in ageGroups.AllKeys)
            {
                if (!s.Contains("Age"))
                {
                    continue;
                }

                string[] range = ageGroups.Get(s).Split(',');

                lowerAge = int.Parse(range[0]);

                upperAge = int.Parse(range[1]);

                if (isInRange(age, lowerAge, upperAge))
                {
                    break;
                }
            }

            Parallel.ForEach(users, u =>
            {
                if (isInRange(u.Age, lowerAge, upperAge) && u.State != null && u.State.Equals(state))
                {
                    lock (lock1)
                    {
                        usersMatchedIds.Add(u.UserId);
                    }
                }

            });

            Parallel.ForEach(ratings, bookUserRating =>
            {
                if (usersMatchedIds.Contains(bookUserRating.UserId))
                {
                    if (!dict.ContainsKey(bookUserRating.ISBN))
                    {
                        lock (lock1)
                        {
                            dict[bookUserRating.ISBN] = new List<int>();
                        }
                    }

                    lock (lock2)
                    {
                        dict[bookUserRating.ISBN].Add(bookUserRating.Rating);
                    }
                }
            });

            return dict;
        }
    }
}
