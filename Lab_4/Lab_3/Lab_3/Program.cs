using Lab_3.Part1;
using System.Collections.Generic;

namespace Lab_3
{
    class Program
    {
        public static void Main()
        {
            string rawData = File.ReadAllText(Environment.CurrentDirectory + "/input.txt");
            string[] data = rawData.Split(' ');
            MyStack<string> stack = new MyStack<string>();
        }
        
    }
}