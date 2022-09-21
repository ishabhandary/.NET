using MovieBookingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingApp.Data
{
    public interface IMoviesRepo
    {
        List<Movie> GetAllMovies();
        List<User> GetAllUsers();
        List<Show> GetAllShows();
        List<Seat> GetAllSeats();
        List<Booking> GetAllBookings();
        List<Ticket> GetAllTickets();
        List<Address> GetAllAddresses();
        List<Theatre> GetAllTheatres();
        List<Screen> GetAllScreens();

    }
}
