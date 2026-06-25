using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E04construct : Page
    {
        public E04construct()
        {
            InitializeComponent();
            Loaded += delegate {
                string s = "";
                E04A v1 = new E04A(); s += $"{v1.R}\n";
                E04A v2 = new E04B(); s += $"{v2.R}\n";
                E04A v3 = new E04C(); s += $"{v3.R}";
                uc.Result.Text = s;
            };
        }
    }
    public class E04A
    {
        public string R { get; set; } = "";
        public E04A() { R += "1A"; }
    }
    public class E04B : E04A
    {
        public E04B() { R += "2B"; }
    }
    public class E04C : E04B
    {
        public E04C()
        {
            R += "3C";
        }
    }
}
