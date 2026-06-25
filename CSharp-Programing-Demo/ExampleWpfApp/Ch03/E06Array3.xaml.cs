using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E06Array3 : Page
    {
        public E06Array3()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E06Array3");
            };
            uc1.BtnWpf.Click += delegate
            {
                var c = new Wpfz.Ch03.C06Array3();
                uc1.Result.Text = c.GetArray();
            };
        }
    }
}
