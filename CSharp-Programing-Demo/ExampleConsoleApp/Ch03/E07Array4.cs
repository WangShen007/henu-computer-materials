using System;
namespace ExampleConsoleApp.Ch03
{
    class E07Array4
    {
        public E07Array4()
        {
            string[][] a =
{
                new string[] { "a11", "a12" },
                new string[] { "a21", "a22", "a23" },
                new string[] { "a", "e", "i", "o", "u" }
            };
            var c = new Wpfz.Ch03.C07Array4();
            Console.WriteLine(c.PrintArray(a));
        }
    }
}
