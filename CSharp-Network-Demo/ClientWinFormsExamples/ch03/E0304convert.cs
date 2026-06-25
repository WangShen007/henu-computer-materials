namespace ClientWinFormsExamples.ch03
{
    public partial class E0304convert : Form
    {
        public E0304convert()
        {
            InitializeComponent();
            this.Text = "类型转换的基本用法";
            label1.Text = ShowDemo();
        }
        private string ShowDemo()
        {
            string result = string.Empty;
            result += "值类型之间的转换：\n";
            int i1 = 12345;
            long r1 = 12345678L;
            long r2 = i1;         //隐式转换
            int i2 = (int)r1;     //显式转换
            try
            {
                int i3 = Convert.ToInt32(r1); //利用Convert类实现转换
                result += $"i1={i1}, r1={r1}, i3={i3}\n\n";
            }
            catch (Exception ex)
            {
                result += ex.Message + "\n\n";
            }
            result += "引用类型之间的转换：\n";
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            c1 = c2;              //隐式转换
            var c3 = (Class1)c2;  //显式转换
            var c4 = c2 as Class1;
            var c5 = c1 as Class2;
            result += $"c1是Class1吗：{((c1 is Class1) ? "是" : "否")}\n";
            result += $"c1的类型是{c1.GetType()}{new string(' ', 8)}";
            result += $"c3的类型是{c3.GetType()}\n";
            result += $"c4={c4}{new string(' ', 8)}c5={c5}\n\n";
            result += "Parse、TryParse方法：\n";
            string s1 = "12";
            int n1 = int.Parse(s1);
            string s2 = "12.3";
            double n2 = double.Parse(s2);
            result += $"s1={s1}， n1={n1}{new string(' ', 8)}";
            result += $"s2={s2}，n2={n2}{new string(' ', 8)}";
            if (int.TryParse(s1, out int n3))
                result += $"n3={n3}{new string(' ', 8)}";
            if (double.TryParse(s1, out double n4))
                result += $"n4={n4}\n\n";
            result += "Jion、Split方法：";
            int[] a = { 11, 12, 13 };
            string str1 = string.Join(",", a);
            string s = "21,22,23";
            string[] b = s.Split(',');
            result += $"a=[{str1}]\tb=[{s}]\n\n";
            result += "char与int之间的转换：";
            char ch1 = 'A';
            int x1 = ch1;  //隐式转换
            int x2 = 49;
            char ch2 = (char)x2;  //显式转换
            result += $"ch1={ch1}，x1={x1}，x2={x2}，ch2={ch2}";
            return result;
        }
    }
    public class Class1 { }
    public class Class2 : Class1 { }
}
