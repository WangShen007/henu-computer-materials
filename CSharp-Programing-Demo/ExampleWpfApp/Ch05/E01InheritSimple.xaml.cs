using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E01InheritSimple : Page
    {
        public E01InheritSimple()
        {
            InitializeComponent();
            Loaded += delegate
            {
                var r = "";
                E01A a = new E01A(); r += a.M1();
                E01B b = new E01B(); r += b.M2();
                uc.Result.Text = r;
            };
        }
    }
    public class E01A
    {
        public string M1() { return $"A.M1\t"; }
    }
    public class E01B : E01A
    {
        public string M2() { return "A.M2\t"; }
    }
}
