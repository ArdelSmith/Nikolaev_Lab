using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class FileWriter
    {
        private static string path = Environment.CurrentDirectory;
        public static void WriteFile(string[] data, string fileName)
        {
            File.WriteAllLines(path + "/" + fileName, data);
        }
        public static void WriteFile(string data, string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, data);
            }
            else
            {
                File.AppendAllText(fileName, data);
            }
        }
    }
}
