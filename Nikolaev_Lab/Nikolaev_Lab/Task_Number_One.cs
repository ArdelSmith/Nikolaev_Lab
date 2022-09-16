using Generator;
using System.Diagnostics;
using Project.Core;

namespace Task_Number_One
{
    public class Task1
    {
        /// <summary>
        /// Выполняет первый пункт, выводит на экран вектор (элементы не отображаются, константное время)
        /// </summary>
        public static void PrintVector()
        {
            int[] vector = ArrayGenerator.GenerateArray();
            Console.WriteLine(vector);
        }
    }
    public class Task3
    {
        /// <summary>
        /// Выполняет третий пункт, время - O(n)
        /// </summary>
        public static void SummElements()
        {
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < DataBase.RawData.Length; i++)
            {
                timer.Reset();
                string[] data = DataBase.RawData[i].Split(" ");
                long sum = 0;
                timer.Start();
                for (int j = 0; j < data.Length; j++)
                {
                    sum += int.Parse(data[j]);
                }
                timer.Stop();
                Console.WriteLine(sum + " Время: " + timer.Elapsed);
            }
        }
    }
    public class Task5
    {
        /// <summary>
        /// Выполняет пятый пункт, максимальное время - O(n^2)
        /// </summary>
        public static void StartBubbleSort()
        {
            Stopwatch timer = new Stopwatch();
            for (int i = 0; i < DataBase.RawData.Length;i++)
            {
                string[] data = DataBase.RawData[i].Split(" "); 
                for (int j = 0; j < data.Length; j++)
                {
                    timer.Reset();
                    timer.Start();
                    for (int k = 0; k < data.Length - 1; k++)
                    {
                        if (int.Parse(data[k]) > int.Parse(data[k+1]))
                        {
                            string t = data[k + 1];
                            data[k + 1] = data[k];
                            data[k] = t;
                        }
                    }
                    timer.Stop();
                }
                string res = "";
                for (int e = 0; e < data.Length; e++)
                {
                    res += (data[e] + " ");
                }
                Console.WriteLine(res + "Время: " + timer.Elapsed);
            }
        }
    }
    public class Task7
    {

    }
}
