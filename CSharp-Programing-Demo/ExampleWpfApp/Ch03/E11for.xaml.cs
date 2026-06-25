using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E11for : Page
    {
        public E11for()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E11for");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C11for();
                uc1.Result.Text = c.GetResult();
            };
        }
    }
}
