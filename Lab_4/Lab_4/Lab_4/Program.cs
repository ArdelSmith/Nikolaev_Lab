using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{ 
    public class Program
    {
        public static void Main()
        {
            Task3 task = new Task3();
            //task.ExecuteTask3("1");
            ABC_Sorter a = new ABC_Sorter(new string[] {"alice", "fagotini", "alla", "patromus", "harry"});
            //Console.WriteLine(a.GetStartArray().ArrayToString());
            //Console.WriteLine(a.AbcSort().ArrayToString());
            Menu.StartMenu();
        }
    }
}
