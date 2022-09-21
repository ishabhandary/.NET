using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MovieBookingApp.Business
{
    public class TicketBookingServiceFactory
    {
        public static readonly TicketBookingServiceFactory Instance = new TicketBookingServiceFactory();

        private TicketBookingServiceFactory()
        {
        }

        public ITicketBookingService GetTicketBookingService()
        {
            string dataLoaderClassName = ConfigurationManager.AppSettings["TicketBookingService"] + "," + "MovieBookingApp.Business";
            if (string.IsNullOrEmpty(dataLoaderClassName)) { return null; }
            Type theType = Type.GetType(dataLoaderClassName);
            return (ITicketBookingService)Activator.CreateInstance(theType);
        }
    }
}
