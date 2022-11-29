
using System;

namespace Lab_4
{
    public static class Logariphmic
    {
        static List<string> log = new List<string>();
        private static int arrayMin;

        public static void SortWithQuickSort(int[] a)
        {
            log.Add($"\nВаш массив: {a.ArrayToString()}");
            QuickSort(a);
            log.Add("\nСортировка завершена");
            log.Add($"\nВаш отсортированный массив: {a.ArrayToString()}");
        }
        //метод для обмена элементов массива
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                log.Add($"Сравниваем: {array[i]} (индекс {i}) < {array[maxIndex]} (индекс {maxIndex})");
                if (array[i] < array[maxIndex])
                {
                    log.Add($"{array[i]} (индекс {i}) < {array[maxIndex]} (индекс {maxIndex}), меняем их местами");
                    pivot++;
                    log.Add($"Изменение опорного элемента: {array[pivot]}");
                    Swap(ref array[pivot], ref array[i]);
                    log.Add("Массив принял вид:");
                    log.Add(array.ArrayToString());
                }
            }
            pivot++;
            log.Add($"Меняем местами элемент {array[pivot]} с индексом {pivot} и элемент {array[maxIndex]} с индексом {maxIndex}");
            log.Add("Массив принял вид:");
            Swap(ref array[pivot], ref array[maxIndex]);
            log.Add(array.ArrayToString());
            return pivot;
        }
  
        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            log.Add($"\nПоиск опорного элемента массива {array.ArrayToString()}");
            var pivotIndex = Partition(array, minIndex, maxIndex);
            int[] arrayMin = new int[pivotIndex];
            int[] arrayMax = new int[array.Length - pivotIndex - 1];
            
            Array.Copy(array, 0, arrayMin, 0, pivotIndex);
            Array.Copy(array, pivotIndex + 1, arrayMax, 0, array.Length - pivotIndex -1 );
            log.Add($"Опорный элемент найден: {array[pivotIndex]}, делим массив на две части: {arrayMin.ArrayToString()} (элементы меньше опорного) и {arrayMax.ArrayToString()} (элементы больше опорного)");
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);
           
            FileWriter.WriteFile(log.ToArray(), "Quick.txt");
            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }
}