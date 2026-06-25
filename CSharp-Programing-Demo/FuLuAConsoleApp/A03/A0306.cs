using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A03
{
    class A0306
    {
        public A0306()
        {
            while (true)
            {
                Console.Write("请输入一个大于100的整数：");
                string s = Console.ReadLine();
                s = s.Trim();
                if (int.TryParse(s, out int n) == false)
                {
                    Console.WriteLine("错误：输入的字符串无法转换为整数！");
                    continue;
                }
                if (n <= 100)
                {
                    Console.WriteLine("错误：输入的整数不满足大于100的条件！");
                    continue;
                }
                Console.WriteLine("该整数共有{0}位。", s.Length);
                //方式1--字符提取法
                PrintResult(s);
                //方式2--整数整除法
                PrintResult(n);
                Console.WriteLine("按回车键返回，其他键继续！");
                var c = Console.ReadKey();
                if (c.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// 字符提取法：依次取字符串中的每个字符，再将字符转换为整数求和
        /// </summary>
        /// <param name="s">可被转换为整数的字符串</param>
        private void PrintResult(string s)
        {
            string s1 = "";
            int n1 = 0;
            for (int i = 0; i < s.Length; i++)
            {
                s1 += s[i] + "、";
                n1 += int.Parse(s[i].ToString());
            }
            Console.WriteLine("字符提取法：每一位的值为{0}，这些位之和为{1}", s1.TrimEnd('、'), n1);
        }

        /// <summary>
        /// 整数整除法：利用取整和求余数的办法求每一位的值，再求和。
        /// </summary>
        /// <param name="n">正整数</param>
        private void PrintResult(int n)
        {
            int length = n.ToString().Length;
            int n1 = 0;
            string s1 = "";
            for (int i = length; i > 0; i--)
            {
                int k = int.Parse("1" + new string('0', i - 1));
                s1 += n / k + "、";
                n1 += n / k;
                n %= k;
            }
            Console.WriteLine("整数整除法：每一位的值为{0}，这些位之和为{1}", s1.TrimEnd('、'), n1);
        }
    }
}
