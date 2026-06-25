using System;
using System.Collections.Generic;
using System.Reflection;
namespace ExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) ShowMenu();
            else ExecExample(args[0]);
        }
        private static void ShowMenu()
        {
            List<string> menu = new List<string>
            {
                "0：退出", "1：第1章", "2：第2章", "3：第3章",
            };
            while (true)
            {
                int n = ShowSubMenu(menu, "ExampleConsoleApp主菜单");
                if (n == -1) continue;
                switch (n)
                {
                    case 0: return;
                    case 1: ExecExample("ExampleConsoleApp.Ch01.Ch01Main"); break;
                    case 2: ExecExample("ExampleConsoleApp.Ch02.Ch02Main"); break;
                    case 3: ExecExample("ExampleConsoleApp.Ch03.Ch03Main"); break;
                        //或者
                        //case 1: new Ch01.Ch01Main(); break;
                        //case 2: new Ch02.Ch02Main(); break;
                        //case 3: new Ch03.Ch03Main(); break;
                }
            }
        }
        private static void ExecExample(string typeName)
        {
            ShowInfo($"{typeName}\n\n");
            if (Type.GetType(typeName) == null)
            {
                ShowWarn("获取类型失败，请检查传递的参数是否正确！");
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                assembly.CreateInstance(typeName);
            }
            WaitKey();
        }
        public static void ShowInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(info);
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.Write("\n按任意键继续...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>返回选择的菜单序号(-1表示有错)。</summary>
        public static int ShowSubMenu(List<string> menu, string title)
        {
            Console.Clear();  //清屏
            ShowInfo($"{title}\n\n");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i]);
            }
            ShowInfo("\n请选择要执行的功能（键入序号并回车）：");
            string s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out int n) == false)
            {
                ShowWarn("请键入序号，不要键入其他符号。");
                WaitKey();
                return -1;
            }
            if (n == 0) return n;
            if (n >= menu.Count || n < 1)
            {
                ShowWarn("无此例子，请检查键入的序号是否正确！");
                WaitKey();
                return -1;
            }
            Console.Clear();
            ShowInfo(menu[n].Substring(menu[n].IndexOf('：') + 1) + "\n\n");
            return n;
        }
    }
}
