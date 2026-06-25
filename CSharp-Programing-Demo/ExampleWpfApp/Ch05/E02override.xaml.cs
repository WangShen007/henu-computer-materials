using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E02override : Page
    {
        public E02override()
        {
            InitializeComponent();
            Loaded += delegate
            {
                string s = "";
                E02A a1 = new E02B(); a1.M1(); a1.M2(); a1.M3(); s += $"{a1.R}\n";
                E02A a2 = new E02C(); a2.M1(); a2.M2(); a2.M3(); s += $"{a2.R}\n";
                uc.Result.Text = s;
            };
        }
    }
    public abstract class E02A
    {
        public string R { get; set; } = "";
        public void M1() { R += "A.M1\t"; }
        public abstract void M2();
        public virtual void M3() { R += "A.M3\t"; }
    }
    public class E02B : E02A
    {
        public new void M1() { R += "B.M1\t"; }
        public override void M2() { R += "B.M2\t"; }
        public override void M3() { R += "B.M3\t"; }
    }
    public class E02C : E02B
    {
        public new void M1() { R += "C.M1\t"; }
        public override void M2() { R += "C.M2\t"; }
        public new void M3() { R += "C.M3\t"; }
    }
}
