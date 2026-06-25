using System;
namespace ExampleConsoleApp.Ch02
{
    class E02Sum
    {
        public E02Sum()
        {
            int[] a = GetInputData();
            if (a.Length == 1) return;
            //实现方式1-直接计算
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            Console.WriteLine("方式1（直接计算）：\t{0}={1}", string.Join("+", a), sum);
            //实现方式2-调用DLL实现
            Console.WriteLine("方式2（调用DLL实现）：\t{0}={1}",
                string.Join("+", a), Wpfz.Ch02.LibDemo.Sum(a));
        }
        private int[] GetInputData()
        {
            Console.Write("请输入用空格分隔的n个数（例如12 15 24）：");
            string s = Console.ReadLine();
            if (s.Length < 2)
            {
                Program.ShowWarn("输入的数太少，求和无意义。");
            }
            string[] a = s.Split(' '); //将空格分隔的字符串转化为整型数组
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (int.TryParse(a[i], out int n)) b[i] = n;
            }
            return b;
        }
    }
}
