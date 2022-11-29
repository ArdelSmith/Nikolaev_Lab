using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public static class ArrayExtensions
    {
        public static string ArrayToString<T>(this T[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            int c = 1;
            foreach (T item in array)
            {
                if (c != array.Length)
                {
                    sb.Append(item.ToString() + ", ");
                    c++;
                }
                else
                {
                    sb.Append(item.ToString() + " }");
                }
            }
            return sb.ToString();
        }
    }
    public static class SubQuadro
    {
        /// <summary>
        /// Сортирует переданный массив при помощи сортировки вставками
        /// </summary>
        /// <param name="array">Массив, который нужно отсортировать</param>
        /// <param name="latency">Задержка вывода операций (милисекунд)</param>
        public static void SortWithInsert(int[] array)
        {
            InsertionSort(array);
        }
        private static void Swap(int[] array, int i, int j, List<string> log)
        {
            log.Add($"Меняем местами: {array[j]} и {array[i]}");
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static int[] ArrayCopy(int[] array, int lenth)
        {
            int[] copyArray = new int[lenth];
            for (int i = 0; i < lenth; i++)
            {
                copyArray[i] = array[i];
            }
            return copyArray;
        }

        private static int[] InsertionSort(int[] array)
        {
            List<string> log = new List<string>();
            int[] arraySorted = ArrayCopy(array, 1);
            log.Add($"\nВаш массив: {array.ArrayToString()}");
            arraySorted = ArrayCopy(array, 1);
            log.Add($"\nОтсортированная часть массива {arraySorted.ArrayToString()}. По умолчанию туда входит первый элемент массива");
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int currentUnsorted = array[partIndex];
                int i = partIndex;
                int count = 0;
                
                log.Add($"\nРассмотрим элемент с значением {array[i - 1]} (индекс {i - 1}) и элемент из неотсортированной части с значением {currentUnsorted} (индекс {partIndex}) и сравним их между собой");
                while (i > 0 && array[i - 1] > currentUnsorted)
                {
                    count++;
                    arraySorted = ArrayCopy(array, i + count);
                    log.Add($"{array[i - 1]} > {currentUnsorted}");
                    Swap(array, i, i - 1, log);
                    arraySorted = ArrayCopy(array, i + count);
                    log.Add($"Массив: {array.ArrayToString()}. Отсортированная часть массива после вставки текущего элемента {arraySorted.ArrayToString()}. В очереди {array.Length - partIndex - 1} элемент(а/ов)");
                    i -= 1;
                }
                array[i] = currentUnsorted;
            }
            log.Add("\nСортировка завершена");
            log.Add($"\nВаш отсортированный массив: {array.ArrayToString()}");
            FileWriter.WriteFile(log.ToArray(), "InsertionSort.txt");
            return array;
        }
    }
}
