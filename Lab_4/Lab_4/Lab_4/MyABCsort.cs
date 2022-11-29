using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
 
    public class MyABCsort
    {
        private List<Dictionary<int, int>> LetterTracker = new List<Dictionary<int, int>>();
        private List<Bebra> List = new List<Bebra>();
        private Dictionary<int, int> WordTracker;
        private Dictionary<int, int> Pattern = new Dictionary<int, int>();
        private class Bebra
        {
            public string Word;
            public int LowerIndex;
        }
        public MyABCsort(List<string> words)
        {
            foreach(var word in words)
            {
               Bebra a = new Bebra();
               a.Word = word;
               a.LowerIndex = 0;
               List.Add(a); 
            }
            for (int i = 0; i < 25; i++)
            {
                Pattern.Add(i, 0);
            }
        }
        public void StartSort()
        {
            FillFirstLevel();
        }
        public void FillFirstLevel() { 
            LetterTracker.Add(Pattern);
            for (int i = 0; i < List.Count; i++)
            {
                List[i].LowerIndex = LetterTracker[0][char.ToUpper(List[i].Word[0]) - 65];
                LetterTracker[0][char.ToUpper(List[i].Word[0]) - 65] = i;
            }
        }
    }
}
