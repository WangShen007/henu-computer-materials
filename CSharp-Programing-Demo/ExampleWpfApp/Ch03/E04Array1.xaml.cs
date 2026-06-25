using Wpfz.Ch03;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E04Array1 : Page
    {
        public E04Array1()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E04Array1");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new C04Array1();
                int[] a = { 10, 20, 4, 8 };
                uc1.Result.Text = c.ArrayDemo1(a);
            };
        }
    }
}
