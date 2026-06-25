using System;
namespace ExampleConsoleApp.Ch03
{
    public class E15try_catch
    {
        public E15try_catch()
        {
            var c = new Wpfz.Ch03.C15try_catch();
            Console.Write("请输入x和y的值(逗号分隔)：");
            try
            {
                var s = Console.ReadLine().Split(',','，');
                Console.WriteLine(c.GetResult(s[0], s[1]));
            }
            catch
            {
                Console.WriteLine("输入不符合要求。");
            }
        }
    }
}
