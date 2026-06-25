namespace ClientWinFormsExamples.ch04
{
    public partial class E0404Method : Form
    {
        public E0404Method()
        {
            InitializeComponent();
            var c = new C0404();
            label1.Text = c.R;
        }
    }
    internal class C0404
    {
        public string R { get; } = string.Empty;
        public C0404()
        {
            //方法1-值参
            int a = 20, b = 30, c = 0;
            var v1 = Add(a);
            var v2 = Add(a, b);
            R += $"方法1(值参)：a={a}，b={b}，c={c}，v1={v1}，v2={v2}";
            //方法2-ref
            int x = 0;
            R += $"\n方法2(ref)：调用前x的值为{x}，";
            AddOne(ref x);
            R += $"调用后x的值为{x}";
            //方法3-out
            int x1 = 13, y1 = 3;
            Div(x1, y1, out int r1, out int r2);
            R += $"\n方法3(out)：x1={x1}，y1={y1}，商={r1},余数={r2}";
            //方法4-params
            string s1 = $"1、2、3、5的平均值为{Average(1, 2, 3, 5)}";
            string s2 = $"4、5、6的平均值为{Average(4, 5, 6)}";
            string s3 = $"元素个数为零时结果是否为有效值：{Average().HasValue}";
            R += $"\n方法4(params)：\n{s1}\n{s2}\n{s3}";
        }
        /// <summary>方法(1)-值参</summary>
        public int Add(int x, int y = 10)
        {
            return x + y;
        }
        /// <summary>方法(2)-ref关键字</summary>
        public void AddOne(ref int a)
        {
            a++;
        }
        /// <summary>方法(3)-out关键字</summary>
        public void Div(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }
        /// <summary>方法(4)-params关键字</summary>
        public double? Average(params int[] v)
        {
            if (v.Length == 0)
            {
                return null;
            }
            double total = 0;
            for (int i = 0; i < v.Length; i++) total += v[i];
            return total / v.Length;
        }
    }
}
