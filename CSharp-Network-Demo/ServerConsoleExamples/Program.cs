namespace ServerConsoleExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C/S应用编程服务器端示例\n");
            List<string> menu = new()
            {
                "0：退出",
                "1：例7-1 棋子消消乐服务器端程序",
                "2：例7-2 群聊服务器端程序",
                "3：例7-3 五子棋服务器端程序",
                "4：例7-6 多机协同绘图系统服务器端程序"
            };
            int n = ShowMenu(menu);
            switch (n)
            {
                case 0: return;
                case 1: _ = new ch07.E01.E0701Main(); break;
                case 2: _ = new ch07.E02.E0702Main(); break;
                case 3: _ = new ch07.E03.E0703Main(); break;
                case 4: _ = new ch07.E06.E0706Main(); break;
            }
        }

        public static int ShowMenu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }
            Console.Write("\n请选择要执行的功能（键入序号并回车）：");
            string? s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out int n) == false)
            {
                Console.WriteLine("警告：请键入序号，不要键入其他符号。");
                Console.Write("按任意键继续...");
                Console.ReadKey();
            }
            return n;
        }
    }
}