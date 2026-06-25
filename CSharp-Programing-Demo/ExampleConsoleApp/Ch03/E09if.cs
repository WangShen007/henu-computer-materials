using System;
namespace ExampleConsoleApp.Ch03
{
    class E09if
    {
        public E09if()
        {
            GetReslt();
        }
        public void GetReslt()
        {
            Console.Write("请输入x的值：");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int x) == false)
            {
                Console.WriteLine("请确保输入的数据是整数！按任意键继续...");
                Console.ReadKey();
            }
            var c = new Wpfz.Ch03.C09if();
            Console.WriteLine($"结果为：{c.Calculate(x)}");
        }
    }
}
