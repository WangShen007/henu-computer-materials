using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A03
{
    class A0303
    {
        public A0303()
        {
            while (true)
            {
                Console.Write("请输入一个整数(负值结束)：");
                string str = Console.ReadLine();
                if (int.TryParse(str, out int n) == false)
                {
                    Console.WriteLine("你输入的不是整数或超出整数的表示范围，请重新输入。");
                    continue;
                }
                if (n < 0) break;
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
