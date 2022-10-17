using System;
using System.Diagnostics;
namespace MatrixExperiment
{
    static class Launcher
    {
        public static void StartSecondTask()
        {
            string fileName = "MatrixTask.csv";
            for (int n = 1; n <= 100; n++)
            {
                for (int m = 1; m <= 100; m++)
                {
                    Console.WriteLine($"n = {n}");
                    Console.WriteLine($"m = {m}\n");

                    Matrix matrix1 = MatrixHelper.GenerateMatrix(n, m);
                    Matrix matrix2 = MatrixHelper.GenerateMatrix(m, n);

                    List<long> timeElems = new List<long>();
                    for (int i = 0; i < 5; i++)
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();

                        Matrix result = MatrixHelper.MulMatrixes(matrix1, matrix2);
                        timer.Stop();

                        long curTime = timer.ElapsedTicks;
                        timeElems.Add(curTime);
                        Console.WriteLine($"Время за {i + 1} выполнение программы: {curTime} мкс.");
                    }

                    double middleTime = HelpMethods.FindMiddleTime(timeElems);

                    Console.WriteLine($"\nСреднее время выполнения: {middleTime} мкс.\n");
                    Console.WriteLine("----------------------------------------------\n");

                    FileWriter.WriteData(middleTime, n, m);
                }
            }
            FileWriter.RewriteDataToSquare(fileName);
        }
    }
    public class Matrix
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public double[,] Elems { get; set; }
    }
    public class Cell
    {
        public double Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    class HelpMethods
    {
        //public static double FindMTCorrectly(List<long> timeList)
        //{
        //    timeList.Sort();
        //    int epsilon 
        //}
        public static double FindMiddleTime(List<long> allElems)
        {
            allElems.Sort();
            double sumTime = 0;

            List<long> selectedElems = new List<long>();
            List<long> selectedDists = new List<long>();

            for (int i = 0; i < allElems.Count - 2; i++)
            {
                long middleDist = selectedDists.Count == 0
                    ? allElems[i + 1] - allElems[i]
                    : selectedDists.Sum() / selectedDists.Count;

                long nextDist = allElems[i + 2] - allElems[i + 1];

                if (middleDist == 0) middleDist = +1;
                if (nextDist == 0) nextDist = +1;

                if (middleDist > nextDist * 20)
                {
                    for (int j = i + 1; j < allElems.Count; j++)
                        selectedElems.Add(allElems[j]);

                    foreach (long elem in selectedElems) sumTime += elem;
                    return sumTime / selectedElems.Count;
                }
                else if (nextDist > middleDist * 20)
                {
                    for (int j = 0; j <= i + 1; j++)
                        selectedElems.Add(allElems[j]);

                    foreach (long elem in selectedElems) sumTime += elem;
                    return sumTime / selectedElems.Count;
                }
            }

            foreach (long elem in allElems) sumTime += elem;
            return sumTime / allElems.Count;
        }
    }

    public static class MatrixHelper
    {
        public static Matrix GenerateMatrix(int height, int width)
        {
            double[,] elems = new double[height, width];
            Random rnd = new Random();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    elems[i, j] = rnd.Next(9);

            return new Matrix { Height = height, Width = width, Elems = elems };
        }

        public static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Height; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < matrix.Width; j++)
                {
                    Console.Write($"{matrix.Elems[i, j]} ");
                }
            }
        }

        public static Matrix MulMatrixes(Matrix matrix1, Matrix matrix2)
        {
            double[,] muledElems = new double[matrix1.Height, matrix2.Width];

            for (int i = 0; i < matrix1.Height; i++)
                for (int j = 0; j < matrix2.Width; j++)
                    for (int k = 0; k < matrix1.Width; k++)
                        muledElems[i, j] += matrix1.Elems[i, k] * matrix2.Elems[k, j];

            return new Matrix { Height = matrix1.Height, Width = matrix2.Width, Elems = muledElems };
        }
    }
    public static class FileDeleter
    {
        public static void DeleteFile(string fullFileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
            if (File.Exists(path)) File.Delete(path);
        }
    }
    public static class FileWriter
    {
        public static void RewriteDataToSquare(string fileName)
        {
            List<Cell> cells = FileReader.ReadData(fileName);
            int size = (int)Math.Sqrt(cells.Count);

            double[,] table = new double[size, size];
            foreach (Cell cell in cells)
                table[cell.X, cell.Y] = cell.Value;

            string[] lines = new string[size];
            for (int i = 0; i < size; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < size; j++)
                {
                    line += $"{table[i, j]};";
                }
                lines[i] = line;
            }

            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            File.WriteAllLines(path, lines);
        }
        public static void WriteData(double time, string fullFileName) //работет для первой задачи, записывает только время
        {
            string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
            string line = $"{time / 10.0}\n";
            if (!File.Exists(path)) File.WriteAllText(path, line);
            else File.AppendAllText(path, line);
        }
        public static void WriteData(double time, double n, string fullFileName) //работет для первой задачи, n - количество элементов(может быть и числом с запятой
                                                                                 // в таком случае необходим для работы восьмого пункта задачи один
        {
            string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
            string line = $"{time};{n}\n";
            if (!File.Exists(path)) File.WriteAllText(path, line);
            else File.AppendAllText(path, line);
        }
        public static void WriteData(double time, double n, string fullFileName, bool flag) //работет для первой задачи и восьмого подпункта, n - количество элементов(может быть и числом с запятой
                                                                                            // в таком случае необходим для работы восьмого пункта задачи один, flag - указатель на то, один раз мы делаем запись или нет
                                                                                            // если false - то File.WriteAllText, иначе Append
        {
            if (flag)
            {
                string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
                string line = $"{time};{n}\n";
                if (!File.Exists(path)) File.WriteAllText(path, line);
                else File.AppendAllText(path, line);
            }
            else
            {
                string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
                string line = $"{time};{n}\n";
                File.WriteAllText(path, line);
            }

        }
        public static void WriteData(double time, int n, int m) // записывает время и данные конкретно для матриц
        {
            string path = Path.Combine(Environment.CurrentDirectory, "MatrixTask.csv");
            string line = $"{n};{m};{time / 10.0}\n";
            if (n == 1 && m == 1)
                File.WriteAllText(path, line);
            else
                File.AppendAllText(path, line);
        }
        public static void WriteData(double time, int[] arr, string fullFileName) //работет для третей задачи
        {
            string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
            string line = $"{arr};{time / 10.0}\n";
            if (!File.Exists(path)) File.WriteAllText(path, line);
            else File.AppendAllText(path, line);
        }

        public static void WriteData(int degree, int stepCount, string fullFileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fullFileName);
            string line = $"{degree};{stepCount * 100}\n";
            if (degree == 0) File.WriteAllText(path, line);
            else File.AppendAllText(path, line);
        }
    }
    public static class FileReader
    {
        public static List<Cell> ReadData(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            string[] data = File.ReadAllLines(path);
            string[][] parts = new string[data.Length][];

            for (int i = 0; i < data.Length; i++)
                parts[i] = data[i].Split(';');

            List<Cell> cells = new List<Cell>();
            for (int i = 0; i < data.Length; i++)
            {
                int x = int.Parse(parts[i][0]);
                int y = int.Parse(parts[i][1]);
                double valuse = double.Parse(parts[i][2]);

                cells.Add(new Cell { Value = valuse, X = x - 1, Y = y - 1 });
            }
            return cells;
        }

    }
}