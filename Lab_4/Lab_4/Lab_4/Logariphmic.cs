namespace Lab
{
    public static class Logariphmic
    {
        public static int[] SortWithShell(int[] array)
        {
            {
                int n = array.Length;
                int i, j, step;
                int tmp;
                List<string> log = new List<string>();
                for (step = n / 2; step > 0; step /= 2)
                    log.Add($"Начинаем бежать по массиву с шагом {step}");
                    for (i = step; i < n; i++)
                    {
                        tmp = array[i];
                        for (j = i; j >= step; j -= step)
                        {
                            if (tmp < array[j - step]) { 
                            log.Add($"Элемент с индексом {j} и значением {array[j]} поменялся местами с элементом индексом {j - 1} и значением {array[j - 1]}");
                            array[j] = array[j - step];
                        }

                            else
                                break;
                        }
                        array[j] = tmp;
                    }
                return array;
            }
        }
    }
}