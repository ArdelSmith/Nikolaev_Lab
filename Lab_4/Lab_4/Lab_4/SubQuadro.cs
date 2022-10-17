using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public static class SubQuadro
    {
        /// <summary>
        /// Сортирует переданный массив при помощи сортировки вставками
        /// </summary>
        /// <param name="array">Массив, который нужно отсортировать</param>
        /// <param name="latency">Задержка вывода операций (милисекунд)</param>
        public static void SortWithInsert(int[] array, int latency)
        {
            InsertionSort(array);
            System.Threading.Thread.Sleep(latency);
        }
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        private static void InsertionSort(int[] array)
        {
            List<string> log = new List<string>();
            int x;
            int j;
            for (int i = 1; i < array.Length; i++)
            {
                x = array[i];
                j = i;
                log.Add($"Элемент с индексом {j} и значением {array[j]} был сравнен с элементом индексом {j - 1} и значением {array[j - 1]}");
                while (j > 0 && array[j - 1] > x)
                {
                    log.Add($"Элемент с индексом {j} и значением {array[j]} поменялся местами с элементом индексом {j - 1} и значением {array[j - 1]}");
                    Swap(array, j, j - 1);
                    j -= 1;
                }
                array[j] = x;
            }
            log.Add("Сортировка завершена");
            FileWriter.WriteFile(log.ToArray(), "InsertionSort.txt");
        }
    }
    public class Program
    {
        public static void Main()
        {
            int[] arr = { 2, 5, 6, 1, 3, 4 };
            SubQuadro.SortWithInsert(arr, 500);
        }
    }
}
