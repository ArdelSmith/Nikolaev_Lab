using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrimSort
{
    public static class Comparers
    {
        public class ComparerInt : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                return x - y;
            }
        }
        public class ComparerString : StringComparer
        {
            public override int Compare(string x, string y)
            {
                return String.Compare(x, y);
            }

            public override bool Equals(string x, string y)
            {
                return x == y;
            }

            public override int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}