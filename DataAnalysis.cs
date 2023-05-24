using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalСompoundRecognition
{
    class DataAnalysis
    {
        public void KNeighbours(double[][] IncomeData, int columns)
        {
            Console.WriteLine("Begin weighted k-NN classification ");
            Console.WriteLine("Normalized income, education data: ");
            Console.WriteLine("[id =  0, 90, 80, .. class = 0]");
            Console.WriteLine(" . . . ");
            Console.WriteLine("[id = 6, 97, 80, ... class = 2]");

            double[][] data = IncomeData;
            for (int i=0; i<data.Length; i++)
            {
                for (int j = 0; j < data[i].Length;j++)
                {
                    Console.Write(data[i][j]+" ");
                }
                Console.WriteLine();
            }
            var item = IncomeData[IncomeData.Length-1];
            Analyze(item, data, 5, 2);  // 3 classes
            Console.WriteLine("\nEnd weighted k-NN demo ");
            Console.ReadLine();
        }

        static void Analyze(double[] item, double[][] data, int k, int classes)
        {
            // 1. Compute all distances
            int N = data.Length;
            double[] distances = new double[N-1];
            for (int i = 0; i < N-1; ++i)
                distances[i] = DistFunc(item, data[i]);

            // 2. Get ordering
            int[] ordering = new int[N-1];
            for (int i = 0; i < N-1; ++i)
                ordering[i] = i;
            double[] distancesCopy = new double[N-1];
            Array.Copy(distances, distancesCopy, distances.Length);
            Array.Sort(distancesCopy, ordering);

            // 3. Show info for k-nearest
            double[] kNearestDists = new double[k];
            for (int i = 0; i < k; ++i)
            {
                int idx = ordering[i];
                ShowVector(data[idx], idx);
                Console.Write("  dist = " +
                  distances[idx].ToString("F4"));
                Console.WriteLine("  inv dist " +
                  (1.0 / distances[idx]).ToString("F4"));
                kNearestDists[i] = distances[idx];
            }

            // 4. Vote

            double[] votes = new double[classes];  // one per class
            double[] wts = MakeWeights(k, kNearestDists);
            Console.WriteLine("\nWeights (inverse technique): ");
            for (int i = 0; i < wts.Length; ++i)
                Console.Write(wts[i].ToString("F4") + "  ");
            Console.WriteLine("\n\nPredicted class: ");
            for (int i = 0; i < k; ++i)
            {
                int idx = ordering[i];
                int predClass = (int)data[idx][361];
                votes[predClass-1] += wts[i] * 1.0;
            }
            for (int i = 0; i < classes; ++i)
                Console.WriteLine("[" + i + "]  " +
                votes[i].ToString("F4"));
        } // Analyze

        static double[] MakeWeights(int k, double[] distances)
        {
            // Inverse technique
            double[] result = new double[k];  // one per neighbor
            double sum = 0.0;
            for (int i = 0; i < k; ++i)
            {
                result[i] = 1.0 / distances[i];
                sum += result[i];
            }
            for (int i = 0; i < k; ++i)
                result[i] /= sum;
            return result;
        }


        static double DistFunc(double[] item, double[] dataPoint)
        {
            double sum = 0.0;
            for (int i = 0; i < item.Length-1; ++i)
            {
                double diff = item[i] - dataPoint[i];
                sum += diff * diff;
            }
            return Math.Sqrt(sum);
        }
        static void ShowVector(double[] v, int idx)
        {
            Console.Write("idx = (" + idx.ToString() + ") class = " + v[v.Length-1]);
        }




    }
}
