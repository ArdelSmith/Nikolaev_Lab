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
        /// <summary>
        /// Возвращает данные в виде строки, готовой для записи в файл
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string GenerateArray(int[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    result += arr[i];
                    result += " ";
                }
                else result += arr[i];
            }
            return result;

        }
    }
}
