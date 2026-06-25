using System;
using Wpfz.Ch03;
namespace ExampleConsoleApp.Ch03
{
    class E02enum
    {
        public E02enum()
        {
            MyColor myColor = MyColor.Black;
            var c = new C02enum();
            Console.WriteLine(c.GetResult(myColor));
        }
    }
}
