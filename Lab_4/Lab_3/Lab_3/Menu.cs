using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Part4;
using Lab_3.Part1;

namespace Lab_3
{
    public class Menu
    {
        public void StartMenu()
        {
            Console.CursorVisible = true;
            Console.WriteLine("Выберите пункт:");
            Console.WriteLine("1. Перевернуть список");
            Console.WriteLine("2. Перенести в начало (конец) списка последний (первый) элемент");
            Console.WriteLine("3. Найти количество различных чисел в списке");
            Console.WriteLine("4. Удалить из списка второй повторяющийся элемент");
            Console.WriteLine("5. Вставить список самого в себя");
            Console.WriteLine("6. Вставить новый элемент с сохранением неубывания");
            Console.WriteLine("7. Удалить все выбранные элементы Е");
            Console.WriteLine("8. Вставить элемент Ф перед первым вхождением элемента Е");
            Console.WriteLine("9. Дописать другой список к списку");
            Console.WriteLine("10. Разбить список на два по первому вхождению числа");
            Console.WriteLine("11. Удвоить список");
            Console.WriteLine("12. Поменять местами два заданные элемента");
            Console.WriteLine("13. Перевести инфикс в постфикс");
            string Decision = Console.ReadLine();
            Console.WriteLine("");
            ChooseSomething(Decision);
        }
        void AskForFinish()
        {
            Console.WriteLine("Want to do something another? Y/N");
            string key = Console.ReadLine();
            if (key == "Y")
            {
                Console.Clear();
                StartMenu();
            }
        }
        void ChooseSomething(string Decision)
        {
            int dec = int.Parse(Decision);
            MyList<int> list = new MyList<int>();
            MyList<int> list1 = new MyList<int>();
            list.Add(10);
            list.Add(15);
            list.Add(29);
            list.Add(15);
            list.Add(71);
            list1.Add(1);
            list1.Add(1);
            list1.Add(2);
            list1.Add(2);
            list1.Add(2);
            list1.Add(3);
            list1.Add(5);
            switch (dec)
            {
                case 1:
                    {
                        list.Print();
                        list.Reverse();
                        Console.WriteLine("List has been reversed:");
                        list.Print();
                        AskForFinish();
                        break;
                    }
                case 2:
                    {
                        list.Print();
                        list.SwapHeadAndTail();
                        Console.WriteLine("Elements has been swapped:");
                        list.Print();
                        AskForFinish();
                        break;
                    }
                case 3:
                    {
                        list.Print();
                        Console.WriteLine($"Amount of unique elems is {list.FindCountUniqueElements()}");
                        AskForFinish();
                        break;
                    }
                case 4:
                    {
                        list.Print();
                        Console.WriteLine("Какой дублирующийся элемент вы хотите удалить?");
                        int a = int.Parse(Console.ReadLine());
                        list.RemoveDuplicateElement(a);
                        list.Print();
                        Console.WriteLine("Element has been removed!");
                        AskForFinish();
                        break;
                    }
                case 5:
                    {
                        list.Print();
                        Console.WriteLine("Введите элемент");
                        int a = int.Parse(Console.ReadLine());
                        list.InsertAllValuesAfter(a);
                        list.Print();
                        Console.WriteLine("List has been inserted!");
                        AskForFinish();
                        break;
                    }
                case 6:
                    {
                        list1.Print();
                        Console.WriteLine("Введите элемент");
                        int a = int.Parse(Console.ReadLine());
                        list1.InsertBySort(a);
                        Console.WriteLine("Element has been inserted:");
                        list1.Print();
                        AskForFinish();
                        break;
                    }
                case 7:
                    {
                        list1.Print();
                        Console.WriteLine("Введите элемент");
                        int a = int.Parse(Console.ReadLine());
                        list1.RemoveAllDuplicates(a);
                        Console.WriteLine("Element has veen removed:");
                        list1.Print();
                        AskForFinish();
                        break;
                    }
                case 8:
                    {
                        list1.Print();
                        Console.WriteLine("Введите элемент 1");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите элемент 2");
                        int b = int.Parse(Console.ReadLine());
                        list1.InsertElementAfterFirstFind(a, b);
                        Console.WriteLine("Element 10 has been inserted before 2:");
                        list.Print();
                        AskForFinish();
                        break;
                    }
                case 9:
                    {
                        list1.Print();
                        list1.AddByFile("bebra.txt");
                        Console.WriteLine("List has been inserted:");
                        list1.Print();
                        AskForFinish();
                        break;
                    }
                case 10:
                    {
                        MyList<int> divided = new MyList<int>();
                        list1.Print();
                        Console.WriteLine("Введите элемент");
                        int a = int.Parse(Console.ReadLine());
                        divided = list1.Split(a);
                        Console.WriteLine("Old list:");
                        list1.Print();
                        Console.WriteLine("New list:");
                        divided.Print();
                        AskForFinish();
                        break;
                    }
                case 11:
                    {
                        list1.Print();
                        list1.Multiply();
                        Console.WriteLine("Multiplied list:");
                        list1.Print();
                        AskForFinish();
                        break;
                    }
                case 12:
                    {
                        list.Print();
                        Console.WriteLine("Введите элемент 1");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите элемент 2");
                        int b = int.Parse(Console.ReadLine());
                        list.Swap(a, b);
                        Console.WriteLine("New list:");
                        list.Print();
                        AskForFinish();
                        break;
                    }
                case 13:
                    {
                        Console.WriteLine("Введите выражение в инфиксной записи (каждый символ отделяется пробелом, в т.ч и скобки):");
                        string virarjenie = Console.ReadLine();    
                        PostfixHandler.InfixToPostfix(virarjenie.Split(' '), new OperationsRepo());
                        AskForFinish();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такого варианта нет!");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        StartMenu();
                        break;
                    }
            }
        }
    }
}
