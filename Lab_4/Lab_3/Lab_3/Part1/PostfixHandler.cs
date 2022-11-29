using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Operations;

namespace Lab_3.Part1
{
    public abstract class Operation : IComparable<Operation>
    {
        public abstract string Name { get; }
        public abstract int Priority { get; }
        public abstract bool hasTwoOperands { get; }
        public abstract double Calculate(double left, double? right = null);

        /// <returns>Если операндов 2 - true, иначе - false</returns>
        public bool Check(double left, double? right = null)
        {
            return right is not null;
        }

        public int CompareTo(Operation? other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));

            return Priority.CompareTo(other.Priority);
        }
    }
    public class OperationsRepo
    {
        private List<Operation> operations { get; set; }

        public OperationsRepo()
        {
            operations = new List<Operation>()
            {
                new Addition(),
                new Cosinus(),
                new Division(),
                new Exponentiation(),
                new Multiplication(),
                new NaturalLogarithm(),
                new Sinus(),
                new Sqrt(),
                new Subtraction()
            };
        }

        public List<Operation> GetOperations()
        {
            return operations.ToList();
        }
    }
    public static class PostfixHandler
    {
       
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
                        sb.Append($"{stack.Pop()} ");
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
                sb.Append($"{stack.Pop()} ");
            }

            Console.WriteLine(sb.ToString()); 
            return sb.ToString();
        } 
    
    }
}
