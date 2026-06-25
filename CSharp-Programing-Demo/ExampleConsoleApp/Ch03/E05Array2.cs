using System;
namespace ExampleConsoleApp.Ch03
{
    class E05Array2
    {
        public E05Array2()
        {
            var c = new Wpfz.Ch03.C05Array2();
            int[] a = { 23, 64, 15, 72, 36 };
            Console.WriteLine(c.ArrayDemo2(a));
            string[] b = { "Java", "C#", "C++", "VB.NET" };
            Console.WriteLine(c.ArrayDemo2(b));
        }
    }
}
