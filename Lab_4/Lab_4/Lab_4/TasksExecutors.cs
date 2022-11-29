using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public static class TaskExecutor
    {
        public static void ExecuteTask1()
        {
            int latency;
            Console.WriteLine("Enter your array, use space to separate elements:");
            string[] a = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] aa = new int[a.Length];
            int[] bb = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                aa[i] = int.Parse(a[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                bb[i] = int.Parse(a[i]);
            }
            Console.WriteLine("Write your latency (yourLatency / 1000 seconds)");
            latency = int.Parse(Console.ReadLine());
            SubQuadro.SortWithInsert(aa);
            Logariphmic.SortWithQuickSort(bb);
            string[] insertion = File.ReadAllLines("InsertionSort.txt");
            string[] quick = File.ReadAllLines("Quick.txt");
            Console.WriteLine("\n");
            Console.WriteLine("Сортировка вставками:");
            foreach (string elem in insertion)
            {
                Console.WriteLine(elem);
                Thread.Sleep(latency);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Быстрая сортировка:");
            foreach (string elem in quick)
            {
                Console.WriteLine(elem);
                Thread.Sleep(latency);
            }
        }
        public static void ExecuteTask2()
        {
            ExternalSorts.StartExternalSorts();
        }
        public static void ExecuteTask3()
        {
            Task3 b = new Task3();
            b.ExecuteTask3(File.ReadAllText("text.csv"));
        }
    }
}
