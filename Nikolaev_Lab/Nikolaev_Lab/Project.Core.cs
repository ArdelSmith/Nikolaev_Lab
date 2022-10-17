using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator;

namespace Project.Core
{
    public class DataBase
    {
        protected static string FileName = "data";
        protected static string FileExtension = ".csv";
        public static string[] RawData { get; set; }
        public static List<int[]> Data { get; set; }
    }
    public class FileWriter: DataBase
    {
        public FileWriter()
        {
            if (File.Exists(DataBase.FileName + DataBase.FileExtension))
            {
            }
            else
            {
                File.WriteAllText(DataBase.FileName + DataBase.FileExtension, ArrayGenerator.GenerateStringArray(1, 100));
                File.AppendAllText(DataBase.FileName + DataBase.FileExtension, " ");
                for (int i = 0; i < 1000000; i++)
                {
                    File.AppendAllText(DataBase.FileName + DataBase.FileExtension, ArrayGenerator.GenerateStringArray(1, 100));
                    File.AppendAllText(DataBase.FileName + DataBase.FileExtension, " ");
                }
                File.AppendAllText(DataBase.FileName + DataBase.FileExtension, ArrayGenerator.GenerateStringArray(1, 100));
            }
        }
    }
    public class FileReader: DataBase
    {
        public FileReader()
        {
            if (!File.Exists(DataBase.FileName + DataBase.FileExtension)) throw new Exception("There's no such file in dir!");
            else
            {
                DataBase.RawData = File.ReadAllLines(DataBase.FileName + DataBase.FileExtension);
                List <int[]> final = new List <int[]>();
                foreach (string line in DataBase.RawData)
                {
                    string[] raw = line.Split(' ');
                    int[] arr = new int[raw.Length];
                    for (int i = 0; i < raw.Length; i++)
                    {
                        arr[i] = int.Parse(raw[i]);
                    }
                    final.Add(arr);
                }
                DataBase.Data = final;
            }
        }
    }
}

