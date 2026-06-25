using System;
using System.Collections.Generic;
namespace ExampleConsoleApp.Ch02
{
    class Ch02Main
    {
        public Ch02Main()
        {
            ExecMenu();
        }
        private void ExecMenu()
        {
            List<string> menu = new List<string>
            {
                "0：返回",
                "1：例2-1 求两个数的和。",
                "2：例2-2 求n个数的和。",
                "3：例2-3 数据的格式化输出。",
            };
            while (true)
            {
                int n = Program.ShowSubMenu(menu, "第2章主菜单");
                if (n == -1) continue;
                switch (n)
                {
                    case 0: return;
                    case 1: new E01Add(); break;
                    case 2: new E02Sum(); break;
                    case 3: new E03DataOutput(); break;
                }
                Program.WaitKey();
            }
        }
    }
}
