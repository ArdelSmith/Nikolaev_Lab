using System;
using System.IO;

namespace Lab_4
{
    public class ExternalSorts
    {
        public static void StartExternalSorts()
        {
            SortTables.StartTask();
        }
    }

    public static class SortTables
    {
        public static void StartTask()
        {
            string fileName = string.Empty;
            List<int> atributes = null;
            int delay = 0;

            List<string> files = GetFiles(Environment.CurrentDirectory);
            while (fileName == string.Empty)
            {
                PrintElems("Выберите файл", files);
                string result = Console.ReadLine();
                try
                {
                    int num = int.Parse(result);
                    if (num == files.Count + 1) return;
                    else if (num > files.Count + 1) continue;
                    else fileName = files[num - 1];
                }
                catch { continue; }
            }

            List<string> columns = GetColumns(fileName);
            while (atributes == null)
            {
                PrintElems("Выберите атрибуты, по которым сортировать (перечислете через пробел)", columns);
                string result = Console.ReadLine();
                try
                {
                    string[] parts = result.Split(' ');
                    List<int> nums = new List<int>();
                    foreach (string str in parts) nums.Add(int.Parse(str));

                    if (nums.Contains(columns.Count + 1) && nums.Count == 1) return;
                    else if (nums.Contains(columns.Count + 1) && nums.Count != 1) continue;
                    if (nums.Max() > columns.Count + 1) continue;

                    atributes = nums;
                }
                catch { continue; }
            }

            for (int i = 0; i < atributes.Count; i++) atributes[i] = atributes[i] - 1;
            while (delay == 0)
            {
                Console.Clear();
                Console.WriteLine("Введите задержку для логгера в млс (оставте пустым, чтобы выйти)\n");
                string result = Console.ReadLine();
                try
                {
                    if (result == string.Empty) return;
                    int num = int.Parse(result);
                    if (num > 0) delay = num;
                }
                catch { continue; }
            }

            while (true)
            {
                PrintElems("Выберите сортировку", new List<string>() { "Прямое слияние", "Естественное слияние", "Многопутевое слияние" });
                string result = Console.ReadLine();
                try
                {
                    int num = int.Parse(result);
                    if (num == 1)
                    {
                        StartFirstSort(fileName, atributes, delay);
                        break;
                    }
                    else if (num == 2)
                    {
                        StartSecondSort(fileName, atributes, delay);
                        break;
                    }
                    else if (num == 3)
                    {
                        StartThirdSort(fileName, atributes, delay);
                        break;
                    }
                    else if (num == 4) return;
                    else continue;
                }
                catch { continue; }
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void PrintElems(string message, List<string> elems)
        {
            Console.Clear();

            Console.WriteLine($"{message}\n");
            for (int i = 0; i < elems.Count; i++)
            {
                Console.WriteLine($"{i + 1} {elems[i]}");
            }
            Console.WriteLine($"\n{elems.Count + 1} Выход\n");
        }

        private static List<string> GetFiles(string directoryPath)
        {
            string[] paths = Directory.GetFiles(directoryPath);
            string[][] parts = new string[paths.Length][];

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = paths[i].Split('\\');
            }

            List<string> files = new List<string>();
            foreach (string[] part in parts)
            {
                string file = part[part.Length - 1];
                if (file.Split('.')[1] == "csv")
                {
                    files.Add(file);
                }
            }
            return files;
        }

        private static List<string> GetColumns(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            StreamReader sr = new StreamReader(path);

            string line = sr.ReadLine();
            string[] parts = line.Split(';');

            List<string> columns = new List<string>();
            foreach (string str in parts)
                columns.Add(str);

            sr.Close();
            return columns;
        }

        private static void StartFirstSort(string fileName, List<int> atribs, int delay)
        {
            foreach (int atrib in atribs)
            {
                DirectMergeSort sort = new DirectMergeSort(fileName, atrib, delay);
                sort.StartSort();
                sort.PrintLogger();
            }
        }

        private static void StartSecondSort(string fileName, List<int> atribs, int delay)
        {
            foreach (int atrib in atribs)
            {
                NaturalMergeSort sort = new NaturalMergeSort(fileName, atrib, delay);
                sort.StartSort();
                sort.PrintLogger();
            }
        }

        private static void StartThirdSort(string fileName, List<int> atribs, int delay)
        {
            foreach (int atrib in atribs)
            {
                MultiPathMergeSort sort = new MultiPathMergeSort(fileName, atrib, delay);
                sort.StartSort();
                sort.PrintLogger();

            }
        }
    }

