using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataCache
{
    public class BooksDataService
    {
        public BookDetails GetBookDetails()
        {
            IDataLoader dataLoader = DataLoaderFactory.Instance.GetDataLoader();

            IDataCacher dataCacher = new MemDataCacher();

            BookDetails bookDetails = dataCacher.GetData();

            if (bookDetails == null)
            {
                bookDetails = dataLoader.Load();
                dataCacher.SetData(bookDetails);
            }

            return bookDetails;
        }
    }
}
