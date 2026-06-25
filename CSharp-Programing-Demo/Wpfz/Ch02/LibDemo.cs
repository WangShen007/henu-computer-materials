namespace Wpfz.Ch02
{
    public class LibDemo
    {
        public static int Sum(params int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }
    }
}
