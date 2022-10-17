namespace Generator
{
    public class ArrayGenerator
    {
        /// <summary>
        /// Генерирует случайный массив чисел длины 10, максимальный элемент - 100
        /// </summary>
        /// <returns></returns>
        public static int[] GenerateArray()
        {
            return GenerateArray(10, 100);
        }
        public static int[] GenerateArray(int length, int maxElem)
        {
            int[] array = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(1, maxElem);
            }    
            return array;
        }
        public static string GenerateStringArray(int length, int maxElem)
        {
            string res = "";
            Random rnd = new Random();
            res += rnd.Next(1, maxElem).ToString();
            return res;
        }
        /// <summary>
        /// Возвращает данные в виде строки, готовой для записи в файл
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ArrayToString(int[] arr)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                list.Add(arr[i].ToString());
                list.Add(" ");
            }
            list.Add(arr[arr.Length-1].ToString());
            list.Add("\n");
            string result = "";
            foreach (string item in list) result += item;
            return result;
        }
    }
}
