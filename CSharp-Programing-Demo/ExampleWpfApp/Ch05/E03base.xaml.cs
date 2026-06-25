using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E03base : Page
    {
        public E03base()
        {
            InitializeComponent();
            Loaded += delegate {
                string s = "";
                E03A v11 = new E03A(); v11.M1(); s += $"{v11.R}\n";
                E03A v12 = new E03A(12); v12.M1(); s += $"{v12.R}";
                uc1.tip.Text = "E03A";
                uc1.Result.Text = s;
                E03A v21 = new E03B(); v21.M1(); s = $"{v21.R}\n";
                E03A v22 = new E03B(22); v22.M1(); s += $"{v22.R}";
                uc2.tip.Text = "E03B";
                uc2.Result.Text = s;
                E03A v31 = new E03C(); v31.M1(); s = $"{v31.R}\n";
                E03A v32 = new E03C(32); v32.M1(); s += $"{v32.R}";
                uc3.tip.Text = "E03C";
                uc3.Result.Text = s;
            };
        }
    }
    public class E03A
    {
        public string R { get; set; } = "";
        public E03A() { R += "[A]"; }
        public E03A(int a)
        {
            R += $"[A({a})]";
        }
        public virtual string M1() { return "[A.M1()]"; }
    }
    public class E03B : E03A
    {
        public E03B() : base() { R += "[B]"; }
        public E03B(int a) : base(a)
        {
            R += $"[B({a})]";
        }
        public override string M1()
        {
            R += "[B.M1()]";
            return R + base.M1();
        }
    }
    public class E03C : E03B
    {
        public E03C()
        {
            R += "[C]";
        }
        public E03C(int a) : base(a)
        {
            R += $"[C({a})]";
        }
        public override string M1()
        {
            R += "[C.M1()]";
            return R + base.M1();
        }
    }
}
