using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Part1
{
    public static class PostfixHandler
    {
        public static void InfixToPostfixStandart(string data)
        {
            string[] infix = data.Split(' ');
            int n = 0;
            bool flag = true;
            string postfix = "";
            Stack<string> nums = new Stack<string>();
            Stack<string> ops = new Stack<string>();
            foreach (string s in infix)
            {
                if (n == 2 && flag)
                {
                    string second = nums.Last();
                    nums.Pop();
                    string first = nums.Last();
                    nums.Pop();
                    postfix += first.ToString() + " " + second.ToString() + " " + ops.Last();
                    ops.Pop();
                    nums.Push(postfix);
                    n = 1;
                    flag = false;
                }
                else if (n == 2 && !flag)
                {
                    string first = nums.Last();
                    nums.Pop();
                    postfix += " " + first.ToString() + " " + ops.Last();
                    ops.Pop();
                    nums.Push(postfix);
                    n = 1;
                }
                try
                {
                    double e = double.Parse(s);
                    nums.Push(e.ToString());
                    n += 1;
                }
                catch
                {
                    ops.Push(s);
                }
            }
            if (ops.Count != 0)
            {
                string sec = nums.Last();
                nums.Pop();
                string f = nums.Last();
                Console.WriteLine(f + " " + sec + " " + ops.Last());
            }
            else
            {
                Console.WriteLine(nums.Last());
            }
        }
        public static void InfixToPostfix(string data)
        {
            string[] infix = data.Split(' ');
            int n = 0;
            bool flag = true;
            string postfix = "";
            MyStack<string> nums = new MyStack<string>();
            MyStack<string> ops = new MyStack<string>();
            foreach (string s in infix)
            {
                if (n == 2 && flag)
                {
                    string second = nums.Top();
                    nums.Pop();
                    string first = nums.Top();
                    nums.Pop();
                    postfix += first.ToString() + " " + second.ToString() + " " + ops.Top();
                    ops.Pop();
                    nums.Push(postfix);
                    n = 1;
                    flag = false;
                }
                else if (n == 2 && !flag)
                {
                    string first = nums.Top();
                    nums.Pop();
                    postfix += " " + first.ToString() + " "  + ops.Top();
                    ops.Pop();
                    nums.Push(postfix);
                    n = 1;
                }
                try
                {
                    double e = double.Parse(s);
                    nums.Push(e.ToString());
                    n += 1;
                }
                catch 
                {
                    ops.Push(s);
                }
            }
            if (!ops.IsEmpty())
            {
                string sec = nums.Top();
                nums.Pop();
                string f = nums.Top();
                Console.WriteLine(f + " " + sec + " " + ops.Top());
            }
            else
            {
                Console.WriteLine(nums.Top());
            }
        }

        public static double ProcessOperation(string operation, MyStack<double> stack)
        {
            switch (operation)
            {
                case "+":
                    {
                        double second = stack.Top();
                        stack.Pop();
                        double first = stack.Top();
                        stack.Pop();
                        return (first + second);
                    }
                case "-":
                    {
                        double second = stack.Top();
                        stack.Pop();
                        double first = stack.Top();
                        stack.Pop();
                        return first - second;
                    }
                case "*":
                    {
                        double second = stack.Top();
                        stack.Pop();
                        double first = stack.Top();
                        stack.Pop();
                        return (first * second);
                    }
                case "/":
                    {
                        double second = stack.Top();
                        stack.Pop();
                        double first = stack.Top();
                        stack.Pop();
                        return first / second;
                    }
                case "ln":
                    {
                        double n = stack.Top();
                        stack.Pop();
                        return Math.Log(n);
                    }
                case "sin":
                    {
                        double n = stack.Top();
                        stack.Pop();
                        return Math.Sin(n);
                    }
                case "cos":
                    {
                        double n = stack.Top();
                        stack.Pop();
                        return Math.Cos(n);
                    }
                case "sqrt":
                    {
                        double n = stack.Top();
                        stack.Pop();
                        return Math.Sqrt(n);
                    }
                case "^":
                    {
                        double second = stack.Top();
                        stack.Pop();
                        double first = stack.Top();
                        stack.Pop();
                        return Math.Pow(first, second);
                    }
                default:
                    throw new Exception("Such operation is not supported!");

            }
        }
        public static List<string> ProcessRawData(string data)
        {
            List<string> result = new List<string>();
            string[] temp = data.Split(' ');
            foreach(string s in temp)
            {
                result.Add(s);
            }
            return result;
        }
        /// <summary>
        /// Приводит постфиксную запись к конечному результату
        /// </summary>
        /// <param name="data">Список с данными - как операциями, так и числами</param>
        public static void DoCalculations(List<string> data)
        {
            MyStack<double> stack = new MyStack<double>();
            foreach (string s in data)
            {
                try
                {
                    double elem = double.Parse(s);
                    stack.Push(elem);
                }
                catch
                {
                    stack.Push(ProcessOperation(s, stack));
                    stack.Print();
                }
            }
        }

        public static string InfixToPostfix(string[] strSplit, OperationsRepo operationsRepo)
        {
            MyStack<string> stack = new MyStack<string>();
            List<Operation> operations = operationsRepo.GetOperations();

            StringBuilder sb = new StringBuilder();

            double num = 0;
            for (int i = 0; i < strSplit.Length; i++)
            {
                if (double.TryParse(strSplit[i], out num))
                {
                    sb.Append($"{strSplit[i]} ");
                }
                else if (strSplit[i].Equals("("))
                    stack.Push(strSplit[i]);
                else if (strSplit[i].Equals(")"))
                {
                    while (stack.Count() != 0 && !stack.Top().Equals("("))
                        sb.Append($"{stack.Top()} ");
                    stack.Pop();
                    stack.Pop();
                }
                else
                {
                    Operation op = operations.FirstOrDefault(x => x.Name == strSplit[i]);
                    if (op == null) continue;

                    Operation top = operations.FirstOrDefault(x => stack.Count() != 0 && x.Name == stack.Top());
                    while (stack.Count() != 0 && top is not null && top.Priority >= op.Priority)
                    {
                        sb.Append($"{stack.Pop()} ");
                        top = operations.FirstOrDefault(x => stack.Count() != 0 && x.Name == stack.Top());
                    }
                    stack.Push(op.Name);
                }
            }

            while (stack.Count() != 0)
            {
                sb.Append($"{stack.Pop()}");
            }

            return sb.ToString();
        }
    }
}
