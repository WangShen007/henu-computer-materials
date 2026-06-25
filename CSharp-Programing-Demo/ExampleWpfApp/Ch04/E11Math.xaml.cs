using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E11Math : Page
    {
        public E11Math()
        {
            InitializeComponent();
            var v = new MathDemo();
            uc.Result.Content = v.R;
        }
    }
    public class MathDemo
    {
        public string R { get; set; } = "";
        public MathDemo()
        {
            Demo1();
            Demo2();
            Demo3();
        }
        private void Demo1()
        {
            int x = -5;
            double y = 45.0, a = 2.0, b = 5.0;
            int r1 = Math.Abs(x);     //求绝对值
            double r2 = Math.Sin(y);  //求指定角度的正弦值
            double r3 = Math.Cos(y);  //求指定角度的余弦值
            R += $"PI的值：{Math.PI}\n" +
                 $"-5的绝对值：{r1}\n" +
                 $"45度的正弦值：{r2}，余弦值：{r3}\n" +
                 $"{a}的{b}次方：{Math.Pow(a, b)}\n" +
                 $"{b}的平方根：{Math.Sqrt(b)}\n\n";
        }
        private void Demo2()
        {
            int i = 10, j = -5;
            double x = 1.3, y = 2.7;
            double r1 = Math.Ceiling(x);
            double r2 = Math.Floor(y);
            R += $"大于等于{x}的最小整数：{r1}，小于等于{y}的最大整数：{r2}\n" +
                 $"{i}和{j}的较大者：{Math.Max(i, j)}\n" +
                 $"{x}和{y}的较小者：{Math.Min(x, y)}\n";
        }

        private void Demo3()
        {
            double x1 = 1.3, x2 = 2.5, x3 = 3.5;
            R += "Round方法取整，按国际标准（四舍六入五取偶）：\n" +
                 $"Round({x1})={Math.Round(x1)}，Round({-x1})={Math.Round(-x1)}\n" +
                 $"Round({x2})={Math.Round(x2)}【注意结果是2，不是3】" +
                 $"Round({x3})={Math.Round(x3)}" +
                 "Round方法取整，按国内标准（四舍五入）：\n" +
                 $"Round({x1})={Math.Round(x1, 0, MidpointRounding.AwayFromZero)}\n" +
                 $"Round({x2})={Math.Round(x2, 0, MidpointRounding.AwayFromZero)}" +
                 $"Round({x3})={Math.Round(x3, 0, MidpointRounding.AwayFromZero)}";
            double x4 = 2.345, x5 = 3.345;
            R += "Round方法舍入（取两位小数），按国际标准（四舍六入五取偶）：\n" +
                 $"x4={Math.Round(x4, 2)}\n" +
                 $"x5={Math.Round(x5, 2)}\n" +
                 "Round方法舍入（取两位小数），按国内标准（四舍五入）：\n" +
                 $"x4={Math.Round(x4, 2, MidpointRounding.AwayFromZero)}\n" +
                 $"x5={Math.Round(x2, 2, MidpointRounding.AwayFromZero)}\n";
        }
    }
}
