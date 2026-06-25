using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E08convert : Page
    {
        public E08convert()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E08convert");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C08TypeConvert();
                uc1.Result.Text = c.Result;
            };
        }
    }
}
