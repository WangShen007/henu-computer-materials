using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A03
{
    class A0302
    {
        public A0302()
        {
            while (true)
            {
                Console.Write("请输入5个大写字母：");
                string str = Console.ReadLine();
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
