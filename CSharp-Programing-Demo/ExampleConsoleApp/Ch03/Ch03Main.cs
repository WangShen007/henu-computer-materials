using System;
using System.Collections.Generic;
namespace ExampleConsoleApp.Ch03
{
    class Ch03Main
    {
        public Ch03Main()
        {
            ShowMenu();
        }
        private void ShowMenu()
        {
            List<string> menu = new List<string>
            {
                "0：返回",
                "1：例3-1 常量和变量",
                "2：例3-2 枚举",
                "3：例3-3 字符串",
                "4：例3-4 一维数组（统计）",
                "5：例3-5 一维数组（复制和排序）",
                "6：例3-6 二维数组",
                "7：例3-7 交错数组",
                "8：例3-8 类型转换",
                "9：例3-9 if语句",
                "10：例3-10 switch语句",
                "11：例3-11 for语句",
                "12：例3-12 foreach语句",
                "13：例3-13 while语句",
                "14：例3-14 do-while语句",
                "15：例3-15 try-catch语句",
            };
            while (true)
            {
                int n = Program.ShowSubMenu(menu, "第3章主菜单");
                if (n == -1) continue;
                switch (n)
                {
                    case 0: return;
                    case 1: new E01(); break;
                    case 2: new E02enum(); break;
                    case 3: new E03string(); break;
                    case 4: new E04Array1(); break;
                    case 5: new E05Array2(); break;
                    case 6: new E06Array3(); break;
                    case 7: new E07Array4(); break;
                    case 8: new E08convert(); break;
                    case 9: new E09if(); break;
                    case 10: new E10switch(); break;
                    case 11: new E11for(); break;
                    case 12: new E12foreach(); break;
                    case 13: new E13while(); break;
                    case 14: new E14do_while(); break;
                    case 15: new E15try_catch(); break;
                }
                Program.WaitKey();
            }
        }
    }
}
