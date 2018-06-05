using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KMeans.Processing;
using static KMeans.Clustering;

namespace KMeans
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify the value of k: ");
            int k = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Specify the value of i: ");
            int i = Int32.Parse(Console.ReadLine());

            Dictionary<int, List<double>> data = readCsv();
            Dictionary<int, List<double>> centroids = SetCentroids(k);
            Dictionary<int, double> distanceToCentroid = CalcDistanceToCentroid(centroids[5], data);

            int total = 0;

            foreach (var entry in distanceToCentroid)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }

            Console.WriteLine();
            Console.ReadKey();

            //ExecKMeans(k, i);
        }
    }
}
