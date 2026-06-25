using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E01 : Page
    {
        public E01()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E01");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C01();
                uc1.Result.Text = c.Result;
            };
        }
    }
}
