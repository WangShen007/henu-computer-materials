namespace ClientConsoleExamples.ch02
{
    internal class E0201
    {
        public E0201()
        {
            Console.Write("请输入两个数（空格分隔）：");
            var c = Console.ReadLine();
            string s;
            if (c == null)
            {
                return;
            }
            else
            {
                s = c;
            }
            string[] sArray = s.Split(' ');
            string r = $"两个数的和为：{int.Parse(sArray[0]) + int.Parse(sArray[1])}";
            Console.WriteLine(r);
        }
    }
}
