using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendation.DataLoader;

namespace AIRecommendation.DataCache
{
    public interface IDataCacher
    {
        BookDetails GetData();

        void SetData(BookDetails bookDetails);

    }
}
