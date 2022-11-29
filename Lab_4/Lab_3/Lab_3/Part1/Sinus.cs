using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Part1;

namespace Project.Core.Operations
{
    public class Sinus : Operation
    {
        public override string Name => "sin";
        public override int Priority => 4;
        public override bool hasTwoOperands => false;

        public override double Calculate(double left, double? right = null)
        {
            if (Check(left, right)) throw new ArgumentException("Неверное количество операндов");
            return Math.Sin(left);
        }
    }
}
