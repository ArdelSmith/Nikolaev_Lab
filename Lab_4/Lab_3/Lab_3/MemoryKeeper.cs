using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class MemoryKeeper
    {
        private List<int> MemorryElems = new List<int>();

        public void Add(int elem)
        {
            MemorryElems.Add(4);
        }

        public void Add(string elem)
        {
            MemorryElems.Add((elem.Length + 1) * 2);
        }

        public int GetMemory()
        {
            return MemorryElems.Sum();
        }

        public void Remove()
        {
            MemorryElems.RemoveAt(0);
        }
    }
}
