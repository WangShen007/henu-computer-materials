using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E13while : Page
    {
        public E13while()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E13while");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C13while();
                uc1.Result.Text = c.GetResult();
            };
        }
    }
}
