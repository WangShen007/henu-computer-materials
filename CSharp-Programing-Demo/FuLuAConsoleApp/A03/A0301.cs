using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A03
{
    class A0301
    {
        public A0301()
        {
            string str = "";
            while (true)
            {
                Console.Write("请输入一个长度大于3的字符串：");
                str = Console.ReadLine();
                if (str.Length <= 3)
                {
                    Console.WriteLine("字符串长度不符合要求，请重新输入！");
                    continue;
                }
                Console.WriteLine();
                break;
            }

            //（1）
            Console.WriteLine("（1）字符串的长度为：{0}", str.Length);

            //（2）
            int i = str.IndexOf('a');
            if (i > -1)
            {
                Console.WriteLine("（2）第一个出现字母a的位置是：{0}", i);
            }
            else
            {
                Console.WriteLine("（2）字符串中不包含字母a。");
            }

            //（3）
            string str1 = str.Insert(3, "hello");  //在第3个（初始序号为）字符前插入hello
            Console.WriteLine("（3）插入hello后的结果为：{0}", str1);

            //（4）
            string str2 = str1.Replace("hello", "me");
            Console.WriteLine("（4）将hello替换为me后的结果为：{0}", str2);

            //（5）
            string[] arr = str2.Split('m');
            Console.Write($"（5）以m为分隔符分离后的字符串有{arr.Length}个：");
            for (int j = 0; j < arr.Length; j++)
            {
                Console.Write(arr[j] + " ");
            }
            Console.WriteLine();
        }
    }
}
