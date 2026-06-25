using System;
namespace ExampleConsoleApp.Ch02
{
    class E03DataOutput
    {
        public E03DataOutput()
        {
            int a = 1, b = 2, c = 3;
            Console.WriteLine("用法1：a={0},b={1},c={2}", a, b, c);
            Console.WriteLine("用法2：b={1},c={2},a={0}", a, b, c);
            Console.WriteLine($"用法3：a={a},b={b},c={c}");
            Console.WriteLine($"用法4：{a}+{b}+{c}={a + b + c}");
            int a1 = 123, a2 = -123;
            double d1 = 1234.56, d2 = -1234.56;
            Console.WriteLine($"a1{a1},a2={a2},d1={d1},d2={d2}");
            var s1 = string.Format("用法5：a1={0:d5},a2={1:d5},d1={2:f2},d2={3:f2}", a1, a2, d1, d2);
            var s2 = $"用法6：a1={a1:d5},a2={a2:d5},d1={d1:f2},d2={d2:f2}";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
