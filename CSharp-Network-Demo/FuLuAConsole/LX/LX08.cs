namespace FuLuAConsole.LX
{
    internal class LX08
    {
        public LX08()
        {
            //（3）
            //"_"表示使用丢弃
            _ = new A();
            _ = new A("This is a string");
            _ = new A[5];
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
