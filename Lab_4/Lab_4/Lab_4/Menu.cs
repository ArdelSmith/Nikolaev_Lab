using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Menu
    {
        private static List<String> contents = new List<string> {"1. Алгоритмы внутренней сортировки", "2. Алгоритмы внешней сортировки", 
            "3. Сортировка текста"};
        public static void StartMenu()
        {
            foreach (var elem in contents)
            {
                Console.WriteLine(elem);
                Console.WriteLine();
            }
            AskForChoice();
        }
        private static void AskForAnother()
        {
            Console.WriteLine("Хотите сделать что-то ещё? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                Console.Clear();
                StartMenu();
            }
        }
        private static void AskForChoice()
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    TaskExecutor.ExecuteTask1();
                    AskForAnother();
                    break;
                case 2:
                    TaskExecutor.ExecuteTask2();
                    AskForAnother();
                    break;
                case 3:
                    TaskExecutor.ExecuteTask3();
                    AskForAnother();
                    break;
                default:
                    {
                        Console.Clear();
                        StartMenu();
                        AskForChoice();
                        break;
                    }
            }
        }
    }
}