    public class Logger
    {
        private string DirectoryPath { get; set; }
        private string LogPath { get; set; }
        private int Delay { get; set; }
        private int Column { get; set; }

        private string FullFileName = "log.txt";

        public Logger(string directoryPath, int delay, int column)
        {
            DirectoryPath = directoryPath;
            Delay = delay;
            Column = column;

            LogPath = Path.Combine(DirectoryPath, FullFileName);
            if (File.Exists(LogPath)) File.Delete(LogPath);
        }

        public void AddComparison(string str1, string str2)
        {
            string message = $"Сравниваем значения '{str1}' и '{str2}'";
            string level = "[COMPARSION]";

            Log(level, message);
        }

        public void AddWriting(string fullFileName, string str)
        {
            string message = $"Записываем строку со значением '{str}' в {Column + 1} столбике в файл {fullFileName}";
            string level = "[WRITING]";

            Log(level, message);
        }

        public void AddReading(string fullFileName, string str)
        {
            string message = $"Считываем строку со значением '{str}' в {Column + 1} столбике из файла {fullFileName}";
            string level = "[READING]";

            Log(level, message);
        }

        public void AddNewSeries(string fullFileName, string str)
        {
            string message = $"С элемента {str} начинается новая серия файла {fullFileName}";
            string level = "[START SERIES]";

            Log(level, message);
        }

        public void AddEndSeries(string fullFileName, string str)
        {
            string message = $"На элементе {str} заканчивается текущая серия файла {fullFileName}";
            string level = "[END SERIES]";

            Log(level, message);
        }

        public void AddNewChunk(string fullFileName, string str)
        {
            string message = $"С элемента {str} начинается новый чанк файла {fullFileName}";
            string level = "[START CHUNK]";

            Log(level, message);
        }

        public void AddEndChunk(string fullFileName, string str)
        {
            string message = $"На элементе {str} заканчивается текущий чанк файла {fullFileName}";
            string level = "[END CHUNK]";

            Log(level, message);
        }

        private void Log(string level, string message)
        {
            File.AppendAllLines(LogPath, new string[] { $"{level} {message}" });
        }

        public void PrintMessages()
        {
            StreamReader sr = new StreamReader(LogPath);
            string message = sr.ReadLine();

            while (message != null)
            {
                Console.WriteLine(message);
                Thread.Sleep(Delay);

                message = sr.ReadLine();
            }

            sr.Close();
            File.Delete(LogPath);
        }
    }

    public class DirectMergeSort
    {
        private string DirectoryPath { get; set; }
        private string FullFileName { get; set; }

        private string PathA { get; set; }
        private string PathB { get; set; }
        private string PathC { get; set; }

        private int Column { get; set; }
        private string Header { get; set; }
        private Logger Log { get; set; }

        private string FullFileNameB = "B.csv";
        private string FullFileNameC = "C.csv";

        private bool IsLastRewrite = false;
        private int Chunk = 1;

