using AIRecommendation.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.DataCache
{
    public class MemDataCacher : IDataCacher
    {
        private BookDetails bookDetails;
        public BookDetails GetData()
        {
            return bookDetails;
        }

        public void SetData(BookDetails bookDetails)
        {
            this.bookDetails=bookDetails;
        }
    }
}
