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
            Menu menu = new Menu();
            menu.StartMenu();
            //MyStack<int> stack = new MyStack<int>();
            //stack.Push(1);
            //stack.Print();
            //Console.WriteLine(stack.Top());
            //stack.Pop();
            //stack.Print();
            //Lab_3.Part3.StackTask.ReverseNumber(156);
            //Queue.QueueExperinment.StartExperiment();
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
            //Queue.QueueExperinment.StartExperiment();
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
            //string[][] different = new string[100][];
            //string[][] same = new string[100][];
            //for (int i = 0; i < different.Length; i++)
            //{
            //    string temp = DataWorker.Generate(5, i * 1000);
            //    string[] t = temp.Split(" ");
            //    different[i] = t;
            //}
            //for (int i = 0; i < same.Length; i++)
            //{
            //    string temp = DataWorker.Generate(5, 1000);
            //    string[] t = temp.Split(" ");
            //    same[i] = t;
            //}
            //Queue.QueueExperinment.StartExperiment(different, true);
            //Queue.QueueExperinment.StartExperiment(same, false);
        }
    }
}