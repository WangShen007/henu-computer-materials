namespace FuLuAConsole.LX
{
    internal class LX04
    {
        public LX04()
        {
            while (true)
            {
                Console.Write("请输入5个大写字母：");
                string? str = Console.ReadLine();
                if (str == null)
                {
                    Console.WriteLine("字符个数不是5个，请重新输入。");
                    continue;
                }
                if (str.Length != 5)
                {
                    Console.WriteLine("字符个数不是5个，请重新输入。");
                    continue;
                }
                bool isValid = true;
                for (int i = 0; i < 5; i++)
                {
                    char c = str[i];
                    if (c < 'A' || c > 'Z')
                    {
                        Console.WriteLine("第{0}个字符“{1}”不是大写字母，请重新输入。", i + 1, c);
                        isValid = false;
                        break;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine("输入的字符满足要求。");
                break;
            }
        }
    }
}
