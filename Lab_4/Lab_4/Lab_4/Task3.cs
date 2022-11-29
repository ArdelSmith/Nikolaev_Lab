using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_4
{
    public class Task3
    {
        public void ExecuteTask3(string data)
        {
            string text = data;
            char[] separators = new[] { ' ', '\n', '\r', '\t', ';', '.', '!', '?', ',', ':', '-', '+', '=', '*', '\\', '/', '—', '<', '>', '\"', '\'', '[', ']', '(', ')', '{', '}' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] words1 = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> w = new List<string>();
            List<string> w1 = new List<string>();
            ABC_Sorter a = new ABC_Sorter(words);
            a.AbcSort();
            ABC_Sorter.PrintDict(ABC_Sorter.CreateDictionary());
            //добавляем в списки строк слова в количестве n штук
            //for (int i = 0; i < words.Length; i += 500)
            //{
            //    for (int j = i; j < i + 500; j++)
            //    {
            //        w.Add(words[j]);
            //        w1.Add(words1[j]);
            //    }
            //    List<long> time = new List<long>();
            //    for (int k = 0; k < 5; k++)
            //    {
            //        //var myStopwatch = new Stopwatch();
            //        var myStopwatch1 = new Stopwatch();
            //        //myStopwatch.Start();
            //        //SelectionSort(w.ToArray(), w.ToArray().Length);
            //        //myStopwatch.Stop();
            //        ABC_Sorter a = new ABC_Sorter(w1.ToArray());
            //        myStopwatch1.Start();
            //        a.AbcSort();
            //        myStopwatch1.Stop();
            //        time.Add(myStopwatch1.ElapsedTicks);
            //        //FileWriter.WriteFile($"{i + 500};{(new TimeSpan(myStopwatch.ElapsedTicks)).TotalMilliseconds/10.0}\n", "ABC.csv");
            //    }
            //    time.Sort();
            //    FileWriter.WriteFile($"{i + 500};{(new TimeSpan(time[2])).TotalMilliseconds / 10.0}\n", "ABC.csv");
          
        }
            

           
        public static void SelectionSort(string[] arr, int size)
        {

            int smallest;
            string tmp;
            for (int i = 0; i < size - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (!needToReOrder(arr[j], arr[smallest]))
                    {
                        smallest = j;
                    }
                }

                tmp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = tmp;
            }
        }

        public static bool needToReOrder(string s1, string s2)
        {
            string tmp1 = s1.ToLower();
            string tmp2 = s2.ToLower();
            for (int i = 0; i < (tmp1.Length >= tmp2.Length ? tmp2.Length : tmp1.Length); i++)
            {
                if (tmp1.ToCharArray()[i] < tmp2.ToCharArray()[i]) return false;
                if (tmp1.ToCharArray()[i] > tmp2.ToCharArray()[i]) return true;
            }

            if (tmp1.Length > tmp2.Length)
            {
                return true;
            }

            return false;
        }
        static void HeapSort(string[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                string temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(arr, i, 0);
            }
        }

        static void Heapify(string[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && needToReOrder(arr[left], arr[largest]))
                largest = left;

            if (right < n && needToReOrder(arr[right], arr[largest]))
                largest = right;

            if (largest != i)
            {
                string swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                Heapify(arr, n, largest);
            }
        }
    }
}
