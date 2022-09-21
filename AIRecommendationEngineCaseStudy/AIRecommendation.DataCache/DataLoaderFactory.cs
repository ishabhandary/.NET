using AIRecommendation.DataLoader;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AIRecommendation.DataCache
{
    internal class DataLoaderFactory
    {
        public static readonly DataLoaderFactory Instance = new DataLoaderFactory();

        private DataLoaderFactory()
        {

        }

        public IDataLoader GetDataLoader()
        {
            string dataLoaderClassName = ConfigurationManager.AppSettings["DataLoader"] + "," + "AIRecommendation.DataLoader";
            if (string.IsNullOrEmpty(dataLoaderClassName)) { return null; }
            Type theType = Type.GetType(dataLoaderClassName);
            return (IDataLoader)Activator.CreateInstance(theType);
        }
    }
}
