using System;
using System.Diagnostics;

namespace MatrixExperiment
{
    public class SquareMatrix
    {
        public int Size { get; set; }
        public double[,] Elems { get; set; }
    }

    class Program
    {
        static void Main()
        {
            for (int n = 1; n <= 1000; n++)
            {
                Console.WriteLine($"{n} ДАННЫХ\n");

                SquareMatrix matrix1 = MatrixHelper.GenerateSquareMatrix(n);
                SquareMatrix matrix2 = MatrixHelper.GenerateSquareMatrix(n);

                List<double> timeElems = new List<double>();
                for (int i = 0; i < 5; i++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    SquareMatrix result = MatrixHelper.MulMatrixes(matrix1, matrix2);
                    timer.Stop();

                    double curTime = timer.ElapsedTicks;
                    timeElems.Add(curTime);
                    Console.WriteLine($"Время за {i + 1} выполнение программы: {curTime} мкс.");
                }

                double middleTime = FindMiddleTime(timeElems);

                Console.WriteLine($"\nСреднее время выполнения: {middleTime} мкс.\n");
                Console.WriteLine("----------------------------------------------\n");

                FileWriter.WriteData(middleTime, n);
            }
        }

        static double FindMiddleTime(List<double> allElems)
        {
            allElems.Sort();
            double sumTime = 0;
            List<double> selectedElems = new List<double>();

            for (int i = 0; i < allElems.Count - 2; i++)
            {
                double curDist = allElems[i + 1] - allElems[i];
                double nextDist = allElems[i + 2] - allElems[i + 1];

                if (curDist == 0) ++curDist;
                if (curDist == 0) ++curDist;

                if (curDist > nextDist * 5)
                {
                    if (i < 2)
                        for (int j = i + 1; j < allElems.Count; j++)
                            selectedElems.Add(allElems[j]);
                    else
                        for (int j = 0; j <= i; j++)
                            selectedElems.Add(allElems[j]);

                    foreach (double elem in selectedElems) sumTime += elem;
                    return sumTime / selectedElems.Count;
                }
                else if (nextDist > curDist * 5)
                {
                    if (i < 1)
                        for (int j = i + 2; j < allElems.Count; j++)
                            selectedElems.Add(allElems[j]);
                    else
                        for (int j = 0; j <= i + 1; j++)
                            selectedElems.Add(allElems[j]);

                    foreach (double elem in selectedElems) sumTime += elem;
                    return sumTime / selectedElems.Count;
                }
            }

            foreach (double elem in allElems) sumTime += elem;
            return sumTime / allElems.Count;
        }
    }

    public static class MatrixHelper
    {
        public static SquareMatrix GenerateSquareMatrix(int size)
        {
            double[,] elems = new double[size, size];
            Random rn = new Random();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    elems[i, j] = rn.Next(9);

            return new SquareMatrix { Size = size, Elems = elems };
        }

        public static void PrintMatrix(SquareMatrix matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < matrix.Size; j++)
                {
                    Console.Write($"{matrix.Elems[i, j]} ");
                }
            }
        }

        public static SquareMatrix MulMatrixes(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            int size = matrix1.Size;
            double[,] muledElems = new double[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    for (int k = 0; k < size; k++)
                        muledElems[i, j] += matrix1.Elems[i, k] * matrix2.Elems[k, j];

            return new SquareMatrix { Size = size, Elems = muledElems };
        }
    }

    public static class FileWriter
    {
        public static void WriteData(double time, int n)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "OutputedData.csv");
            string line = $"{n};{time / 10.0}\n";


            File.AppendAllText(path, line);
        }
    }
}