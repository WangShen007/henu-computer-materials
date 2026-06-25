namespace ClientConsoleExamples.ch02
{
    internal class E0202
    {
        public E0202()
        {
            int a = 1, b = 2, c = 3, a1 = 123, a2 = -123;
            double d1 = 1234.56, d2 = -1234.56;
            Console.WriteLine($"a={a}, b={b}, c={c}");
            Console.WriteLine($"a1={a1}, a2={a2}, d1={d1}, d2={d2}");
            Console.WriteLine($"a+b+c={a + b + c}");
            var s = $"a1={a1:d5}, a2={a2:d5}, d1={d1:f4}, d2={d2:f4}";
            Console.WriteLine(s);
        }
    }
}


//public E0202()
//{
//    Console.Write("请输入用空格分隔的n个数（例如12 15 24）：");
//    string? s = Console.ReadLine();
//    if(s==null)
//    {
//        Console.WriteLine("未按要求输入，求和无意义。按任意键返回...");
//        Console.ReadKey();
//        return;
//    }
//    string[] a = s.Split(' '); //将空格分隔的字符串转化为整型数组
//    if (a.Length < 2)
//    {
//        Console.WriteLine("输入的数太少，求和无意义。按任意键返回...");
//        Console.ReadKey();
//        return;
//    }
//    int[] b = new int[a.Length];
//    for (int i = 0; i < a.Length; i++)
//    {
//        if (int.TryParse(a[i], out int n))
//        {
//            b[i] = n;
//        }
//        else
//        {
//            b[i] = 0;
//        }
//    }
//    int sum = 0;
//    for (int i = 0; i < a.Length; i++)
//    {
//        sum += b[i];
//    }
//    Console.WriteLine($"{string.Join("+", b)}={sum}");
//}

