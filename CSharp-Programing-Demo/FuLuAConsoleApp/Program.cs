using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowWarn("用法不正确\n");
                Console.WriteLine("别怪我没提醒你：要在WPF页中给我传参数，否则我怎么知道该调用谁呀。");
                WaitKey();
                return;
            }

            string className = args[0];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{className}\n");
            Console.ForegroundColor = ConsoleColor.White;

            var a = Type.GetType(className);
            if (a == null)
            {
                ShowWarn("无此例子，请检查传递的参数是否正确。");
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                assembly.CreateInstance(className);
            }
            WaitKey();
        }
        public static void ShowWarn(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("警告：" + info);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WaitKey()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write("按任意键继续...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
