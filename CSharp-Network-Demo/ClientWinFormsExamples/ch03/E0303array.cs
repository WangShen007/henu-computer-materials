namespace ClientWinFormsExamples.ch03
{
    public partial class E0303array : Form
    {
        public E0303array()
        {
            InitializeComponent();
            this.Text = "一维数组的基本用法";
            int[] a = { 23, 64, 15, 72, 36 };
            string[] b = { "Java", "C#", "C++", "Python" };
            var s = "";
            s += $"初始值：{string.Join(",", a)}" + new string(' ',5);
            s += $"平均值：{a.Average()}" + new string(' ', 5);
            s += $"和：{a.Sum()}" + new string(' ', 5);
            s += $"最大值：{a.Max()}" + new string(' ', 5);
            s += $"最小值：{a.Min()}\n";
            s += ArraySortDemo(a);
            s += ArraySortDemo(b);
            label1.Text = s;
        }
        /// <summary>对整型数组排序并返回结果</summary>
        public static string ArraySortDemo(int[] a)
        {
            int[] b = new int[a.Length];
            Array.Copy(a, b, a.Length); //将数组a的值全部复制到数组b中
            var s = $"原始整数数组：{string.Join(",", a)}\n";
            Array.Reverse(a); //反转数组a的值，结果仍保存到a中
            s += $"反转后的值：{string.Join(",", a)}" + new string(' ', 5);
            Array.Sort(b); //将数组b升序排序，排序结果仍保存到b中
            s += $"升序排序后的值：{string.Join(",", b)}" + new string(' ', 5);
            Array.Reverse(b); //反转排序后的值，得到降序结果仍保存到b中
            s += $"降序排序后的值：{string.Join(",", b)}\n";
            return s;
        }
        /// <summary>对字符串数组排序</summary>
        public static string ArraySortDemo(string[] a)
        {
            var s = $"原始数组：{string.Join(",", a)}\n";
            Array.Sort(a);
            s += $"升序排序后的值：{string.Join(",", a)}" + new string(' ', 5);
            Array.Reverse(a);
            s += $"降序排序后的值：{string.Join(",", a)}\n";
            return s;
        }
    }
}
