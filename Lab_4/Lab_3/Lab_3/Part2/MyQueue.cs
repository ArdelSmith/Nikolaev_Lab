using System;
using System.Collections;
using System.Diagnostics;
using Lab_3.Part4;

namespace Queue
{
    public class MemoryKeeper
    {
        private List<int> MemorryElems = new List<int>();

        public void Add(int elem)
        {
            MemorryElems.Add(4);
        }

        public void Add(string elem)
        {
            MemorryElems.Add((elem.Length + 1) * 2);
        }

        public void Add(object elem)
        {
            try
            {
                int num = (int)elem;
                Add(num);
            }
            catch
            {
                string str = (string)elem;
                Add(str);
            }
        }

        public int GetMemory()
        {
            return MemorryElems.Sum();
        }

        public void Remove()
        {
            MemorryElems.RemoveAt(0);
        }
    }

    public class Queue<T>
    {
        private List<T> Elems = new List<T>();
        private MemoryKeeper Keeper = new MemoryKeeper();

        public bool IsEmpty()
        {
            return (Elems.Count == 0);
        }

        public void Enqueue(T elem)
        {
            Elems.Add(elem);
            Keeper.Add(elem);
        }

        public T Dequeue()
        {
            T result = Elems[0];
            Elems.RemoveAt(0);

            Keeper.Remove();
            return result;
        }

        public T Peek()
        {
            return Elems[0];
        }

        public int GetTotalMemory()
        {
            return Keeper.GetMemory();
        }

        public void Print()
        {
            if (!IsEmpty()) Console.WriteLine(Elems[0]);
        }
    }

    public class MyQueue<T>
    {
        private MyList<T> Elems = new MyList<T>();
        private MemoryKeeper Keeper = new MemoryKeeper();

        public bool IsEmpty()
        {
            return (Elems.Count == 0);
        }

        public void Enqueue(T elem)
        {
            Elems.Add(elem);
            Keeper.Add(elem);
        }

        public T Dequeue()
        {
            T result = Elems.GetFirstElem();
            Elems.Remove(result);

            Keeper.Remove();
            return result;
        }

        public T Peek()
        {
            return Elems.GetFirstElem();
        }

        public int GetTotalMemory()
        {
            return Keeper.GetMemory();
        }

        public void Print()
        {
            if (!IsEmpty()) Console.WriteLine(Elems.GetFirstElem());
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    QueueExperinment.StartExperiment();
        //    QueueTask.SolveTask();
        //}
    }

    public static class QueueTask
    {
        public static void SolveTask()
        {
            Console.Clear();
            MyQueue<int> queue = new MyQueue<int>();
            Random rnd = new Random();

            int[] numbers = FileReader.ReadNumbers();
            int c = rnd.Next(1, 30000);

            foreach (int number in numbers)
                queue.Enqueue(number);

            MyQueue<int> less = new MyQueue<int>();
            MyQueue<int> more = new MyQueue<int>();

            while (!queue.IsEmpty())
            {
                int num = (int)queue.Dequeue();
                if (num <= c) less.Enqueue(num);
                else more.Enqueue(num);
            }

            PrintQueue(less);
            Console.WriteLine($"\nC = {c}\n");
            PrintQueue(more);
        }

        private static void PrintQueue(MyQueue<int> queue)
        {
            while (!queue.IsEmpty())
            {
                int num = (int)queue.Dequeue();
                Console.WriteLine(num);
            }
        }
    }

    public static class QueueExperinment
    {
        /// <summary>
        /// Удаление первого элемента из очереди
        /// </summary>
        private const string DequeueId = "2";

        /// <summary>
        /// Возврат первого элемента из очереди без удаления (просмотр начала очереди)
        /// </summary>
        private const string PeekId = "3";

        /// <summary>
        /// Проверка на пустоту
        /// </summary>
        private const string IsEmptyId = "4";

        /// <summary>
        /// Вывод в консоль первого элемента очереди (печать)
        /// </summary>
        private const string PrintId = "5";

        public static List<double> QueueListTimes = new List<double>();
        public static List<double> QueueTimes = new List<double>();
        public static List<int> CommandNumberList = new List<int>();
        public static List<long> QueueListMemory = new List<long>();
        public static List<long> QueueMemory = new List<long>();
        public static void StartExperiment(string[][] data, bool flag)
        {
            StartMyQueueExperiment(data);
            StartQueueExperimnt(data);
            FileWriter.WriteData(CommandNumberList, QueueListTimes, QueueTimes, QueueListMemory, QueueMemory);
            if (flag)
            {
                string path = Path.Combine(Environment.CurrentDirectory, "output_different.csv");
                string[] lines = new string[QueueTimes.Count];
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    lines[i] = $"{QueueListTimes[i]};{QueueTimes[i]};{QueueListMemory[i]}; {QueueMemory[i]}";
                }

                File.WriteAllLines(path, lines);
            }
        }
        public static void StartExperiment()
        {
            string[][] data = FileReader.ReadCommands(File.ReadAllText(Environment.CurrentDirectory + "/commands.txt"));

            FillCommandNumberList(data);
            StartMyQueueExperiment(data);
            StartQueueExperimnt(data);
            FileWriter.WriteData(CommandNumberList, QueueListTimes, QueueTimes, QueueListMemory, QueueMemory);
        }

