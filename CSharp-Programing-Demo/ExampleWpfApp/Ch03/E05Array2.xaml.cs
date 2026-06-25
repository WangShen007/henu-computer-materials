using Wpfz.Ch03;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E05Array2 : Page
    {
        public E05Array2()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E05Array2");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new C05Array2();
                int[] a = { 23, 64, 15, 72, 36 };
                var s = $"{c.ArrayDemo2(a)}\n";
                string[] b = { "C++", "C#", "Java", "Pathon" };
                s += c.ArrayDemo2(b);
                uc1.Result.Text = s;
            };
        }
    }
}

