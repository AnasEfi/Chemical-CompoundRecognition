using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace ChemicalСompoundRecognition
{
    internal class SVM
    {
        public SVM() { }
        public void SVMethod (double[][] data , double[] test, int[] classes)
        {
            Console.WriteLine("Creating and training Poly kernel SVM");
            var smo = new SequentialMinimalOptimization<Polynomial>();
            smo.Complexity = 1.0;
            smo.Kernel = new Polynomial(4, 0.0);
            smo.Epsilon = 1.0e-3;
            smo.Tolerance = 1.0e-2;
            Console.WriteLine("Starting training");
            var svm = smo.Learn(data, classes);
            Console.WriteLine("Training complete");

            Console.WriteLine("Evaluating SVM model");
            bool[] preds = svm.Decide(data);
            double[] score = svm.Score(data);

            int numCorrect = 0; int numWrong = 0;
            for (int i = 0; i < preds.Length; ++i)
            {
                Console.Write("Predicted (double) : " + score[i] + " ");
                Console.Write("Predicted (bool): " + preds[i] + " ");
                Console.WriteLine("Actual: " + classes[i]);
                if (preds[i] == true && classes[i] == 1) ++numCorrect;
                else if (preds[i] == false && classes[i] == -1) ++numCorrect;
                else ++numWrong;
            }
            double acc = (numCorrect * 100.0) / (numCorrect + numWrong);
            Console.WriteLine("Model accuracy = " + acc);

            bool predClass = svm.Decide(test);
            Console.WriteLine("Predicted class for (test) = " +
              predClass);

            //support vectors
            Console.WriteLine("Model support vectors: ");
            double[][] sVectors = svm.SupportVectors;
            for (int i = 0; i < sVectors.Length; ++i)
            {
                for (int j = 0; j < sVectors[i].Length; ++j)
                {
                    Console.Write(sVectors[i][j].ToString("F1") + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Model weights: ");
            double[] wts = svm.Weights;
            for (int i = 0; i < wts.Length; ++i)
                Console.Write(wts[i].ToString("F6") + " ");
            Console.WriteLine("");

            double b = svm.Threshold;
            Console.WriteLine("Model b = " + b.ToString("F6"));
            Console.WriteLine("End SVM demo ");
           
        }


    }
}
