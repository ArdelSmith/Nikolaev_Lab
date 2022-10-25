using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Part4;

using System.Collections.Generic;
namespace Lab_3.Part1
{
    public class MyStack<T>
    {
        int top = -1;   
        private MyList<T> st;
        public MyStack()
        {
            st = new MyList<T>();
        }
        public int Count()
        {
            if (top > 0) return top++;
            else return 0;
        }
        public void Push(T elem)
        {
            st.Add(elem);
            top += 1;
        }
        public bool IsEmpty()
        {
            return st.Count == 0;
        }
        public void Pop()
        {
            if (!IsEmpty())
            {
                MyList<T> list = new MyList<T>();
                int count = 0;
                foreach (T elem in st)
                {
                    if (count < top)
                    {
                        list.Add(elem);
                        count++;
                    }
                    else break;
                }
                st = list;
                
            }
            else throw new Exception("Stack is already empty!");
        }
        public T Top()
        {
            if (!IsEmpty())
            {
                List<T> list = new List<T>();
                foreach (T elem in st)
                {
                    list.Add(elem);   
                }
                return list.Last();
            }
            else throw new Exception("Stack has no elements!");
        }
        public void Print()
        {
            if (!IsEmpty())
            {
                string str = "";
                foreach (T i in st)
                {
                    str += i.ToString();
                    str += " ";
                }
                Console.WriteLine(str);
            }
            else Console.WriteLine("Stack is empty!");
        }
        public static void ProcessCommands(string[] data, MyStack<string> stack)
        {
            foreach (string command in data)
            {
                if (command.Length > 1)
                {
                    string[] temp = command.Split(',');
                    stack.Push(temp[1]);
                }
                else
                {
                    switch (int.Parse(command))
                    {
                        case 2:
                            {
                                try
                                {
                                    stack.Pop();
                                    Console.WriteLine("Last element in stack has been deleted!");
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Stack has no elements to delete!");
                                    break;
                                }
                            }
                        case 3:
                            {
                                try
                                {
                                    Console.WriteLine(stack.Top());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Stack has no elements!");
                                    break;
                                }
                            }
                        case 4:
                            {
                                try
                                {
                                    Console.WriteLine(stack.IsEmpty());
                                    break;
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        case 5:
                            {
                                try
                                {
                                    stack.Print();
                                    break;
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        default:
                            throw new Exception("There is no such operation!");
                    }
                }
            }
        }
        public static void ProcessCommandsClassicStack(string[] data, Stack<string> stack)
        {
            foreach (string command in data)
            {
                if (command.Length > 1)
                {
                    string[] temp = command.Split(',');
                    stack.Push(temp[1]);
                }
                else
                {
                    switch (int.Parse(command))
                    {
                        case 2:
                            {
                                try
                                {
                                    stack.Pop();
                                    Console.WriteLine("Last element in stack has been deleted!");
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Stack has no elements to delete!");
                                    break;
                                }
                            }
                        case 3:
                            {
                                try
                                {
                                    Console.WriteLine(stack.Last());
                                    stack.Pop();
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Stack has no elements!");
                                    break;
                                }
                            }
                        case 4:
                            {
                                try
                                {
                                    Console.WriteLine(stack.Count > 0);
                                    break;
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        case 5:
                            {
                                try
                                {
                                    Console.WriteLine(stack);
                                    break;
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        default:
                            throw new Exception("There is no such operation!");
                    }
                }
            }
        }
    }
}
