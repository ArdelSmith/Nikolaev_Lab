using Lab_3.Part1;
using System.Collections.Generic;
using System.Diagnostics;
using Lab_3.Part4;

namespace Lab_3
{
    class Program
    {
        public static void Main()
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Print();
            Console.WriteLine(stack.Top());
            stack.Pop();
            stack.Print();
            //Lab_3.Part3.StackTask.ReverseNumber(156);
            //for (int i = 0; i < 1000; i++)
            //{
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/inputPart2.csv", DataWorker.Generate(5, 1000));
            //}
            //string[] rawData = File.ReadAllLines(Environment.CurrentDirectory + "/inputPart2.csv");
            //int i = 0;
            //foreach (string s in rawData)
            //{
            //    string[] data = rawData[i].Split(' '); 
            //    Stopwatch timer = new Stopwatch();
            //    Stopwatch timer1 = new Stopwatch();
            //    timer.Start();
            //    Queue.QueueExperinment.StartExpMyQueue(DataWorker.Generate(5, 1000));
            //    timer.Stop();
            //    long m1 = Process.GetCurrentProcess().WorkingSet64;
            //    timer1.Start();
            //    Queue.QueueExperinment.StartExpClassicQueue(DataWorker.Generate(5, 1000));
            //    timer1.Stop();
            //    long m2 = Process.GetCurrentProcess().WorkingSet64;
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/punkt2_my.csv", timer.ElapsedMilliseconds, m1);
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/punkt2_.csv", timer1.ElapsedMilliseconds, m2);
            //    i += 1;
            //}
            //string rawData = File.ReadAllText(Environment.CurrentDirectory + "/input.csv");
            //string[] data = rawData.Split(' ');
            //for (int i = 1; i < data.Length / 100; i += 100)
            //{
            //    Stopwatch timer = new Stopwatch();
            //    string kek = "";
            //    for (int j = 0; j < i - 1; j++)
            //    {
            //        kek += data[j];
            //        kek += " ";
            //    }
            //    kek += data[i];
            //    timer.Start();
            //    PostfixHandler.InfixToPostfix(kek);
            //    timer.Stop();
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/infixtimeStandart.csv", i, timer.ElapsedMilliseconds);
            //}
            //Queue.QueueExperinment.StartExpMyQueue(File.ReadAllText(Environment.CurrentDirectory + "/commands.txt"));
            //Queue.QueueExperinment.StartExpClassicQueue(File.ReadAllText(Environment.CurrentDirectory + "/commands.txt"));
            //string rawData = File.ReadAllText(Environment.CurrentDirectory + "/commands.txt");
            //string[] data = rawData.Split(' ');
            //for (int i = 1; i < 150000; i += 1000)
            //{
            //    MyStack<string> stack = new MyStack<string>();
            //    Stopwatch timer = new Stopwatch();
            //    string[] t = new string[i];
            //    for (int j = 0; j < i; j++)
            //    {
            //        t[j] = data[j];
            //    }
            //    timer.Start();
            //    MyStack<string>.ProcessCommands(t, stack);
            //    timer.Stop();
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/stacktime.csv", i, timer.ElapsedMilliseconds, Process.GetCurrentProcess().WorkingSet64);
            //}
            //for (int i = 1; i < 150000; i += 1000)
            //{
            //    Stack<string> stack = new Stack<string>();
            //    Stopwatch timer = new Stopwatch();
            //    string[] t = new string[i];
            //    for (int j = 0; j < i; j++)
            //    {
            //        t[j] = data[j];
            //    }
            //    timer.Start();
            //    MyStack<string>.ProcessCommandsClassicStack(t, stack);
            //    timer.Stop();
            //    FileWriter.WriteData(Environment.CurrentDirectory + "/classicstacktime.csv", i, timer.ElapsedMilliseconds, Process.GetCurrentProcess().WorkingSet64);
            //}
            //Task4Executor.ExecuteTask4(Environment.CurrentDirectory + "/postfix.txt");
            //string infix = "2 + 2 + 4";
            //Task4Executor.ExecuteTask4(Environment.CurrentDirectory + "/postfix.txt");
            //Lab_3.Part3.StackTask.FindDelims(48);
        }
    }
}