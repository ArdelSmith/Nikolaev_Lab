using System;
using System.Collections.Generic;
using Lab_3.Part4;

namespace task4
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    StartTask();
        //    StartFibonacci();
        //}

        private static void StartTask()
        {
            MyList<int> linkedList = new MyList<int>();
            // добавление элементов
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);

            // выводим элементы
            Console.WriteLine("Изначальный список:");
            linkedList.Print();
            // удаляем элемент
            linkedList.Remove(3);
            Console.WriteLine("\nСписок после удаления 3:");
            linkedList.Print();
            // проверяем наличие элемента
            Console.WriteLine(linkedList.Contains(2) == true ? "\n2 присутствует" : "\n2 отсутствует");

            // добавляем элемент в начало            
            //linkedList.AppendFirst("Bill");

            // метод для "переворачивания" списка
            linkedList.Reverse();
            Console.WriteLine("\nПосле переворачивания список:");
            linkedList.Print();

            linkedList.SwapHeadAndTail();
            Console.WriteLine("\nСписок после смены местами первого и последнего элемента:");
            linkedList.Print();

            Console.WriteLine("\nКол-во уникальных элементов в списке: " + linkedList.FindCountUniqueElements());

            linkedList.Add(1);
            linkedList.Add(7);

            Console.WriteLine("\nСписок после добавление 1 и 7:");
            linkedList.Print();

            linkedList.RemoveDuplicateElement(1);
            Console.WriteLine("\nСписок после удаления второго такого же элемента, как " + 1 + ":");
            linkedList.Print();

            linkedList.InsertBySort(3);
            Console.WriteLine("\nСписок после вставки в него 3, не нарушая упорядоченность: ");
            linkedList.Print();

            linkedList.InsertAllValuesAfter(4);
            Console.WriteLine("\nСписок после вставки самого себя же после значения 4:");
            linkedList.Print();

            linkedList.RemoveAllDuplicates(1);
            Console.WriteLine("\nСписок после удаления всех 1:");
            linkedList.Print();

            linkedList.InsertElementAfterFirstFind(17, 3);
            Console.WriteLine("\nСписок после вставки 17 перед первой 3:");
            linkedList.Print();

            linkedList.AddByFile("input.txt");
            Console.WriteLine("\nСписок после добавления списка значений из файла:");
            linkedList.Print();

            var linkedList2 = linkedList.Split(20);
            Console.WriteLine("\nИзначальный список после разбиения:");
            linkedList.Print();
            Console.WriteLine("\nВторой список:");
            linkedList2.Print();

            linkedList.Multiply();
            Console.WriteLine("\nСписок после удвоения:");
            linkedList.Print();

            linkedList.Swap(4, 7);
            Console.WriteLine("\nСписок после перестановки:");
            linkedList.Print();

            Console.ReadKey();
            Console.Clear();
        }

        private static void StartFibonacci()
        {
            MyList<int> list = new MyList<int>() { 2, 3, 4, 5, 6, 8, 13, 21, 27 };

            int maxElem = GetMax(list);
            List<int> fibonacciNumbers = GetFibonacciNumbers(maxElem);

            Console.WriteLine("Изначальный массив:");
            list.Print();

            foreach (int num in fibonacciNumbers)
                if (list.Contains(num))
                    list.Remove(num);

            Console.WriteLine("\nМассив после удаления чисел Фибоначчи: ");
            list.Print();
        }

        private static int GetMax(MyList<int> list)
        {
            int step = 0;
            int number = 0;
            int max = 0;

            while (step != list.Count)
            {
                if (list.Contains(number) || list.Contains(number * (-1)))
                {
                    step++;
                    if (max < number)
                        max = number;
                }
                number++;
            }
            return max;
        }

        private static List<int> GetFibonacciNumbers(int upLimit)
        {
            List<int> numbers = new List<int> { 0, 1 };
            while (numbers[numbers.Count - 1] < upLimit)
            {
                numbers.Add(numbers[numbers.Count - 1] + numbers[numbers.Count - 2]);
            }
            return numbers;
        }
    }
}