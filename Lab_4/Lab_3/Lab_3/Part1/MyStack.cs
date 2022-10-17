using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
namespace Lab_3.Part1
{
    public class MyStack<T>
    {
        int top = -1;
        private List<T> st;
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
                                stack.Pop();
                                Console.WriteLine("Last element in stack has been deleted!");
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine(stack.Top());
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine(stack.IsEmpty());
                                break;
                            }
                        case 5:
                            {
                                stack.Print();
                                break;
                            }
                        default:
                            throw new Exception("There is no such operation!");
                    }
                }
            }
        }
        public MyStack()
        {
            st = new List<T>();
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
                st.RemoveAt(st.Count - 1);
                top -= 1;
            }
            else throw new Exception("Stack is already empty!");
        }
        public T Top()
        {
            if (!IsEmpty()) return st[top];
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
    }
}
