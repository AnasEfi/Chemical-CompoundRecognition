using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aspose.Cells;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Runtime.InteropServices;
using Accord.Controls;
using Accord.Statistics;
using Accord.Math;
using DecisionTreeAccord;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math.Optimization.Losses;
using System.Diagnostics.Eventing.Reader;

namespace ChemicalСompoundRecognition
{
    public partial class Form1 : Form
    {
        private static Bitmap? ActiveGraph = null;
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += form_DragEnter;
            this.DragDrop += form_DragDrop;
        }

        private void form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files?.Length <= 0 || new[] { files[0].Split('.').Last() }.Any(end =>
            {
                var validFormats = new[] { "png", "jpg", "jpeg", "gif", "bmp" };
                if (validFormats.Where(f => f.ToLower().Equals(end.ToLower())).FirstOrDefault() == null)
                    return false;
                return true;
            }) == false) return;

            var firstFile = files[0];
            Bitmap fileBitmap = new Bitmap(firstFile);
            pictureBox1.Image = fileBitmap;
            ActiveGraph = fileBitmap;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (ActiveGraph == null || !int.TryParse(textBox3.Text, out int step) || step <= 0) return;
            GetCoordinates(step);
            // GetMatrix();
        }

        private void GetCoordinates(int step)
        {
            var coordinates = new List<Point>();
            var transformedCoordinates = new List<Point>();
            var width = ActiveGraph.Width;
            var height = ActiveGraph.Height;

            for (var x = 0; x < width; x += step)
            {
                for (var y = 0; y < height; y++)
                {
                    var pixel = ActiveGraph.GetPixel(x, y);
                    if (pixel.R <= 120 && pixel.G <= 120 && pixel.B <= 120) { coordinates.Add(new Point(x, y)); break; }
                }
            }
            textBox1.Clear();
            try
            {
                transformedCoordinates = TransformCoordinates(coordinates, height, width);
            }
            catch (BadInputException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            //coordinates.ForEach(point => textBox1.AppendText($"[{point.X},{point.Y}]" + Environment.NewLine));
            transformedCoordinates.ForEach(point => textBox1.AppendText($"[{point.X},{point.Y}]" + Environment.NewLine));

            Workbook wb = new Workbook("test2.xlsx");
            WorksheetCollection collection = wb.Worksheets;
            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                Console.WriteLine("Worksheet: " + worksheet.Name);
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                double[][] av = new double[rows][];
                for (int i = 1; i <= rows; i++)
                {
                    av[i - 1] = new double[cols - 1];
                    for (int j = 1; j < cols - 1; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].DoubleValue;
                        textBox1.AppendText(worksheet.Cells[i, j].Value + "|");

                        if (i > 0)
                        {
                            av[i - 1][j - 1] = ((int)cellValue);
                        }
                    }
                    textBox1.AppendText(Environment.NewLine);


                }
                var transformPCA = new PCA();
                var transfprmedData = transformPCA.PCAMethod(av);
            }
        }

        private List<Point> TransformCoordinates(List<Point> coordenates, int height, int width)
        {
            List<Point> TransformedCoordinates = new List<Point>();
            if (!int.TryParse(textBox4.Text, out int userWidthMax) || !int.TryParse(textBox2.Text, out int userWidthMin))
                throw new BadInputException("Input a correct number");

            foreach (Point currentCoordinate in coordenates)
            {
                var transfCoordinateX = (-1) * ((currentCoordinate.X * (userWidthMax - userWidthMin) / width) - userWidthMax);
                var transfCoordinateY = currentCoordinate.Y * 100 / height;
                TransformedCoordinates.Add(new Point(transfCoordinateX, transfCoordinateY));
            }
            return TransformedCoordinates;
        }

       /* private void ConculationMean(int[][] data)
        {
            if (data.Length == 0)
                throw new Exception("data empty");

            var rows = data.Length;
            var columns = data[0].Length;
            var meanArray = new double[columns];

            for (int c = 0; c < columns; c++)
            {
                meanArray[c] = 0;
                for (int r = 0; r < rows; r++)
                {
                    meanArray[c] += data[r][c];
                }
                meanArray[c] /= rows;
            }
            /*
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    sum += data[j][i];
                }
                means.Add(sum / rows);
            }
            */
            /* double sum2 = 0.0;
             List<double> d = new List<double>();
             for (int i = 0; i < columns; i++)
             {
                 for (int j = 0; j < rows; j++)
                 {
                     sum2 += (data[j][i] - means[i]) * (data[j][i] - means[i]);
                 }
                 sum2 = Math.Sqrt(sum2 / rows);
                 d.Add(sum2);
             }
            */
            /*
             double[,] covarianceMatrix = new double[columns, columns];

             for (int col1 = 0; col1 < columns; col1++)
             {
                 for (int col2 = 0; col2 < columns; col2++)
                 {
                     double sum3 = 0.0;

                     for (int k = 0; k < rows; k++)
                     {
                         sum3 += (data[k][col1] - meanArray[col1] * (data[k][col2] - meanArray[col2]));
                     }
                     covarianceMatrix[col1, col2] = sum3 / (rows - 1);
                 }
            */
            /*
            var covariance = new double[columns, columns];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double sum2 = 0.0;
                    for (int r = 0; r < rows; r++)
                    {
                        sum2 += (data[r][i] - meanArray[i]) * (data[r][j] - meanArray[j]);
                    }
                    covariance[i, j] = sum2 / (rows - 1);
                }
            }
            //transform data
            double[,] resultData = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 1; j < rows; j++)
                {
                    resultData[i, j] = data[i][j];
                }
            }

            Matrix<double> dataMatrix = DenseMatrix.OfArray(resultData);
            Matrix<double> covarianceMatrixa = DenseMatrix.OfArray(covariance);
            Evd<double> eigen = covarianceMatrixa.Evd();



            MathNet.Numerics.LinearAlgebra.Vector<double> eigenValues = eigen.EigenValues.Real();
            Matrix<double> eigenVectors = eigen.EigenVectors;

            double[] eigenValuesArray = eigenValues.ToArray();

            int[] sortedIndices = eigenValuesArray
                .Select((value, index) => new { Value = value, Index = index })
                .OrderByDescending(x => x.Value)
                .Select(x => x.Index)
                .ToArray();


            // Select the eigenvectors corresponding to the largest eigenvalues
            Matrix<double> selectedEigenVectors = eigenVectors.SubMatrix(0, eigenVectors.RowCount, 0, 10);

            // Perform dimensionality reduction
            Matrix<double> reducedData = dataMatrix.Multiply(selectedEigenVectors);
        }

        private void PrincipalComponentMethod()
        {
            Workbook wb = new Workbook("test2.xlsx");
            WorksheetCollection collection = wb.Worksheets;
            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                Console.WriteLine("Worksheet: " + worksheet.Name);
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                int[][] av = new int[rows][];
                for (int i = 1; i <= rows; i++)
                {
                    av[i - 1] = new int[cols - 1];
                    for (int j = 1; j < cols - 1; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].DoubleValue;
                        textBox1.AppendText(worksheet.Cells[i, j].Value + "|");

                        if (i > 0)
                        {
                            av[i - 1][j - 1] = ((int)cellValue);
                        }
                    }
                    textBox1.AppendText(Environment.NewLine);
                }

                //calculations

                // var convarianceMatrix = Matrix<int>.Build.DenseOfArray(av).Covariance();
                ConculationMean(av);
            }
        } */

        private void GetMatrix()
        {
            var matrix = new List<PixelColor>();
            var width = ActiveGraph.Width;
            var height = ActiveGraph.Height;

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var pixel = ActiveGraph.GetPixel(x, y);
                    if (pixel.R <= 120 && pixel.G <= 120 && pixel.B <= 120)
                        matrix.Add(new PixelColor(x, y, 1));
                    else matrix.Add(new PixelColor(x, y, 0));
                }
            }

            PixelColor.SavePixelColorsIntoFile(matrix);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AllocConsole();
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Workbook wb = new Workbook("test2.xlsx");
            WorksheetCollection collection = wb.Worksheets;
            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                Console.WriteLine("Worksheet: " + worksheet.Name);
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                double[][] av = new double[rows][];
                for (int i = 1; i <= rows; i++)
                {
                    av[i - 1] = new double[cols];
                    for (int j = 1; j <= cols; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].DoubleValue;
                        textBox1.AppendText(worksheet.Cells[i, j].Value + "|");

                        if (i > 0)
                        {
                            av[i - 1][j - 1] = ((int)cellValue);
                        }
                    }
                    textBox1.AppendText(Environment.NewLine);
                }

                DataAnalysis K_Method = new DataAnalysis();
                K_Method.KNeighbours(av, cols);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workbook wb = new Workbook("test2.xlsx");
            WorksheetCollection collection = wb.Worksheets;

            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                Console.WriteLine("Worksheet: " + worksheet.Name);
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                int[][] av = new int[rows][];
                int[] classes = new int[rows];
                for (int i = 1; i <= rows; i++)
                {
                    av[i - 1] = new int[cols - 1];
                    for (int j = 1; j <= cols - 1; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].DoubleValue;
                        textBox1.AppendText(worksheet.Cells[i, j].Value + "|");

                        if (i > 0)
                        {
                            av[i - 1][j - 1] = ((int)cellValue);
                        }

                    }
                    textBox1.AppendText(Environment.NewLine);
                    if ((int)worksheet.Cells[i, cols].DoubleValue == 1)

                        classes[i - 1] = 0;
                    else classes[i - 1] = 1;
                }


                //var treeTry = new DecisionTreeProgram();

                // treeTry.TreeDecision(av, classes);
                // var tree = new DecisionTreeGPT();
                //tree.GetTree(av, classes);
                ID3Learning teacher = new ID3Learning();

                // Learn a decision tree for the XOR problem
                Accord.MachineLearning.DecisionTrees.DecisionTree tree = null;
                try
                {
                    
                    tree = teacher.Learn(av, classes);
                  
                }
                catch (Exception ex)
                {
                    return;
                }
                // Compute the error in the learning
                double error = new ZeroOneLoss(classes).Loss(tree.Decide(av));

                // The tree can now be queried for new examples:
                int[] predicted = tree.Decide(av);


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Workbook wb = new Workbook("test2.xlsx");
            WorksheetCollection collection = wb.Worksheets;

            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                Worksheet worksheet = collection[worksheetIndex];
                Console.WriteLine("Worksheet: " + worksheet.Name);
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                double[][] av = new double[rows][];
                int[] classes = new int[rows];
                int[] classesNum = new int[rows];

                for (int i = 1; i <= rows; i++)
                {
                    av[i - 1] = new double[cols - 1];
                    for (int j = 1; j <= cols - 1; j++)
                    {
                        var cellValue = worksheet.Cells[i, j].DoubleValue;
                        textBox1.AppendText(worksheet.Cells[i, j].Value + "|");

                        if (i > 0)
                        {
                            av[i - 1][j - 1] = ((int)cellValue);
                        }

                    }
                    textBox1.AppendText(Environment.NewLine);
                    if ((int)worksheet.Cells[i, cols].DoubleValue == 1)
                    {
                        classesNum[i - 1] = 1;
                        classes[i - 1] = -1;
                    }
                    else
                    {
                        classes[i - 1] = 1;
                        classesNum[i - 1] = 0;
                    }
                }
                // var svm = new SVM();
                // svm.SVMethod(av, av[rows - 1], classes);
                var svm2 = new SVM2();
                svm2.SVM2Method(av, av[rows - 1], classesNum);

            }
        }

        private void scatterplotView1_Load(object sender, EventArgs e)
        {

        }

        struct PixelColor
        {
            public int X;
            public int Y;
            public int Color;
            public PixelColor(int x, int y, int c)
            {
                X = x;
                Y = y;
                Color = c;
            }

            public static void SavePixelColorsIntoFile(List<PixelColor> collection)
            {
                if (collection?.Count == 0) return;

                string fileText = string.Empty;

                var currentLine = collection[0].Y;
                collection.ForEach(pixel =>
                {
                    if (currentLine != pixel.Y)
                    {
                        fileText += Environment.NewLine;
                        currentLine++;
                    }

                    fileText += pixel.Color;
                });

                File.WriteAllText("graphMatrix.txt", fileText);
            }
        }
    }
}

