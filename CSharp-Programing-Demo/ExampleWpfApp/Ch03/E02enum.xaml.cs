using Wpfz.Ch03;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E02enum : Page
    {
        public E02enum()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E02enum");
            };
            uc1.BtnWpf.Click += delegate
            {
                MyColor myColor = MyColor.Black;
                var c = new C02enum();
                uc1.Result.Text = c.GetResult(myColor);
            };
        }
    }
}
