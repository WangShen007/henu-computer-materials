using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuLuAConsoleApp.A04
{
    class A0401
    {
        public A0401()
        {
            //（3）
            var a = new A();
            var b = new A("This is a string");
            A[] aArr = new A[5];
        }
    }

    class A
    {
        //（1）
        public A()
        {
            Console.WriteLine(this);
        }
        //（2）
        public A(string str)
        {
            Console.WriteLine(str);
        }
    }
}
