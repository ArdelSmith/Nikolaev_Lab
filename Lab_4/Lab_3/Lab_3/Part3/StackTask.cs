using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Part1;

namespace Lab_3.Part3
{
    public static class StackTask
    {
        public static void ReverseNumber(int n)
        {
            MyStack<int> b = new MyStack<int>();
            string num = n.ToString();
            int f10 = (int) (Math.Pow(10, num.Length - 1));
            for (int i = 0; i < num.Length; i++)
            {
                int temp = n / f10 % 10;
                b.Push(temp);
                f10 /= 10;
            }
            string nn = "";
            for (int i = 0; !b.IsEmpty(); i++)
            {
                nn += b.Top();
                b.Pop();
            }
            Console.WriteLine(nn);
        }
    }
}
