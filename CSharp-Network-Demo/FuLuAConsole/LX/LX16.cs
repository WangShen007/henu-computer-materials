namespace FuLuAConsole.LX
{
    internal class LX16
    {
        public LX16()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("使用LINQ查询列表:");
            var query1 = from t in list
                         where t % 2 == 0
                         select t;
            foreach (var m in query1)
            {
                Console.Write(m + " ");
            }
            Console.WriteLine();
            Console.WriteLine("使用Lamdam查询列表:");
            var query2 = list.Where(x => x % 2 == 0);
            foreach (var m1 in query2)
            {
                Console.Write(m1 + " ");
            }
        }
    }
}
