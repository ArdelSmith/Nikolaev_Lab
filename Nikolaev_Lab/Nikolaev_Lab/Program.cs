using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task_One;

namespace Nikolaev_Lab
{
    class Program
    {
        public static void Main()
        {
            //string[] names = Directory.GetFiles(Environment.CurrentDirectory, "*.csv");
            //foreach (string name in names)
            //{
            //    string normalName = Path.GetFileName(name);
            //    List<string> list = new List<string>();
            //    list = normalName.Split(".").ToList();
            //    if (normalName != "data.csv")
            //    {
            //        MatrixExperiment.FileDeleter.DeleteFile(name);
            //    }
            //}
            Project.Core.FileWriter l = new Project.Core.FileWriter();
            Project.Core.FileReader fileReader = new Project.Core.FileReader();
            Screen.ChooseTask(Screen.AskUser());
        }
    }
}
