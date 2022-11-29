﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.Part1;
namespace Project.Core.Operations
{
    public class Exponentiation : Operation
    {
        public override string Name => "^";
        public override int Priority => 3;
        public override bool hasTwoOperands => true;

        public override double Calculate(double left, double? right)
        {
            if (!Check(left, right)) throw new ArgumentException("Неверное количество операндов");
            return Math.Pow(left, (double)right);
        }
    }
}
