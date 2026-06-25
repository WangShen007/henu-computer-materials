namespace FuLuAConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mainMenu = new()
            {
                "0：退出",
                "1：练习1  格式化输出",
                "3：练习3  字符串处理",
                "4：练习4  字母判断",
                "5：练习5  类型转换",
                "6：练习6  数组排序和计算",
                "7：练习7  循环语句",
                "8：练习8  类和对象",
                "9：练习16 查找列表",
                "13：实验3  字符提取",
                "14：实验4  求完数"
            };
            while (true)
            {
                int n = ShowMenu(mainMenu, "主菜单");
                if (n == -1) continue;
                //内置的下划线变量名表示使用丢弃
                switch (n)
                {
                    case 0: return;
                    case 1: _ = new LX.LX01(); break;
                    case 3: _ = new LX.LX03(); break;
                    case 4: _ = new LX.LX04(); break;
                    case 5: _ = new LX.LX05(); break;
                    case 6: _ = new LX.LX06(); break;
                    case 7: _ = new LX.LX07(); break;
                    case 8: _ = new LX.LX08(); break;
                    case 9: _ = new LX.LX16(); break;
                    case 13: _ = new SY.SY03(); break;
                    case 14: _ = new SY.SY04(); break;
                    default:
                        Console.WriteLine("警告：请检查键入的序号是否正确！");
                        break;
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
            else
            {
                return n;
            }
        }
    }
}