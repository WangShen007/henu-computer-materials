namespace ClientConsoleExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mainMenu = new()
            {
                "0：退出",
                "1：Hello World!",
                "2：例2-1 求两个数的和",
                "3：例2-2 数据的格式化输出"
            };
            while (true)
            {
                int n = ShowMenu(mainMenu, "主菜单");
                if (n == -1) continue;
                //内置的下划线变量名表示使用丢弃
                switch (n)
                {
                    case 0: return;
                    case 1: _ = new ch01.HelloWorld(); break;
                    case 2: _ = new ch02.E0201(); break;
                    case 3: _ = new ch02.E0202(); break;
                }
                Console.Write("\n按任意键继续...");
                Console.ReadKey();
            }
        }

        internal static int ShowMenu(List<string> menu, string title)
        {
            Console.Clear();  //清屏
            Console.WriteLine($"{title}\n");
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
                return -1;
            }
            else if (n >= menu.Count || n < 0)
            {
                Console.WriteLine("警告：无此例子，请检查键入的序号是否正确！");
                Console.Write("按任意键继续...");
                Console.ReadKey();
                return -1;
            }
            else
                return n;
        }
    }
}