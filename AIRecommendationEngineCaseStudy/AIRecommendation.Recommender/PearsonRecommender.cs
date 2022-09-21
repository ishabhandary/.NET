using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendation.Recommender
{
    public class PearsonRecommender : IRecommender
    {
        public double GetCorrelation(List<int> baseArr, List<int> otherArr)
        {
            List<int> baseData = new List<int>(baseArr);
            List<int> otherData = new List<int>(otherArr);

            if (baseData.Count < otherData.Count)
            {
                otherData.RemoveRange(baseData.Count, otherData.Count-baseData.Count);
            }

            else if (otherData.Count < baseData.Count)
            { 

                for (int i = otherData.Count; i < baseData.Count; i++)
                {
                    otherData.Add(1);
                    baseData[i] += 1;
                }

            }

            for (int i = 0; i < baseData.Count; i++)
            {
                if (baseData[i] == 0 || otherData[i] == 0)
                {
                    baseData[i] += 1;
                    otherData[i] += 1;
                }
            }

            /*for (int i = 0; i < baseData.Count; i++)
            {
                Console.WriteLine(baseData[i] + " " + otherData[i]);
            }

            Console.WriteLine("--------------------------------------------------------\n");*/

            int n = baseData.Count;
            int sumX = 0, sumY = 0, sumXY = 0, sumXSquare = 0, sumYSquare = 0;

            for (int i = 0; i < n; i++)
            {
                sumX += baseData[i];
                sumY += otherData[i];
                sumXY += baseData[i] * otherData[i];
                sumXSquare += baseData[i] * baseData[i];
                sumYSquare += otherData[i] * otherData[i];
            }

            double numerator = n * sumXY - (sumX * sumY);
            double denominator = Math.Sqrt(((n * sumXSquare) - (sumX * sumX)) * ((n * sumYSquare) - (sumY * sumY)));

            return numerator / denominator;

        }
    }
}
