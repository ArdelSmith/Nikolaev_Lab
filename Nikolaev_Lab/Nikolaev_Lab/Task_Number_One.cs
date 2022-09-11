using Generator;
using System.Diagnostics;

namespace Task_Number_One
{
    public class Task1
    {
        /// <summary>
        /// Выполняет первый пункт, выводит на экран вектор (элементы не отображаются, константное время)
        /// </summary>
        public static void ExecuteTaskOne()
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
        public static void ExecuteTaskThree()
        {
            Stopwatch stopWatch = new Stopwatch();

        }
    }
}
