using System;
using System.Collections.Generic;

namespace DecisionTreeAccord
{
    internal class DecisionTreeGPT
    {
        static DecisionTreeGPT() { }
        public void GetTree(double[][] data, int[] classes)
        {
            double[][] inputs = data;
            int[] outputs = classes;

            // Create and train the decision tree
            DecisionTree tree = new DecisionTree();
            tree.Train(data, outputs);

            // Test the decision tree
            List<int> predicted = new List<int>();
            foreach (var input in inputs)
            {
                int output = tree.Predict(input);
                predicted.Add(output);
            }

            // Print the results
            for (int i = 0; i < inputs.Length; i++)
            {
                double[] input = inputs[i];
                int output = predicted[i];

                Console.WriteLine($"Input: [{string.Join(", ", input)}], Predicted: {output}");
            }
        }
    }

    class DecisionTree
    {
        private Node root;

        public void Train(double[][] inputs, int[] outputs)
        {
            // Build the decision tree recursively
            root = BuildTree(inputs, outputs);
        }

        public int Predict(double[] input)
        {
            // Traverse the decision tree to make a prediction
            return TraverseTree(input, root);
        }

        private Node BuildTree(double[][] inputs, int[] outputs)
        {
            // Implement your decision tree building algorithm here
            // This is a simplified example, you may need to customize it for your specific requirements

            // In this example, we create a leaf node that predicts the majority class in the outputs
            int majorityClass = GetMajorityClass(outputs);
            Node node = new Node(majorityClass);

            return node;
        }

        private int TraverseTree(double[] input, Node node)
        {
            // Traverse the decision tree recursively to make a prediction
            if (node.IsLeaf)
            {
                return node.PredictedClass;
            }
            else
            {
                int featureIndex = node.SplitFeatureIndex;
                double threshold = node.SplitThreshold;

                if (input[featureIndex] <= threshold)
                {
                    return TraverseTree(input, node.LeftChild);
                }
                else
                {
                    return TraverseTree(input, node.RightChild);
                }
            }
        }

        private int GetMajorityClass(int[] outputs)
        {
            // Compute the majority class in the outputs
            Dictionary<int, int> classCounts = new Dictionary<int, int>();
            foreach (var output in outputs)
            {
                if (classCounts.ContainsKey(output))
                {
                    classCounts[output]++;
                }
                else
                {
                    classCounts[output] = 1;
                }
            }

            int maxCount = 0;
            int majorityClass = 0;
            foreach (var kvp in classCounts)
            {
                if (kvp.Value > maxCount)
                {
                    majorityClass = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            return majorityClass;
        }
    }

    class Node
    {
        public int PredictedClass { get; }
        public bool IsLeaf { get; }
        public int SplitFeatureIndex { get; }
        public double SplitThreshold { get; }
        public Node LeftChild { get; }
        public Node RightChild { get; }

        public Node(int predictedClass)
        {
            PredictedClass = predictedClass;
            IsLeaf = true;
        }

        public Node(int splitFeatureIndex, double splitThreshold, Node leftChild, Node rightChild)
        {
            SplitFeatureIndex = splitFeatureIndex;
            SplitThreshold = splitThreshold;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
