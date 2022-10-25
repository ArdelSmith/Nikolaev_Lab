using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Part1
{
    public static class DataWorker
    {
        static readonly Random _rand = new Random();

        /// <summary>Генерация команд</summary>
        /// <param name="commands">Количество команд</param>
        /// <param name="count">Количество команд для генерации</param>
        public static string Generate(int commands, int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int command = _rand.Next(1, commands + 1);
                if (command == 1) sb.Append($"{command},{_rand.Next()} ");
                else sb.Append(command + " ");
            }

            return sb.ToString();
        }
    }

}
