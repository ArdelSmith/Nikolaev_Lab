using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikolaev_Lab
{
    public static class Screen
    {
        public static int AskUser()
        {
            Console.WriteLine("Введите число ");
            int ans = int.Parse(Console.ReadLine());
            return ans;
        }
        public static void ChooseTask(int ans)
        {
            switch (ans)
            {
                case 1:
                    {
                        Task_One.Executor.ExecuteAllTasks();
                        break;
                    }
                case 2:
                    {
                        MatrixExperiment.Launcher.StartSecondTask();
                        break;
                    }
                case 3:
                    {
                        Task_Three.Executor.ExecuteAllTasks();
                        break;
                    }
                default:
                    {
                        throw new Exception("There is no such task!");
                    }
            }
        }
    }
}
