using System.Diagnostics;

namespace Task_Three
{
    public class IEratosfen
    {
        public void IErat(int n)
        {
            List<bool> l = new List<bool>();
            for (int i = 0; i < n+1; i++)
            {
                l.Add(true);
            }
            for (int i = 2; i*i <= n; i++)
            {
                if ((l[i]) == true)
                {
                    for (int j = i*i; j <= n; j += i)
                    {
                        l[j] = false;
                    }
                }
            }
            for (int i = 2; i < n; i++)
            {
                if (l[i] == true) Console.WriteLine(i);
            }
        }
    }
}
