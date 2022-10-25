using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public static class FileWriter
    {
        public static void WriteData(string path, string content)
        {
            string line = $"{content}\n";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, line);
            }
            else
            {
                File.AppendAllText(path, line);
            }
        }
        public static void WriteData(string path, double time, long memory)
        {
            string line = $"{time / 1000.0};{memory}\n";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, line);
            }
            else
            {
                File.AppendAllText(path, line);
            }
        }
        public static void WriteData(string path, int i, double time, long memory)
        {
            string line = $"{i};{time / 1000.0};{memory}\n";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, line);
            }
            else
            {
                File.AppendAllText(path, line);
            }
        }
    }
}