        public DirectMergeSort(string directoryPath, string fullFileName, int column, int delay)
        {
            DirectoryPath = directoryPath;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        public DirectMergeSort(string fullFileName, int column, int delay)
        {
            DirectoryPath = Environment.CurrentDirectory;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        private void InitPaths()
        {
            PathA = Path.Combine(DirectoryPath, FullFileName);
            PathB = Path.Combine(DirectoryPath, FullFileNameB);
            PathC = Path.Combine(DirectoryPath, FullFileNameC);
        }

        private void InitHeader()
        {
            StreamReader sr = new StreamReader(PathA);
            Header = sr.ReadLine();
            sr.Close();
        }

        private void InitLogger(int delay)
        {
            Log = new Logger(DirectoryPath, delay, Column);
        }

        public void StartSort()
        {
            while (!IsLastRewrite)
            {
                RewriteToTwoFiles();
                RewriteToMainFile();
                Chunk *= 2;
            }

            File.Delete(PathB);
            File.Delete(PathC);
        }

        public void PrintLogger()
        {
            Log.PrintMessages();
        }

        private void RewriteToTwoFiles()
        {
            StreamReader srA = new StreamReader(PathA);

            StreamWriter swB = new StreamWriter(PathB);
            StreamWriter swC = new StreamWriter(PathC);

            bool flagB = true;
            bool isNewChunk = true;
            int step = 0;

            srA.ReadLine();
            while (true)
            {
                string str = srA.ReadLine();
                if (str == null) break;

                Log.AddReading(FullFileName, str.GetElem(Column));
                if (isNewChunk)
                {
                    Log.AddNewChunk(FullFileName, str.GetElem(Column));
                    isNewChunk = false;
                }
                step++;

                if (flagB)
                {
                    swB.WriteLine(str);
                    Log.AddWriting(FullFileNameB, str.GetElem(Column));
                }
                else
                {
                    swC.WriteLine(str);
                    Log.AddWriting(FullFileNameC, str.GetElem(Column));
                }
                if (step == Chunk)
                {
                    Log.AddEndChunk(FullFileName, str.GetElem(Column));
                    HelpUtils.ChangeFlag(ref flagB);
                    isNewChunk = true;
                    step = 0;
                }
            }
            srA.Close(); swB.Close(); swC.Close();
        }

        private void RewriteToMainFile()
        {
            StreamWriter swA = new StreamWriter(PathA);

            StreamReader srB = new StreamReader(PathB);
            StreamReader srC = new StreamReader(PathC);

            IsLastRewrite = true;
            bool isNewChunkB = true;
            bool isNewChunkC = true;

            swA.WriteLine(Header);
            while (true)
            {
                string strB = srB.ReadLine();
                string strC = srC.ReadLine();

                if (strB == null && strC == null) break;
                if (strB != null)
                {
                    Log.AddReading(FullFileNameB, strB.GetElem(Column));
                    if (isNewChunkB)
                    {
                        Log.AddNewChunk(FullFileNameB, strB.GetElem(Column));
                        isNewChunkB = false;
                    }
                }
                if (strC != null)
                {
                    Log.AddReading(FullFileNameC, strC.GetElem(Column));
                    if (isNewChunkC)
                    {
                        Log.AddNewChunk(FullFileNameC, strC.GetElem(Column));
                        isNewChunkC = false;
                    }
                }

                int indexB = 1;
                int indexC = 1;

                for (int i = 0; i < Chunk * 2; i++)
                {
                    if (strB == null && strC != null)
                    {
                        WriteAndSetNextPointer(ref swA, ref srC, ref strC, ref indexC, ref isNewChunkC, FullFileNameC);
                    }
                    else if (strB != null && strC == null)
                    {
                        WriteAndSetNextPointer(ref swA, ref srB, ref strB, ref indexB, ref isNewChunkB, FullFileNameB);
                    }
                    else if (strB != null && strC != null)
                    {
                        if (Compare(strB, strC))
                        {
                            WriteAndSetNextPointer(ref swA, ref srB, ref strB, ref indexB, ref isNewChunkB, FullFileNameB);
                        }
                        else
                        {
                            WriteAndSetNextPointer(ref swA, ref srC, ref strC, ref indexC, ref isNewChunkC, FullFileNameC);
                        }
                    }
                }
            }
            swA.Close(); srB.Close(); srC.Close();
        }

        private void WriteAndSetNextPointer(ref StreamWriter sw, ref StreamReader sr, ref string str, ref int index, ref bool isNewChunk, string file)
        {
            sw.WriteLine(str);
            Log.AddWriting(FullFileName, str.GetElem(Column));

            if (index == Chunk)
            {
                Log.AddEndChunk(file, str.GetElem(Column));
                IsLastRewrite = false;
                isNewChunk = true;
                str = null;
            }
            else
            {
                str = sr.ReadLine();
                index++;

                if (str != null) Log.AddReading(file, str.GetElem(Column));
            }
        }

        private bool Compare(string str1, string str2)
        {
            string[] line1 = str1.Split(';');
            string[] line2 = str2.Split(';');

            Log.AddComparison(line1[Column], line2[Column]);

            if (HelpUtils.IsParseAvalible(line1[Column]) && HelpUtils.IsParseAvalible(line2[Column]))
            {
                return (int.Parse(line1[Column]) <= int.Parse(line2[Column]));
            }
            else
            {
                return HelpUtils.CompareTwoWords(line1[Column], line2[Column]);
            }
        }
    }

    public class NaturalMergeSort
    {
        private string DirectoryPath { get; set; }
        private string FullFileName { get; set; }

        private string PathA { get; set; }
        private string PathB { get; set; }
        private string PathC { get; set; }

        private int Column { get; set; }
        private string Header { get; set; }
        private Logger Log { get; set; }

        private string FullFileNameB = "B.csv";
        private string FullFileNameC = "C.csv";

        private bool IsLastRewrite = false;

        public NaturalMergeSort(string directoryPath, string fullFileName, int column, int delay)
        {
            DirectoryPath = directoryPath;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        public NaturalMergeSort(string fullFileName, int column, int delay)
        {
            DirectoryPath = Environment.CurrentDirectory;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        private void InitPaths()
        {
            PathA = Path.Combine(DirectoryPath, FullFileName);
            PathB = Path.Combine(DirectoryPath, FullFileNameB);
            PathC = Path.Combine(DirectoryPath, FullFileNameC);
        }

        private void InitHeader()
        {
            StreamReader sr = new StreamReader(PathA);
            Header = sr.ReadLine();
            sr.Close();
        }

        private void InitLogger(int delay)
        {
            Log = new Logger(DirectoryPath, delay, Column);
        }

        public void StartSort()
        {
            while (!IsLastRewrite)
            {
                RewriteToTwoFiles();
                RewriteToMainFile();
            }

            File.Delete(PathB);
            File.Delete(PathC);
        }

        public void PrintLogger()
        {
            Log.PrintMessages();
        }

        private void RewriteToTwoFiles()
        {
            StreamReader srA = new StreamReader(PathA);

            StreamWriter swB = new StreamWriter(PathB);
            StreamWriter swC = new StreamWriter(PathC);

            bool flagB = true;

            srA.ReadLine();
            string cur = srA.ReadLine();
            string next = srA.ReadLine();

            if (cur != null)
            {
                swB.WriteLine(cur);

                Log.AddReading(FullFileName, cur.GetElem(Column));
                Log.AddNewSeries(FullFileName, cur.GetElem(Column));
                Log.AddWriting(FullFileNameB, cur.GetElem(Column));
            }

            while (true)
            {
                if (next == null) break;
                Log.AddReading(FullFileName, next.GetElem(Column));

                if (!Compare(cur, next))
                {
                    Log.AddEndSeries(FullFileName, cur.GetElem(Column));
                    Log.AddNewSeries(FullFileName, next.GetElem(Column));
                    HelpUtils.ChangeFlag(ref flagB);
                }

                if (flagB)
                {
                    swB.WriteLine(next);
                    Log.AddWriting(FullFileNameB, next.GetElem(Column));
                }
                else
                {
                    swC.WriteLine(next);
                    Log.AddWriting(FullFileNameC, next.GetElem(Column));
                }

                cur = next;
                next = srA.ReadLine();
            }

            srA.Close(); swB.Close(); swC.Close();
        }


        private void RewriteToMainFile()
        {
            StreamWriter swA = new StreamWriter(PathA);

            StreamReader srB = new StreamReader(PathB);
            StreamReader srC = new StreamReader(PathC);

            IsLastRewrite = true;
            bool isNewSeriesB = false;
            bool isNewSeriesC = false;

            string curB = srB.ReadLine();
            string curC = srC.ReadLine();

            if (curB != null)
            {
                Log.AddReading(FullFileNameB, curB.GetElem(Column));
                Log.AddNewSeries(FullFileNameB, curB.GetElem(Column));
            }
            if (curC != null)
            {
                Log.AddReading(FullFileNameC, curC.GetElem(Column));
                Log.AddNewSeries(FullFileNameC, curC.GetElem(Column));
            }

            string nextB = srB.ReadLine();
            string nextC = srC.ReadLine();

            swA.WriteLine(Header);
            while (true)
            {
                if (curB == null && curC == null && nextB == null && nextC == null) break;
                InitNextSeriesPointers(ref srB, ref srC, ref curB, ref curC, ref nextB, ref nextC, ref isNewSeriesB, ref isNewSeriesC);

                if (curB == null)
                {
                    WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                }
                else if (curC == null)
                {
                    WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                }
                else
                {
                    if (Compare(curB, curC))
                    {
                        WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                    }
                    else
                    {
                        WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                    }
                }
            }
            swA.Close(); srB.Close(); srC.Close();
        }

        private void InitNextSeriesPointers(ref StreamReader srB, ref StreamReader srC,
            ref string curB, ref string curC, ref string nextB, ref string nextC,
            ref bool isNewSeriasB, ref bool isNewSeriasC)
        {
            if (curB == null && curC == null)
            {
                if (nextB != null)
                {
                    curB = nextB;
                    nextB = srB.ReadLine();

                    Log.AddReading(FullFileNameB, curB.GetElem(Column));
                    if (isNewSeriasB)
                    {
                        Log.AddNewSeries(FullFileNameB, curB.GetElem(Column));
                        isNewSeriasB = false;
                    }
                }
                if (nextC != null)
                {
                    curC = nextC;
                    nextC = srC.ReadLine();

                    Log.AddReading(FullFileNameC, curC.GetElem(Column));
                    if (isNewSeriasC)
                    {
                        Log.AddNewSeries(FullFileNameC, curC.GetElem(Column));
                        isNewSeriasC = false;
                    }
                }
            }
        }

        private void WriteAndSetNextPointers(ref StreamWriter sw, ref StreamReader sr, ref string cur, ref string next, ref bool isNewSerias, string file)
        {
            sw.WriteLine(cur);
            Log.AddWriting(FullFileName, cur.GetElem(Column));

            if (next != null && !Compare(cur, next, false))
            {
                Log.AddEndSeries(file, cur.GetElem(Column));
                cur = null;
                IsLastRewrite = false;
                isNewSerias = true;
            }
            else
            {
                if (next != null) Log.AddReading(file, next.GetElem(Column));

                cur = next;
                next = sr.ReadLine();
            }
        }

        private bool Compare(string str1, string str2, bool write = true)
        {
            string[] line1 = str1.Split(';');
            string[] line2 = str2.Split(';');

            if (write) Log.AddComparison(line1[Column], line2[Column]);

            if (HelpUtils.IsParseAvalible(line1[Column]) && HelpUtils.IsParseAvalible(line2[Column]))
            {
                return (int.Parse(line1[Column]) <= int.Parse(line2[Column]));
            }
            else
            {
                return HelpUtils.CompareTwoWords(line1[Column], line2[Column]);
            }
        }
    }

    public class MultiPathMergeSort
    {
        private string DirectoryPath { get; set; }
        private string FullFileName { get; set; }

        private string PathA { get; set; }
        private string PathB { get; set; }
        private string PathC { get; set; }
        private string PathD { get; set; }

        private string Header { get; set; }
        private int Column { get; set; }
        private Logger Log { get; set; }

        private string FullFileNameB = "B.csv";
        private string FullFileNameC = "C.csv";
        private string FullFileNameD = "D.csv";

        private bool IsLastRewrite = false;

        public MultiPathMergeSort(string directoryPath, string fullFileName, int column, int delay)
        {
            DirectoryPath = directoryPath;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        public MultiPathMergeSort(string fullFileName, int column, int delay)
        {
            DirectoryPath = Environment.CurrentDirectory;
            FullFileName = fullFileName;
            Column = column;

            InitPaths();
            InitHeader();
            InitLogger(delay);
        }

        private void InitPaths()
        {
            PathA = Path.Combine(DirectoryPath, FullFileName);

            PathB = Path.Combine(DirectoryPath, FullFileNameB);
            PathC = Path.Combine(DirectoryPath, FullFileNameC);
            PathD = Path.Combine(DirectoryPath, FullFileNameD);
        }

        private void InitHeader()
        {
            StreamReader sr = new StreamReader(PathA);
            Header = sr.ReadLine();
            sr.Close();
        }

        private void InitLogger(int delay)
        {
            Log = new Logger(DirectoryPath, delay, Column);
        }

        public void StartSort()
        {
            while (!IsLastRewrite)
            {
                RewriteToThreeFiles();
                RewriteToMainFile();
            }

            File.Delete(PathB);
            File.Delete(PathC);
            File.Delete(PathD);
        }

        public void PrintLogger()
        {
            Log.PrintMessages();
        }

        private void RewriteToThreeFiles()
        {
            StreamReader srA = new StreamReader(PathA);

            StreamWriter swB = new StreamWriter(PathB);
            StreamWriter swC = new StreamWriter(PathC);
            StreamWriter swD = new StreamWriter(PathD);

            int step = 0;
            int choice = 0;

            srA.ReadLine();
            string cur = srA.ReadLine();
            string next = srA.ReadLine();

            if (cur != null)
            {
                swB.WriteLine(cur);

                Log.AddReading(FullFileName, cur.GetElem(Column));
                Log.AddNewSeries(FullFileName, cur.GetElem(Column));
                Log.AddWriting(FullFileNameB, cur.GetElem(Column));
            }
            while (true)
            {
                if (next == null) break;
                Log.AddReading(FullFileName, next.GetElem(Column));

                if (!Compare(cur, next))
                {
                    choice = ++step % 3;
                    Log.AddEndSeries(FullFileName, cur.GetElem(Column));
                    Log.AddNewSeries(FullFileName, next.GetElem(Column));
                }

                if (choice == 0)
                {
                    swB.WriteLine(next);
                    Log.AddWriting(FullFileNameB, next.GetElem(Column));
                }
                else if (choice == 1)
                {
                    swC.WriteLine(next);
                    Log.AddWriting(FullFileNameC, next.GetElem(Column));
                }
                else if (choice == 2)
                {
                    swD.WriteLine(next);
                    Log.AddWriting(FullFileNameD, next.GetElem(Column));
                }

                cur = next;
                next = srA.ReadLine();
            }

            srA.Close(); swB.Close(); swC.Close(); swD.Close();
        }

        private void RewriteToMainFile()
        {
            StreamWriter swA = new StreamWriter(PathA);

            StreamReader srB = new StreamReader(PathB);
            StreamReader srC = new StreamReader(PathC);
            StreamReader srD = new StreamReader(PathD);

            IsLastRewrite = true;
            bool isNewSeriesB = false;
            bool isNewSeriesC = false;
            bool isNewSeriesD = false;

            string curB = srB.ReadLine();
            string curC = srC.ReadLine();
            string curD = srD.ReadLine();

            if (curB != null)
            {
                Log.AddReading(FullFileNameB, curB.GetElem(Column));
                Log.AddNewSeries(FullFileNameB, curB.GetElem(Column));
            }
            if (curC != null)
            {
                Log.AddReading(FullFileNameC, curC.GetElem(Column));
                Log.AddNewSeries(FullFileNameC, curC.GetElem(Column));
            }
            if (curD != null)
            {
                Log.AddReading(FullFileNameD, curD.GetElem(Column));
                Log.AddNewSeries(FullFileNameD, curD.GetElem(Column));
            }

            string nextB = srB.ReadLine();
            string nextC = srC.ReadLine();
            string nextD = srD.ReadLine();

            swA.WriteLine(Header);
            while (true)
            {
                if (curB == null && curC == null && curD == null &&
                    nextB == null && nextC == null && nextD == null) break;

                InitNextSeriesPointers(ref srB, ref srC, ref srD, ref curB,
                    ref curC, ref curD, ref nextB, ref nextC, ref nextD,
                    ref isNewSeriesB, ref isNewSeriesC, ref isNewSeriesD);

                if (curB == null && curC == null)
                {
                    WriteAndSetNextPointers(ref swA, ref srD, ref curD, ref nextD, ref isNewSeriesD, FullFileNameD);
                }
                else if (curB == null && curD == null)
                {
                    WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                }
                else if (curC == null && curD == null)
                {
                    WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                }
                else if (curB == null)
                {
                    if (Compare(curC, curD))
                    {
                        WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                    }
                    else
                    {
                        WriteAndSetNextPointers(ref swA, ref srD, ref curD, ref nextD, ref isNewSeriesD, FullFileNameD);
                    }
                }
                else if (curC == null)
                {
                    if (Compare(curB, curD))
                    {
                        WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                    }
                    else
                    {
                        WriteAndSetNextPointers(ref swA, ref srD, ref curD, ref nextD, ref isNewSeriesD, FullFileNameD);
                    }
                }
                else if (curD == null)
                {
                    if (Compare(curB, curC))
                    {
                        WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                    }
                    else
                    {
                        WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                    }
                }
                else
                {
                    if (Compare(curB, curC))
                    {
                        if (Compare(curB, curD))
                        {
                            WriteAndSetNextPointers(ref swA, ref srB, ref curB, ref nextB, ref isNewSeriesB, FullFileNameB);
                        }
                        else
                        {
                            WriteAndSetNextPointers(ref swA, ref srD, ref curD, ref nextD, ref isNewSeriesD, FullFileNameD);
                        }
                    }
                    else
                    {
                        if (Compare(curC, curD))
                        {
                            WriteAndSetNextPointers(ref swA, ref srC, ref curC, ref nextC, ref isNewSeriesC, FullFileNameC);
                        }
                        else
                        {
                            WriteAndSetNextPointers(ref swA, ref srD, ref curD, ref nextD, ref isNewSeriesD, FullFileNameD);
                        }
                    }
                }
            }
            swA.Close(); srB.Close(); srC.Close(); srD.Close();
        }

        private void InitNextSeriesPointers(ref StreamReader srB, ref StreamReader srC,
            ref StreamReader srD, ref string curB, ref string curC, ref string curD,
            ref string nextB, ref string nextC, ref string nextD, ref bool isNewSeriesB,
            ref bool isNewSeriesC, ref bool isNewSeriesD)
        {
            if (curB == null && curC == null && curD == null)
            {
                if (nextB != null)
                {
                    curB = nextB;
                    nextB = srB.ReadLine();

                    Log.AddReading(FullFileNameB, curB.GetElem(Column));
                    if (isNewSeriesB)
                    {
                        Log.AddNewSeries(FullFileNameB, curB.GetElem(Column));
                        isNewSeriesB = false;
                    }
                }
                if (nextC != null)
                {
                    curC = nextC;
                    nextC = srC.ReadLine();

                    Log.AddReading(FullFileNameC, curC.GetElem(Column));
                    if (isNewSeriesC)
                    {
                        Log.AddNewSeries(FullFileNameC, curC.GetElem(Column));
                        isNewSeriesC = false;
                    }
                }
                if (nextD != null)
                {
                    curD = nextD;
                    nextD = srD.ReadLine();

                    Log.AddReading(FullFileNameD, curD.GetElem(Column));
                    if (isNewSeriesD)
                    {
                        Log.AddNewSeries(FullFileNameD, curD.GetElem(Column));
                        isNewSeriesD = false;
                    }
                }
            }
        }

        private void WriteAndSetNextPointers(ref StreamWriter sw, ref StreamReader sr,
            ref string cur, ref string next, ref bool isNewSeries, string file)
        {
            sw.WriteLine(cur);
            Log.AddWriting(FullFileName, cur.GetElem(Column));

            if (next != null && !Compare(cur, next, false))
            {
                Log.AddEndSeries(file, cur.GetElem(Column));
                cur = null;
                IsLastRewrite = false;
                isNewSeries = true;
            }
            else
            {
                if (next != null) Log.AddReading(file, next.GetElem(Column));

                cur = next;
                next = sr.ReadLine();
            }
        }

        private bool Compare(string str1, string str2, bool write = true)
        {
            string[] line1 = str1.Split(';');
            string[] line2 = str2.Split(';');

            if (write) Log.AddComparison(line1[Column], line2[Column]);

            if (HelpUtils.IsParseAvalible(line1[Column]) && HelpUtils.IsParseAvalible(line2[Column]))
            {
                return (int.Parse(line1[Column]) <= int.Parse(line2[Column]));
            }
            else
            {
                return HelpUtils.CompareTwoWords(line1[Column], line2[Column]);
            }
        }
    }

    public static class HelpUtils
    {
        public static void ChangeFlag(ref bool flag)
        {
            if (flag) flag = false;
            else flag = true;
        }

        public static bool CompareTwoWords(string word1, string word2)
        {
            int minLen = Math.Min(word1.Length, word2.Length);
            for (int i = 0; i < minLen; i++)
            {
                if (word1[i] < word2[i])
                {
                    return true;
                }
                else if (word1[i] > word2[i])
                {
                    return false;
                }
            }
            if (word1.Length >= word2.Length) return true;
            else return false;
        }

        public static bool IsParseAvalible(string str)
        {
            try
            {
                int num = int.Parse(str);
                return true;
            }
            catch { return false; }
        }
    }

    public static class StringExtansion
    {
        public static string GetElem(this string str, int index)
        {
            string[] array = str.Split(';');
            return array[index];
        }
    }
}