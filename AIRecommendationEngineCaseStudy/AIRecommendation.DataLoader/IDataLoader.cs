using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.DataLoader
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
