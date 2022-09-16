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
            if (!File.Exists(DataBase.FileName + DataBase.FileExtension)) File.WriteAllText(DataBase.FileName + DataBase.FileExtension,
                ArrayGenerator.GenerateArray(ArrayGenerator.GenerateArray()));
            else
            {
                string data = File.ReadAllText(DataBase.FileName + DataBase.FileExtension);
                File.WriteAllText(DataBase.FileName + DataBase.FileExtension,data + "\n" +
                ArrayGenerator.GenerateArray(ArrayGenerator.GenerateArray(15, 40440)));
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
                ///DataBase.Data = 
            }
        }
    }
}

