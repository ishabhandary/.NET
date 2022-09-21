using MovieBookingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Dapper;

namespace MovieBookingApp.Data
{
    public class DapperMoviesRepo : IMoviesRepo
    {
        DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["default"].ProviderName);
        IDbConnection conn = null;

        public List<Address> GetAllAddresses()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Address>("Select * from Addresses").ToList();
            }

        }

        public List<Booking> GetAllBookings()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Booking>("Select * from Bookings").ToList();
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Movie>("Select * from Movies").ToList();
            }
        }

        public List<Screen> GetAllScreens()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Screen>("Select * from Screens").ToList();
            }
        }

        public List<Seat> GetAllSeats()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Seat>("Select * from Seats").ToList();
            }
        }

        public List<Show> GetAllShows()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Show>("Select * from Shows").ToList();
            }
        }

        public List<Theatre> GetAllTheatres()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Theatre>("Select * from Theatres").ToList();
            }
        }

        public List<Ticket> GetAllTickets()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<Ticket>("Select * from Tickets").ToList();
            }
        }

        public List<User> GetAllUsers()
        {
            using (conn = factory.CreateConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;// server name;database name;auth details
                conn.Open();
                return conn.Query<User>("Select * from Users").ToList();
            }
        }
    }
}
