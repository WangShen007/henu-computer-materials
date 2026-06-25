namespace FuLuAConsole.LX
{
    internal class LX01
    {
        public LX01()
        {
            Console.WriteLine("{0}--{0:p}good", 12.34F);
            Console.WriteLine("{0}--{0:####}good", 0);
            Console.WriteLine("{0}--{0:00000}good", 456);
            var n = 456;
            var s1 = string.Format("{0}--{0:00000}good", n);
            var s2 = $"n--{n:00000}good";
            Console.WriteLine("{0}\t{1}", s1, s2);
        }
    }
}
