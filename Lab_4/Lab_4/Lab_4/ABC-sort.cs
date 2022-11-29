using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{

    public class ABC_Sorter
    {
        private static string[] AbsSort_13(string[] list) => new ABC_Sorter(list).AbcSort();
        private static int?[] Indexes;
        private static List<int?[]> Level;
        private static List<string> Result;
        private static string[] List;
        private static string[] SortedArray;
        private static Dictionary<string, int> SortedDictionary;

        public ABC_Sorter(string[] list)
        {
            List = list;
            Indexes = new int?[List.Length];
            Level = new List<int?[]> { new int?[26] };
            Result = new List<string>();
        }
        public string ArrayToString(string[] array)
        {
            StringBuilder a = new StringBuilder();
            a.Append("{ ");
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length)
                {
                    a.Append(array[i]);
                    a.Append(", ");
                }
                else
                {
                    a.Append(array[i]);
                }
            }
            a.Append(" }");
            return a.ToString();
        }
        public string[] GetStartArray()
        {
            return List;
        }
        public string[] GetResult()
        {
            return Result.ToArray();
        }
        public static void PrintDict(Dictionary<string, int> d)
        {
            foreach (string key in d.Keys)
            {
                Console.WriteLine(key + " " + d[key]);
            }
        }
        public static Dictionary<string, int> CreateDictionary()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string elem in Result)
            {
                if (dict.ContainsKey(elem.ToLower()))
                {
                    dict[elem.ToLower()] += 1;
                }
                else
                {
                    dict.Add(elem.ToLower(), 1);
                }
            }
            SortedDictionary = dict;
            return dict;
        }

        public string[] AbcSort()
        {
            for (var i = 0; i < List.Length; i++)
            {
                var letter = char.ToUpper(List[i][0]) - 65;
                Indexes[i] = Level[0][letter];
                Level[0][letter] = i;
            }
            ClearLevel(0);
            return Result.ToArray();
        }
        private static void ClearLevel(int depth)
        {
            if (Level.Count == depth + 1)
                Level.Add(new int?[26]);
            for (var i = 0; i < 26; i++)
            {
                if (Level[depth][i] != null)
                {
                    var pos = Level[depth][i].GetValueOrDefault();
                    if (Indexes[pos] == null)
                    {
                        Result.Add(List[pos]);
                        Level[depth][i] = null;
                    }
                    else
                    {
                        MarkChain(pos, depth);
                        Level[depth][i] = null;
                        ClearLevel(depth + 1);
                    }
                }
            }
        }
        private static void MarkChain(int pos, int depth)
        {
            while (true)
            {
                var nextPos = Indexes[pos];
                if (depth + 1 >= List[pos].Length)
                {
                    Result.Add(List[pos]);
                    Indexes[pos] = null;
                }
                else
                {
                    int letter = char.ToUpper(List[pos][depth + 1]) - 65;
                    Indexes[pos] = Level[depth + 1][letter];
                    Level[depth + 1][letter] = pos;
                }
                if (nextPos == null)
                    break;
                else
                    pos = nextPos.GetValueOrDefault();
            }
        }
    }
}
