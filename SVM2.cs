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
using Accord.Statistics.Visualizations;

using Accord.Controls;
namespace ChemicalСompoundRecognition
{
    internal class SVM2
    {
       public SVM2() { 
        }

        public void SVM2Method(double[][] data, double[] test ,  int[] classes)
        {
            // training  model SVM classifier
            var teacher = new MulticlassSupportVectorLearning<Gaussian>()
            {
                // Configure the learning algorithm to use SMO to train the
                //  underlying SVMs in each of the binary class subproblems.
                Learner = (param) => new SequentialMinimalOptimization<Gaussian>()
                {
                    // Estimate a suitable guess for the Gaussian kernel's parameters.
                    // This estimate can serve as a starting point for a grid search.
                    UseKernelEstimation = true
                }
            };

            // Learn a machine
            var machine = teacher.Learn(data, classes);

            // Obtain class predictions for each sample
            int[] predicted = machine.Decide(data);

            //print result
            int i = 0;
            Console.WriteLine("results - (predict ,real labels)");
            foreach (int pred in predicted)
            {

                Console.Write("({0},{1} )", pred, classes[i]);
                i++;
            }

            //calculate the accuracy
            double error = new ZeroOneLoss(classes).Loss(predicted);

            Console.WriteLine("\n accuracy: {0}", 1 - error);

            // consider the decrease in the dimension of features using PCA
            var pca = new PrincipalComponentAnalysis()
            {
                Method = PrincipalComponentMethod.Center,
                Whiten = true
            };

            pca.NumberOfOutputs = 2;
            MultivariateLinearRegression transform = pca.Learn(data);
            double[][] outputPCA = pca.Transform(data);

            // print it on the scatter plot
            //ScatterplotBox.Show(outputPCA, classes).Hold();

            Console.ReadLine();
        }
    }
}
