using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieBookingApp.Data;

namespace MovieBookingApp.Business
{
    public class MoviesRepoFactory
    {
        public static readonly MoviesRepoFactory Instance = new MoviesRepoFactory();

        private MoviesRepoFactory()
        {
        }

        public IMoviesRepo GetMoviesRepo()
        {
            string dataLoaderClassName = ConfigurationManager.AppSettings["MoviesRepo"] + "," + "MovieBookingApp.Data";
            if (string.IsNullOrEmpty(dataLoaderClassName)) { return null; }
            Type theType = Type.GetType(dataLoaderClassName);
            return (IMoviesRepo)Activator.CreateInstance(theType);
        }
    }
}
