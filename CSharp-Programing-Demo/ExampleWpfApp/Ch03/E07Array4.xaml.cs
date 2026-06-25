using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E07Array4 : Page
    {
        public E07Array4()
        {
            InitializeComponent();
            uc1.BtnConsole.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E07Array4");
            };
            uc1.BtnWpf.Click += delegate
            {
                string[][] a ={
                    new string[] { "a11", "a12" },
                    new string[] { "a21", "a22", "a23" },
                    new string[] { "a", "e", "i", "o", "u" }
                };
                var c = new Wpfz.Ch03.C07Array4();
                uc1.Result.Text = c.PrintArray(a);
            };
        }
    }
}
