using System.Diagnostics;
using MatrixExperiment;

namespace Task_Three
{
    public static class Executor
    {
        public static void ExecuteAllTasks()
        {
            //HeapSort h = new HeapSort();
            //for (int i = 0; i < Project.Core.DataBase.Data[0].Length / 10; i += 1000)
            //{
            //    int[] elem = new int[i + 1];
            //    for (int j = 0; j < i; j++)
            //    {
            //        elem[j] = Project.Core.DataBase.Data[0][j];
            //    }
            //    List<long> timeList = new List<long>();
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Stopwatch timer = new Stopwatch();
            //        timer.Start();
            //        SelectionSort.SortBySelection(elem);
            //        timer.Stop();
            //        timeList.Add(timer.ElapsedTicks);
            //    }
            //    h.sort(elem);
            //    double time = HelpMethods.FindMiddleTime(timeList);
            //    FileWriter.WriteData(time, elem.Length, "SelectionSort.csv");
            //}
            for (int i = 0; i < 1000000; i += 1000)
            {
                Eratosfen.Erat(i);
            }
        }
    }
    public class SelectionSort
    {
        static public void SortBySelection(int[] array) // Сортировка Выбором
        {

            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                int largestIndex = 0;
                for (int i = 1; i <= partIndex; i++)
                {

                    if (array[largestIndex] < array[i])
                    {
                        largestIndex = i;
                    }

                }
                Swap(array, largestIndex, partIndex);
            }

        }
        static public void Swap(int[] array, int i, int j) // Меняем местами переменные
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
    public static class Eratosfen
    {
        public static void Erat(int n)
        {
            List<long> timeList = new List<long>();
            for (int k = 0; k < 5; k++)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                List<bool> l = new List<bool>();
                for (int i = 0; i < n + 1; i++)
                {
                    l.Add(true);
                }
                for (int i = 2; i * i <= n; i++)
                {
                    if ((l[i]) == true)
                    {
                        for (int j = i * i; j <= n; j += i)
                        {
                            l[j] = false;
                        }
                    }
                }
                if (k == 4)
                {
                    for (int i = 2; i < n; i++)
                    {
                        if (l[i] == true) Console.WriteLine(i);
                    }
                }
                timer.Stop();
                timeList.Add(timer.ElapsedTicks);
            }
            double time = HelpMethods.FindMiddleTime(timeList);
            Console.WriteLine("Eratosfen!");
            Console.WriteLine("Время: " + time);
            MatrixExperiment.FileWriter.WriteData(time, n, "Erat.csv");
        }
        public static void Erat()
        {
            for (int n = 0; n  < 1000000; n += 1000)
            {
                List<long> timeList = new List<long>();
                for (int k = 0; k < 5; k++)
                {
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    List<bool> l = new List<bool>();
                    for (int i = 0; i < n + 1; i++)
                    {
                        l.Add(true);
                    }
                    for (int i = 2; i * i <= n; i++)
                    {
                        if ((l[i]) == true)
                        {
                            for (int j = i * i; j <= n; j += i)
                            {
                                l[j] = false;
                            }
                        }
                    }
                    if (k == 4)
                    {
                        for (int i = 2; i < n; i++)
                        {
                            if (l[i] == true) Console.WriteLine(i);
                        }
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                Console.WriteLine("Eratosfen!");
                Console.WriteLine("Время: " + time);
                MatrixExperiment.FileWriter.WriteData(time, n, "Erat.csv");
            }
        }
    }
    public class HeapSort
    {
        public void sort(int[] arr)
        {
            List<long> timeList = new List<long>();
            for (int j = 0; j < 5; j++)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                int n = arr.Length;

                // Построение кучи (перегруппируем массив)
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);

                // Один за другим извлекаем элементы из кучи
                for (int i = n - 1; i >= 0; i--)
                {
                    // Перемещаем текущий корень в конец
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;

                    // вызываем процедуру heapify на уменьшенной куче
                    heapify(arr, i, 0);
                }
                timer.Stop();
                timeList.Add(timer.ElapsedTicks);
            }
            double time = HelpMethods.FindMiddleTime(timeList);
            FileWriter.WriteData(time, arr.Length, "HeapSort.csv");
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в arr[]. n - размер кучи

        void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                heapify(arr, n, largest);
            }
        }

        /* Вспомогательная функция для вывода на экран массива размера n */
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.Read();
        }

        //Управляющая программа
        //public static void Main()
        //{
        //    int[] arr = { 4, 85, 37, 103, 1 };
        //    int n = arr.Length;

        //    HeapSort ob = new HeapSort();
        //    ob.sort(arr);

        //    Console.WriteLine("Sorted array is");
        //    printArray(arr);
        //}
    }

}
