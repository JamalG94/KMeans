using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Processing
    {
        private static Dictionary<int, List<double>> _centroids = new Dictionary<int, List<double>>();
        private static Dictionary<int, List<double>> _datapoints = new Dictionary<int, List<double>>();
        public static Random random = new Random();

        public static Dictionary<int, double> CalcDistanceToCentroid(List<double> centroid, Dictionary<int, List<double>> datapoints)
        {
            double sum;
            Dictionary<int, double> distToCentroid = new Dictionary<int, double>();

            foreach (KeyValuePair<int, List<double>> entry in datapoints)
            {
                sum = 0.0;
                if (centroid.Count == entry.Value.Count)
                {
                    for (int x = 0; x < centroid.Count; x++)
                    {
                        sum += Math.Pow(centroid[x] - entry.Value[x], 2);
                    }
                }
                distToCentroid.Add(entry.Key, Math.Sqrt(sum));
            }

            return distToCentroid;
        }

        public static Dictionary<int, List<double>> SetCentroids(int k)
        {
            for (var i = 0; i < k; i++)
            {
                var centroid = new List<double>();
                for (var j = 0; j < 100; j++)
                {
                    centroid.Add(random.Next(2));
                }
                _centroids.Add(i, centroid);
            }

            return _centroids;
        }

        public static Dictionary<int, List<double>> readCsv()
        {
            using (var reader = new StreamReader(@"D:\Projects\DataScience2\KMeans\data\WineData.csv"))
            {
                while (!reader.EndOfStream)
                {
                    for (var i = 0; i < 32; i++)
                    {
                        String line = reader.ReadLine();
                        String[] splitline = line.Split(',');

                        for (var j = 0; j < splitline.Length; j++)
                        {
                            if (_datapoints.ContainsKey(i))
                            {
                                _datapoints[i].Add(int.Parse(splitline[j]));
                            }
                            else
                            {
                                var ordersList = new List<double>();
                                ordersList.Add(int.Parse(splitline[j]));
                                _datapoints.Add(i, ordersList);
                            }
                        }
                    }
                }
            }

            return _datapoints;
        }
    }
}