        private static void FillCommandNumberList(string[][] data)
        {
            for (int i = 1; i < data.Length - 1; i++)
                CommandNumberList.Add(data[i].Length);
        }

        private static void StartMyQueueExperiment(string[][] data)
        {
            for (int i = 0; i < data.Length - 1; i += 1)
            {
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    MyQueue<object> queue = new MyQueue<object>();
                    string[] line = data[i];

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < data[i].Length - 1; j++)
                    {
                        switch (line[j])
                        {
                            case "1":
                                {
                                    break;
                                }
                            case DequeueId:
                                if (!queue.IsEmpty()) queue.Dequeue();
                                break;

                            case PeekId:
                                if (!queue.IsEmpty()) queue.Peek();
                                break;

                            case IsEmptyId:
                                queue.IsEmpty();
                                break;

                            case PrintId:
                                queue.Print();
                                break;

                            default:
                                string[] parts = line[j].Split(',');
                                string str = parts[1];

                                if (HelpMethods.IsParsePossible(str))
                                    queue.Enqueue(int.Parse(str));
                                else
                                    queue.Enqueue(str);
                                break;
                        }
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                QueueListTimes.Add(time);
                QueueListMemory.Add(Process.GetCurrentProcess().WorkingSet64);
            }
        }

        private static void StartQueueExperimnt(string[][] data)
        {
            for (int i = 0; i < data.Length - 1; i += 1)
            {
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    Queue<object> queue = new Queue<object>();
                    string[] line = data[i];

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < data[i].Length - 1; j++)
                    {
                        switch (line[j])
                        {
                            case DequeueId:
                                if (!queue.IsEmpty()) queue.Dequeue();
                                break;

                            case PeekId:
                                if (!queue.IsEmpty()) queue.Peek();
                                break;

                            case IsEmptyId:
                                queue.IsEmpty();
                                break;

                            case PrintId:
                                queue.Print();
                                break;

                            default:
                                string[] parts = line[j].Split(',');
                                string str = parts[1];

                                if (HelpMethods.IsParsePossible(str))
                                    queue.Enqueue(int.Parse(str));
                                else
                                    queue.Enqueue(str);
                                break;
                        }
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                QueueTimes.Add(time);
                QueueMemory.Add(Process.GetCurrentProcess().WorkingSet64);
            }
        }
    }

    public static class HelpMethods
    {
        public static double FindMiddleTime(List<long> allElems)
        {
            allElems.Sort();
            double sumTime = 0;

            List<long> selectedElems = new List<long>();
            List<long> selectedDists = new List<long>();

            for (int i = 0; i < allElems.Count - 2; i++)
            {
                long middleDist = selectedDists.Count == 0
                    ? allElems[i + 1] - allElems[i]
                    : selectedDists.Sum() / selectedDists.Count;

                long nextDist = allElems[i + 2] - allElems[i + 1];

                if (middleDist == 0) middleDist = +1;
                if (nextDist == 0) nextDist = +1;

                if (middleDist > nextDist * 20)
                {
                    for (int j = i + 1; j < allElems.Count; j++)
                        selectedElems.Add(allElems[j]);

                    foreach (long elem in selectedElems) sumTime += elem;
                    return (sumTime / selectedElems.Count) / 10.0;
                }
                else if (nextDist > middleDist * 20)
                {
                    for (int j = 0; j <= i + 1; j++)
                        selectedElems.Add(allElems[j]);

                    foreach (long elem in selectedElems) sumTime += elem;
                    return (sumTime / selectedElems.Count) / 10.0;
                }
            }

            foreach (long elem in allElems) sumTime += elem;
            return (sumTime / allElems.Count) / 10.0;
        }

        public static bool IsParsePossible(string str)
        {
            try
            {
                int num = int.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public static class FileReader
    {
        public static string[][] ReadCommands(string commands)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "commands.txt");
            string line = File.ReadAllText(path);
            int thousands = 1000 * 2;
            string[][] data = new string[150][];
            string temp = "";
            int j = 0;
            for (int i = 0; i < 300000; i++)
            {
                temp += line[i];
                if (i == thousands)
                {   
                    string[] coms = temp.Split(" ");
                    if (coms[coms.Length - 1].ToString() == "")
                    {
                        coms[coms.Length - 1] = "5";
                    }
                    data[j] = coms;
                    j++;
                    thousands += 2000;
                }
            }
            return data;
        }
        public static string[][] ReadCommands()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
            string[] lines = File.ReadAllLines(path);


            string[][] data = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                data[i] = lines[i].Split(' ');
            }
            return data;
        }

        public static int[] ReadNumbers()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "data.txt");
            string line = File.ReadAllText(path);

            string[] parts = line.Split(' ');
            int[] nums = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                nums[i] = int.Parse(parts[i]);
            }
            return nums;
        }
    }

    public static class FileWriter
    {
        public static void WriteData(List<int> commands, List<double> myQueueTimes, List<double> queueTimes, List<long> MyQueueMemory, List<long> QueueMemory)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "output.csv");
            string[] lines = new string[queueTimes.Count];

            for (int i = 0; i < lines.Length - 1; i++)
            {
                lines[i] = $"{myQueueTimes[i]};{queueTimes[i]};{MyQueueMemory[i]}; {QueueMemory[i]}";
            }

            File.WriteAllLines(path, lines);
        }
    }
}