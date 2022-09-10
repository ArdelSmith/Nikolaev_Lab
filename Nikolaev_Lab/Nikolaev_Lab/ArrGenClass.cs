<<<<<<< Updated upstream

=======
namespace ArrGen
{
    public class ArrayGenerator
    {
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
    }
}
>>>>>>> Stashed changes
