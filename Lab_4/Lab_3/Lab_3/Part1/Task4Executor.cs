using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Part1
{
    public static class Task4Executor
    {
        public static void ExecuteTask4(string path)
        {
            string data = File.ReadAllText(path);
            List<string> t = PostfixHandler.ProcessRawData(data);
            PostfixHandler.DoCalculations(t);
        }
    }
}
