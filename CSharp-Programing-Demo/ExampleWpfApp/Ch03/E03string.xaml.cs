using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E03string : Page
    {
        public E03string()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E03string");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C03string();
                uc1.Result.Text = c.GetResult();
            };
        }
    }
}
