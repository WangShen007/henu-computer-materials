namespace ClientWinFormsExamples.ch04
{
    public partial class E0407Math : Form
    {
        public E0407Math()
        {
            InitializeComponent();
            var v = new MathDemo();
            label1.Text = v.R;
        }
    }
    public class MathDemo
    {
        public string R { get; private set; } = "";
        private readonly string space10 = new(' ', 10);
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
            R += $"PI的值：{Math.PI}{space10}" +
                 $"-5的绝对值：{r1}{space10}" +
                 $"45度的正弦值：{r2}， 余弦值：{r3}\n" +
                 $"{a}的{b}次方：{Math.Pow(a, b)}{space10}" +
                 $"{b}的平方根：{Math.Sqrt(b)}\n\n";
        }
        private void Demo2()
        {
            int i = 10, j = -5;
            double x = 1.3, y = 2.7;
            double r1 = Math.Ceiling(x);
            double r2 = Math.Floor(y);
            R += $"大于等于{x}的最小整数：{r1}， 小于等于{y}的最大整数：{r2}{space10}" +
                 $"{i}和{j}的较大者：{Math.Max(i, j)}， " +
                 $"{x}和{y}的较小者：{Math.Min(x, y)}\n\n";
        }

        private void Demo3()
        {
            double x1 = 1.3, x2 = 2.5, x3 = 3.5;
            R += "Round方法取整，按国际标准（四舍六入五取偶）：\n" +
                 $"Round({x1})={Math.Round(x1)}，Round({-x1})={Math.Round(-x1)}{space10}" +
                 $"Round({x2})={Math.Round(x2)}【注意结果是2，不是3】{space10}" +
                 $"Round({x3})={Math.Round(x3)}\n" +
                 "Round方法取整，按国内标准（四舍五入）：\n" +
                 $"Round({x1})={Math.Round(x1, 0, MidpointRounding.AwayFromZero)}{space10}" +
                 $"Round({x2})={Math.Round(x2, 0, MidpointRounding.AwayFromZero)}{space10}" +
                 $"Round({x3})={Math.Round(x3, 0, MidpointRounding.AwayFromZero)}\n\n";
            decimal x4 = 2.345m, x5 = 3.345m;
            R += "Round方法舍入（取两位小数），按国际标准（四舍六入五取偶）：\n" +
                 $"Math.Round({x4},2)={Math.Round(x4, 2)}{space10}" +
                 $"Math.Round({x5},2)={Math.Round(x5, 2)}\n\n" +
                 "Round方法舍入（取两位小数），按国内标准（四舍五入）：\n" +
                 $"Math.Round({x4},2,MidpointRounding.AwayFromZero)={Math.Round(x4, 2, MidpointRounding.AwayFromZero)}{space10}" +
                 $"Math.Round({x5},2,MidpointRounding.AwayFromZero)={Math.Round(x5, 2, MidpointRounding.AwayFromZero)}";
        }
    }
}
