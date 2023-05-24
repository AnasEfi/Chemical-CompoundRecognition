
using System;
using System.Linq;
using Accord.Statistics.Models.Regression.Linear;
using Accord.Statistics.Analysis;
using Accord.IO;
using Accord.Math;
using System.Data;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using Accord.Controls;

namespace ChemicalСompoundRecognition
{
    internal class PCA
    {

        public PCA() { }

        public double[][] PCAMethod(double[][] data)
        {
            var pca = new PrincipalComponentAnalysis()
            {
                Method = PrincipalComponentMethod.Center,
                Whiten = true
            };

            pca.NumberOfOutputs = 20;
            pca.Learn(data);
            double[][] outputPCA = pca.Transform(data);

            Console.ReadLine();
            return outputPCA;
        }
    }
}
