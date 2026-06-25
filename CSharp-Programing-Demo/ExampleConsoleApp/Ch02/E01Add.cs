using System;
namespace ExampleConsoleApp.Ch02
{
    class E01Add
    {
        public E01Add()
        {
            Console.Write("请输入两个数（空格分隔）：");
            string s = Console.ReadLine();
            string[] sArray = s.Split(' ');
            string r = $"两个数的和为：{int.Parse(sArray[0]) + int.Parse(sArray[1])}";
            Console.WriteLine(r);
        }
    }
}
