using System;
using System.Collections;
using System.Diagnostics;

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

        public int GetMemory()
        {
            return MemorryElems.Sum();
        }

        public void Remove()
        {
            MemorryElems.RemoveAt(0);
        }
    }

    public class Queue
    {
        private List<object> Elems = new List<object>();
        private MemoryKeeper Keeper = new MemoryKeeper();

        public bool IsEmpty()
        {
            return (Elems.Count == 0);
        }

        public void Enqueue(string elem)
        {
            Elems.Add(elem);
            Keeper.Add(elem);
        }

        public void Enqueue(int elem)
        {
            Elems.Add(elem);
            Keeper.Add(elem);
        }

        public object Dequeue()
        {
            if (!IsEmpty())
            {
                object result = Elems[0];
                Elems.RemoveAt(0);

                Keeper.Remove();
                return result;
            }
            else return new object();
        }

        public object Peek()
        {
            if (!IsEmpty()) return Elems[0];
            else return new object();
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

    public static class ListExtensionMethods
    {
        private static MemoryKeeper Keeper = new MemoryKeeper();

        public static bool IsEmpty(this List<object> list)
        {
            return (list.Count == 0);
        }

        public static void Enqueue(this List<object> list, string elem)
        {
            list.Add(elem);
            Keeper.Add(elem);
        }

        public static void Enqueue(this List<object> list, int elem)
        {
            list.Add(elem);
            Keeper.Add(elem);
        }

        public static object Dequeue(this List<object> list)
        {
            if (!list.IsEmpty())
            {
                object result = list[0];
                list.RemoveAt(0);

                Keeper.Remove();
                return result;
            }
            else return new object();
        }

        public static object Peek(this List<object> list)
        {
            if (!list.IsEmpty()) return list[0];
            else return new object();
        }

        public static int GetTotalMemory(this List<object> list)
        {
            return Keeper.GetMemory();
        }

        public static void Print(this List<object> list)
        {
            if (!list.IsEmpty()) Console.WriteLine(list[0]);
        }
    }

    class Program
    {
        //static void Main()
        //{
        //    //QueueExperinment.StartExperiment();
        //    //QueueTask.SolveTask();
        //    //QueueExperinment.StartExpMyQueue(File.ReadAllText(Environment.CurrentDirectory + "/commands.txt"));
        //    //QueueExperinment.StartExpClassicQueue(File.ReadAllText(Environment.CurrentDirectory + "/commands.txt"));
        //}
    }

    public static class QueueTask
    {
        public static void SolveTask()
        {
            Console.Clear();
            Queue queue = new Queue();
            Random rnd = new Random();

            int[] numbers = FileReader.ReadNumbers();
            int c = rnd.Next(1, 30000);

            foreach (int number in numbers)
                queue.Enqueue(number);

            Queue less = new Queue();
            Queue more = new Queue();

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

        private static void PrintQueue(Queue queue)
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

        public static void StartExperiment()
        {
            string[][] data = FileReader.ReadCommands();

            FillCommandNumberList(data);
            StartListQueueExperiment(data);
            StartQueueExperimnt(data);

            FileWriter.WriteData(CommandNumberList, QueueListTimes, QueueTimes);
        }

        private static void FillCommandNumberList(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
                CommandNumberList.Add(data[i].Length);
        }
        public static void StartExpClassicQueue(string data)
        {
            string[] d = data.Split(' ');
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    Queue<object> q = new Queue<object>();
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < d.Length - 1; j++)
                    {
                        switch (d[j])
                        {
                            case DequeueId:
                                if (q.Count > 0) q.Dequeue();
                                else Console.WriteLine("Queue is empty!");
                                break;

                            case PeekId:
                                if (q.Count > 0) q.Peek();
                                else Console.WriteLine("Queue is empty!");
                                break;

                            case IsEmptyId:
                                if (q.Count > 0)
                                {
                                    Console.WriteLine(true);
                                }
                                else
                                {
                                    Console.WriteLine(false);
                                }
                                break;

                            case PrintId:
                                Console.WriteLine(q);
                                break;

                            default:
                                string[] parts = d[j].Split(',');
                                string str = parts[1];

                                if (HelpMethods.IsParsePossible(str))
                                    q.Enqueue(int.Parse(str));
                                else
                                    q.Enqueue(str);
                                break;
                        }
                    }
                    timer.Stop();
                    timeList.Add(timer.ElapsedTicks);
                }
                double time = HelpMethods.FindMiddleTime(timeList);
                //FileWriter.WriteData(k, time, Process.GetCurrentProcess().WorkingSet64, Environment.CurrentDirectory + "/classicqueue_2.csv");
        }
        public static void StartExpMyQueue(string data)
        {
                string[] d = data.Split(' ');
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    List<object> queue = new List<object>();
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < d.Length - 1; j++)
                    {
                        switch (d[j])
                        {
                            case DequeueId:
                                queue.Dequeue();
                                break;

                            case PeekId:
                                queue.Peek();
                                break;

                            case IsEmptyId:
                                queue.IsEmpty();
                                break;

                            case PrintId:
                                queue.Print();
                                break;

                            default:
                                string[] parts = d[j].Split(',');
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
                //FileWriter.WriteData(k, time, Process.GetCurrentProcess().WorkingSet64, Environment.CurrentDirectory + "/queue_2.csv");
        }
        private static void StartListQueueExperiment(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    List<object> queue = new List<object>();
                    string[] line = data[i];

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < data[i].Length; j++)
                    {
                        switch (line[j])
                        {
                            case DequeueId:
                                queue.Dequeue();
                                break;

                            case PeekId:
                                queue.Peek();
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
            }
        }

        private static void StartQueueExperimnt(string[][] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                List<long> timeList = new List<long>();
                for (int repeat = 0; repeat < 5; repeat++)
                {
                    Queue queue = new Queue();
                    string[] line = data[i];

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    for (int j = 0; j < data[i].Length; j++)
                    {
                        switch (line[j])
                        {
                            case DequeueId:
                                queue.Dequeue();
                                break;

                            case PeekId:
                                queue.Peek();
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
        public static string[][] ReadCommands()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "commands.txt");
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
        public static void WriteData(int i, double time, long memory, string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, $"{i};{time};{memory}\n");
            }
            else
            {
                File.AppendAllText(path, $"{i};{time};{memory}\n");
            }
        }
        public static void WriteData(List<int> commands, List<double> queueListTimes, List<double> queueTimes)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "output.csv");
            string[] lines = new string[queueTimes.Count];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{commands[i]};{queueListTimes[i]};{queueTimes[i]}";
            }

            File.WriteAllLines(path, lines);
        }
    }
}