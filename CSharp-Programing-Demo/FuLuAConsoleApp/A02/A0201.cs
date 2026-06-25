using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A02
{
    class A0201
    {
        public A0201()
        {
            //(1)
            Console.WriteLine("{0}--{0:p}good", 12.34F);
            Console.WriteLine("{0}--{0:####}good", 0);
            Console.WriteLine("{0}--{0:00000}good", 456);

            //(2)
            var n = 456;
            var s1 = string.Format("{0}--{0:00000}good", n);
            var s2 = $"n--{n:00000}good";
            Console.WriteLine("{0}\t{1}", s1, s2);
        }
    }
}
