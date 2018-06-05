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

            Dictionary<int, Dictionary<int, double>> DistDPToCentroids = new Dictionary<int, Dictionary<int, double>>();

            foreach (var datapoint in data)
            {
                DistDPToCentroids.Add(datapoint.Key, new Dictionary<int, double>());
                foreach (var centroid in centroids)
                {
                    DistDPToCentroids[datapoint.Key].Add(centroid.Key, CalcDistanceToCentroid(centroid.Value, data)[datapoint.Key]);
                    DistDPToCentroids[datapoint.Key] = DistDPToCentroids[datapoint.Key].OrderBy(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value);
                }
            }


            foreach (var distanceToCentroid in DistDPToCentroids)
            {
                Console.WriteLine(distanceToCentroid.Key);
                foreach (var ie in distanceToCentroid.Value)
                {
                    Console.WriteLine(ie.Key + " : " + ie.Value);
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine();
            Console.ReadKey();

            //ExecKMeans(k, i);
        }
    }
}
