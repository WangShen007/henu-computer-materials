using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A03
{
    class A0304
    {
        public A0304()
        {
            while (true)
            {
                Console.Write("请输入5个整数（空格分隔）：");
                string s = Console.ReadLine();
                if (s.Length == 0) return;  //如果是直接按回车键，则退出

                string[] sArray = s.Split(' ');
                if (sArray.Length != 5)
                {
                    Console.WriteLine("错误：输入的不是5个数，请再次输入。");
                    continue;
                }
                bool isValid = true;
                int[] nArray = new int[5];
                for (int i = 0; i < nArray.Length; i++)
                {
                    if (int.TryParse(sArray[i], out nArray[i]) == false)
                    {
                        Console.WriteLine("错误：无法将\"{0}\"转换为整数，请再次输入。", sArray[i]);
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine();  //输出空行
                    continue;
                }
                Array.Sort(nArray);
                Console.WriteLine("正序：{0}", string.Join(",", nArray));
                Array.Reverse(nArray);
                Console.WriteLine("逆序：{0}", string.Join(",", nArray));
                Console.WriteLine("平均值：{0:f1}", nArray.Average());
                Console.WriteLine("最大值：{0:f1}", nArray.Max());
                break;
            }
        }
    }
}
