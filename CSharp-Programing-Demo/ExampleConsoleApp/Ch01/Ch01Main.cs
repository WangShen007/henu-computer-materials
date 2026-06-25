using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsoleApp.Ch01
{
    class Ch01Main
    {
        public Ch01Main()
        {
            ExecMenu();
        }
        private void ExecMenu()
        {
            List<string> menu = new List<string>
            {
                "0：返回",
                "1：例1-1 Hello World",
            };
            while (true)
            {
                int n = Program.ShowSubMenu(menu, "第1章主菜单");
                if (n == -1) continue;
                switch (n)
                {
                    case 0: return;
                    case 1: new E0101HelloWorld(); break;
                }
                Program.WaitKey();
            }
        }
    }
}

