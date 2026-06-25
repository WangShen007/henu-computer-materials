using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E14do_while : Page
    {
        public E14do_while()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E14do_while");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C14do_while();
                uc1.Result.Text = c.GetResult();
            };
        }
    }
}
