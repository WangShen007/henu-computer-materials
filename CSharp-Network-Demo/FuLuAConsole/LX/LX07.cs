namespace FuLuAConsole.LX
{
    internal class LX07
    {
        public LX07()
        {
            //（1）
            Console.Write("用for语句实现：");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("{0} ", i * i);
            }
            Console.WriteLine();

            //（2）
            Console.Write("用while语句实现：");
            int j = 0;
            while (j++ < 5)
            {
                Console.Write("{0} ", j * j);
            }
            Console.WriteLine();

            //（3）
            Console.Write("用do-while语句实现：");
            int k = 1;
            do
            {
                Console.Write("{0} ", k * k);
            } while (k++ < 5);
            Console.WriteLine();
        }
    }
}
