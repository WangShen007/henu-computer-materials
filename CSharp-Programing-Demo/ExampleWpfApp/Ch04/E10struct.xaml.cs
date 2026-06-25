using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E10struct : Page
    {
        public E10struct()
        {
            InitializeComponent();
            var v = new StructDemo();
            uc.Result.Content = v.Result;
        }
    }
    public class StructDemo
    {
        private const int LEN = 3;
        private readonly string space = new string(' ', 2);
        public string Result { get; set; } = "";
        public StructDemo()
        {
            Demo1[] p1 = new Demo1[LEN];
            for (int i = 0; i < p1.Length; i++)
            {
                //必须创建对象
                p1[i] = new Demo1 { X = i, Y = i };
                Result += $"[{p1[i].X},{p1[i].Y}]{space}";
            }
            Result += "\n";

            Demo2[] p2 = new Demo2[LEN];
            for (int i = 0; i < p2.Length; i++)
            {
                //不需要创建对象
                p2[i].X = i + 10;
                p2[i].Y = i + 10;
                Result += $"[{p2[i].X},{p2[i].Y}]{space}";
            }
        }
    }
    public class Demo1
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public struct Demo2
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
