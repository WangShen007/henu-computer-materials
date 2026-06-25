using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E05Lambda : Page
    {
        public E05Lambda()
        {
            InitializeComponent();
            Loaded += delegate
            {
                //Lambda表达式一般用于仅有一条语句的情况
                string Demo1() => "hello";
                int Demo2(int x, int y) => x + y;
                string s = $"Demo1：{Demo1()}\tDemo2：{Demo2(13, 14)}";
                //Demo3：如果是少量语句，可以用本地函数实现
                string Demo3()
                {
                    return "hello";
                };
                //Demo4：如果语句较多，可以用单独的方法实现
                int z = Demo4(13, 14);
                s += $"\nDemo3:{Demo3()}\tDemo4:{z}";
                uc.Result.Content = s;
            };
        }
        private int Demo4(int x,int y)
        {
            return x + y;
        }
    }
}
