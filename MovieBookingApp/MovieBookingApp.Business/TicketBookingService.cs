using Microsoft.Win32;
using MovieBookingApp.Data;
using MovieBookingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Business
{
    public class TicketBookingService : ITicketBookingService
    {
        private IMoviesRepo moviesRepo = MoviesRepoFactory.Instance.GetMoviesRepo();
        private List<Address> addresses = null;
        private List<User> users = null;
        private List<Booking> bookings = null;
        private List<Ticket> tickets = null;
        private List<Show> shows = null;
        private List<Seat> seats = null;
        private List<Screen> screens = null;
        private List<Theatre> theatres = null;
        private List<Movie> movies = null;

        public TicketBookingService()
        {
            addresses = moviesRepo.GetAllAddresses();
            users = moviesRepo.GetAllUsers();
            bookings = moviesRepo.GetAllBookings();
            tickets = moviesRepo.GetAllTickets();
            shows = moviesRepo.GetAllShows();
            screens = moviesRepo.GetAllScreens();
            seats = moviesRepo.GetAllSeats();
            movies = moviesRepo.GetAllMovies();
            theatres = moviesRepo.GetAllTheatres();
        }

        public void DisplayReport(string movieName)
        {
            Console.WriteLine("Theatre Name    Movie Name     Number of tickets sold\n");
            var screenIdList = (from s in shows
                                where s.MovieId == (from m in movies where m.MovieName == movieName select m.MovieId).Single()
                                select s.ScreenId).Distinct();

            var theatreList = (from t in theatres
                               where (from s in screens
                                      where screenIdList.Contains(s.ScreenId)
                                      select s.TheatreId).Distinct().Contains(t.TheatreId)
                               select t).Distinct();

            foreach (var theatre in theatreList)
            {
                Console.Write(theatre.TheatreName + "  " + movieName + "  ");
                var screenIds = (from s in screens
                                 where s.TheatreId == theatre.TheatreId && screenIdList.Contains(s.ScreenId)
                                 select s.ScreenId);

                var ticketIdList = (from s in seats
                                    where screenIds.Contains(s.ScreenId)
                                    select s.TicketId).Distinct();

                Console.Write(ticketIdList.Count() + "\n");

            }

        }

        public List<string> GetAllMovieNamesSeenByUserInTheatre(string theatreName, string loginName)
        {
            List<string> movieNames = new List<string>();
            var userId = (from u in users
                          where u.LoginName == loginName
                          select u.UserId).Single();

            var showIds = from b in bookings
                          where b.UserId == userId
                          select b.ShowId;

            var showsList = (from s in shows
                             where showIds.Contains(s.ShowId)
                             select s);

            foreach (var show in showsList)
            {

                var theatreScreenId = (from s in screens
                                       where s.ScreenId == show.ScreenId
                                       select new { s.TheatreId, s.ScreenId }).Single();



                var theatre = (from t in theatres
                               where t.TheatreId == theatreScreenId.TheatreId
                               select t).Single();

                if (theatre.TheatreName == theatreName)
                {
                    var movieName = (from m in movies where m.MovieId == show.MovieId select m.MovieName).Single();
                    if (!movieNames.Contains(movieName))
                        movieNames.Add(movieName);
                }


            }
            return movieNames;
        }

        public double GetTotalIncomeEarnedByTheatre(string theatreName)
        {
            var theatreId = (from t in theatres
                             where t.TheatreName == theatreName
                             select t.TheatreId).Single();

            var screenIdList = from s in screens
                               where s.TheatreId.Equals(theatreId)
                               select s.ScreenId;

            var ticketIdList = (from s in seats
                                where screenIdList.Contains(s.ScreenId)
                                select s.TicketId).Distinct();

            var bookingIdList = (from t in tickets
                                 where ticketIdList.Contains(t.TicketId)
                                 select t.BookingId).Distinct();
            double income = 0;

            foreach (var bookingId in bookingIdList)
            {
                var booking = (from b in bookings
                               where b.BookingId == bookingId
                               select b).Single();

                var cost = (from s in shows
                            where s.ShowId == booking.ShowId
                            select s.Cost).Single();

                var ticketList = from t in tickets
                                 where t.BookingId == booking.BookingId
                                 select t.TicketId;


                ticketList = from t in ticketList
                             where ticketIdList.Contains(t)
                             select t;
                income += cost * ticketList.Count();

            }
            return income;

        }

        public int GetTotalNumberOfTicketsBookedByCity(string cityName)
        {

            var addressIds = from a in addresses
                             where a.City == cityName
                             select a.AddressId;

            var userIds = from u in users
                          where addressIds.Contains(u.AddressId)
                          select u.UserId;

            var bookingIds = from b in bookings
                             where userIds.Contains(b.UserId)
                             select b.BookingId;

            var ticketsList = from t in tickets
                              where bookingIds.Contains(t.BookingId)
                              select t;

            return ticketsList.Count();
        }
    }
}
