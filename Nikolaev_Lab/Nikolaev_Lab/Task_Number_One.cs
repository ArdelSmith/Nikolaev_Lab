using Generator;
using System.Diagnostics;
using Project.Core;
using MatrixExperiment;

namespace Task_One
{
    public static class Executor
    {
        public static void ExecuteAllTasks()
        {
            // Task1.PrintVector();
            // Task2.SummElems();
            // Task3.MulElems();
            // Task4.Polynomial();
            // Task5.StartBubbleSort();
            // Task6.QuickSort();
            Task7.TimSort();
            //for (int i = 1; i <= 4; i++)
            //{
            //    for (int degree = 0; degree <= 100000; degree += 100)
            //    {
            //        long number = 2;
            //        Task8.Pow(number, degree, i);
            //    }
            //}
        }
    }
    public static class Task1
    {
        /// <summary>
        /// Выполняет первый пункт, выводит на экран вектор (элементы не отображаются, константное время)
        /// </summary>
        public static void PrintVector()
        {
            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                List<long> timeList = new List<long>();
                int[] vector = DataBase.Data[i];
                for (int j = 0; j < 5; j++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    Console.WriteLine(vector);
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = MatrixExperiment.HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("1!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, DataBase.Data[i].Length, "vector.csv");
            }

        }
    }
    public static class Task2
    {
        /// <summary>
        /// Выполняет второй пункт
        /// </summary>
        public static void SummElems() // Сумма элементов
        {
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                List<long> timeList = new List<long>();
                string[] data = DataBase.RawData[i].Split(" ");
                for (int j = 0; j < 5; j++)
                {
                    timer.Reset();
                    long sum = 0;
                    timer.Start();
                    for (int k = 0; k < DataBase.Data[i].Length; k++)
                    {
                        sum += int.Parse(data[k]);
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = MatrixExperiment.HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("2!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, data.Length, "SummeElems.csv");
            }
        }

    }
    public static class Task3
    {
        /// <summary>
        /// Выполняет третий пункт, время - O(n)
        /// </summary>
        public static void MulElems()
        {

            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                List<long> timeList = new List<long>();
                for (int k = 0; k < 5; k++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Reset();
                    string[] data = DataBase.RawData[i].Split(" ");
                    long mul = 0;
                    timer.Start();
                    for (int j = 0; j < DataBase.Data[i].Length; j++)
                    {
                        mul *= int.Parse(data[j]);
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("3!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, DataBase.Data[i].Length, "MulElems.csv");
            }
        }
    }
    public static class Task4
    {
        static public void Polynomial()
        {
            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                int[] numbersArray = DataBase.Data[i];
                Function4dot1(numbersArray);
                List<long> timeList = new List<long>();
                for (int j = 0; j < 5; j++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    Function4dot2(numbersArray.ToList());
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("4.2!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, numbersArray.Length, "Polynom_2.csv");
            }


        }
        public static double Function4dot1(int[] numbersArray)
        {
            List<long> timeList = new List<long>();
            double result = 0;
            for (int j = 0; j < 5; j++)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                result = 0;
                for (int i = 0; i < numbersArray.Length - 1; i++)
                {
                    result += (double)numbersArray[i + 1] * Math.Pow(1.5, i);
                }
                timer.Stop();
                timeList.Add(timer.ElapsedTicks);
            }
            double time = HelpMethods.FindMiddleTime(timeList);
            Console.WriteLine("4.1!");
            Console.WriteLine("Время: " + time);
            MatrixExperiment.FileWriter.WriteData(time, numbersArray.Length, "Polynom_1.csv");
            return result;
        }

        public static double Function4dot2(List<int> numbersArray)
        {
            double result = 0;
            if (numbersArray.Count != 0)
            {
                result += numbersArray[0];
                numbersArray.RemoveAt(0);
                result += 1.5 * Function4dot2(numbersArray);
                return result;
            }
            else
            {
                return 0;
            }
        }

    }
    public static class Task5
    {
        /// <summary>
        /// Выполняет пятый пункт, максимальное время - O(n^2)
        /// </summary>
        public static void StartBubbleSort()
        {

            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                List<long> timeList = new List<long>();
                for (int e = 0; e < 5; e++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    int[] data = DataBase.Data[i];
                    for (int j = 0; j < data.Length; j++)
                    {
                        timer.Reset();
                        timer.Start();
                        for (int k = 0; k < data.Length - 1; k++)
                        {
                            if (data[k] > data[k + 1])
                            {
                                int t = data[k + 1];
                                data[k + 1] = data[k];
                                data[k] = t;
                            }
                        }
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("5!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, DataBase.Data[i].Length, "BubbleSort.csv");
            }
        }
        public static void StartBubbleSort(int[] arr)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int j = 0; j < arr.Length; j++)
            {

                for (int k = 0; k < arr.Length - 1; k++)
                {
                    if (arr[k] > arr[k + 1])
                    {
                        int t = arr[k + 1];
                        arr[k + 1] = arr[k];
                        arr[k] = t;
                    }
                }
            }
            timer.Stop();
            string res = "";
            for (int e = 0; e < arr.Length; e++)
            {
                res += (arr[e] + " ");
            }
            Console.WriteLine("5!");
            Console.WriteLine(res + "Время: " + (new TimeSpan(timer.ElapsedTicks)).TotalMilliseconds);
            MatrixExperiment.FileWriter.WriteData((new TimeSpan(timer.ElapsedTicks)).TotalMilliseconds, arr, "BubbleSort.csv");
        }
    }
    public static class Task6
    {
        static public void QuickSort()
        {
            for (int i = 0; i < DataBase.Data.Count; i++)
            {
                List<long> timeList = new List<long>();
                int[] array = DataBase.Data[i];
                for (int j = 0; j < 5; j++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    StartSorting(array);
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("6!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, array.Length, "QuickSort.csv");
            }
        }
        static private void StartSorting(int[] array) // Быстрая Сортировка
        {
            Sort(0, array.Length - 1);
            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }
            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                            break;
                    }
                    while (pivot < array[--j])
                    {
                        if (j == low)
                            break;
                    }
                    if (i >= j)
                        break;
                    Swap(array, i, j);
                }
                Swap(array, low, j);
                return j;
            }
            static void Swap(int[] array, int i, int j) // Меняем местами переменные
            {
                if (i == j)
                    return;
                int box = array[j];
                array[j] = array[i];
                array[i] = box;
            }
            //
            //  8   9   0   3   2   43  32  1
            //                                |partIndex
            //  
            //
            //
        }
    }
    public static class Task7
    {
        public const int RUN = 32;

        // This function sorts array from left index to
        // to right index which is of size atmost RUN
        public static void TimSort()
        {
            for (int i = 0; i < DataBase.Data[0].Length / 10; i += 100)
            {
                int[] r_arr = DataBase.Data[0];
                List<int> list = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    list.Add(DataBase.Data[0][j]);
                    
                }
                List<long> timeList = new List<long>();
                for (int j = 0; j < 5; j++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    StartTimSort(list.ToArray(), list.Count);
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("7!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, list.Count, "TimSort.csv");
            }

        }
        public static void insertionSort(int[] arr,
                                    int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        // merge function merges the sorted runs
        public static void merge(int[] arr, int l,
                                       int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }

        // Iterative Timsort function to sort the
        // array[0...n-1] (similar to merge sort)
        private static void StartTimSort(int[] arr, int n)
        {

            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
                insertionSort(arr, i,
                             Math.Min((i + RUN - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN; size < n;
                                     size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n;
                                      left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left +
                                        2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        merge(arr, left, mid, right);
                }
            }
        }

        // Utility function to print the Array
        public static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");
        }

        // Driver program to test above function
    }
    public static class Task8
    {
        public static int stepCount = 0;

        public static long Function8dot1(long number, int degree) // Возведение в степень (простой алгоритм)
        {
            long output = 1;
            while (degree > 0)
            {
                output *= number;
                degree--;
                stepCount += 2;
            }
            return output;
        }

        public static long Function8dot2(long number, int degree) // Возведение в степень (рекурсивный алгоритм)
        {
            long output;
            if (degree == 0)
                return 1;
            else
            {
                output = Function8dot2(number, degree / 2);
                if (degree % 2 == 1)
                {
                    stepCount += 2;
                    return output * output * number;
                }
                else
                {
                    stepCount += 1;
                    return output * output;
                }
            }
        }

        public static long Function8dot3(long number, int degree) // Возведение в степень (быстрый алгоритм)
        {
            long output = 1;
            if (degree % 2 == 1)
            {
                output = number;
            }
            else
            {
                output = 1;
            }
            do
            {
                degree = degree / 2;
                number *= number;
                stepCount += 2;

                if (degree % 2 == 1)
                {
                    output *= number;
                    stepCount += 1;
                }
            } while (degree != 0);
            return output;
        }

        public static long Function8dot4(long number, int degree) // Возведение в степень (классический быстрый алгоритм)
        {
            long output = 1;
            while (degree != 0)
            {
                if (degree % 2 == 0)
                {
                    number *= number;
                    degree /= 2;
                    stepCount += 2;
                }
                else
                {
                    output *= number;
                    degree -= 1;
                    stepCount += 2;
                }
            }
            return output;
        }
        static public void Pow(long number, int degree, int pow)
        {
            stepCount = 0;
            if (pow == 1)
            {
                long result = Function8dot1(number, degree);
                Console.WriteLine("8.1!");
                Console.WriteLine("Кол-во шагов: " + stepCount);
                MatrixExperiment.FileWriter.WriteData(degree, stepCount, "Function8_1.csv");
            }
            else if (pow == 2)
            {
                long result = Function8dot2(number, degree);
                Console.WriteLine("8.2!");
                Console.WriteLine("Кол-во шагов: " + stepCount);
                MatrixExperiment.FileWriter.WriteData(degree, stepCount, "Function8_2.csv");
            }
            else if (pow == 3)
            {
                long result = Function8dot3(number, degree);
                Console.WriteLine("8.3!");
                Console.WriteLine("Кол-во шагов: " + stepCount);
                MatrixExperiment.FileWriter.WriteData(degree, stepCount, "Function8_3.csv");
            }
            else if (pow == 4)
            {
                long result = Function8dot4(number, degree);
                Console.WriteLine("8.4!");
                Console.WriteLine("Кол-во шагов: " + stepCount);
                MatrixExperiment.FileWriter.WriteData(degree, stepCount, "Function8_4.csv");
            }
        }
    }
}

