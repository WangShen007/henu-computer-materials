namespace FuLuAConsole.SY
{
    internal class SY04
    {
        public SY04()
        {
            for (int i = 2; i <= 1000; i++)
            {
                int s = 1;
                string str = "1";
                for (int j = 2; j <= (int)Math.Sqrt(i); j++)
                {
                    if (j * (i / j) == i)
                    {
                        if (j != i / j)
                        {
                            s += j + i / j;
                            str += string.Format("+{0}+{1}", j, i / j);
                        }
                        else
                        {
                            s += j;
                            str += string.Format("+{0}", j);
                        }
                    }
                }
                if (s == i) Console.WriteLine("{0}={1}", i, str);
            }
        }
    }
}
