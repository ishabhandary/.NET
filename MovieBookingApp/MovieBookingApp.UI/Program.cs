using MovieBookingApp.Business;
using System.Collections.Generic;
using System.Configuration;
using System;

namespace MovieBookingApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ITicketBookingService ticketBookingService = TicketBookingServiceFactory.Instance.GetTicketBookingService();

            /*Console.WriteLine("Enter the city to find the total number of tickets booked in that city:");
            string cityName = Console.ReadLine();
            Console.WriteLine("The total number of tickets is:" + ticketBookingService.GetTotalNumberOfTicketsBookedByCity(cityName));

            Console.WriteLine("Enter the theatre to find the total income:");
            string theatreName = Console.ReadLine();
            Console.WriteLine("The total income of the theatre is:" + ticketBookingService.GetTotalIncomeEarnedByTheatre(theatreName));

            Console.WriteLine("Enter the theatre name and login name to find the movies watched by the user in that theatre:");
            theatreName = Console.ReadLine();
            string loginName = Console.ReadLine();
            Console.WriteLine("The movie names are:");
            foreach (var movieName in ticketBookingService.GetAllMovieNamesSeenByUserInTheatre(theatreName, loginName))
            {
                Console.WriteLine(movieName);
            }*/

            Console.WriteLine("Enter the movie name to find total tickets booked:");
            var movieName = Console.ReadLine();
            ticketBookingService.DisplayReport(movieName);

        }
    }
}
