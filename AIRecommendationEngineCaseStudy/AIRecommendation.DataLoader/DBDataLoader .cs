using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AIRecommendation.DataLoader
{
    public class DBDataLoader : IDataLoader
    {
        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();

            return bookDetails;
        }
    }
}
