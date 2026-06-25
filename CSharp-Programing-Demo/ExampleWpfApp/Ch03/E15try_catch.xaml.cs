using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E15try_chtch : Page
    {
        public E15try_chtch()
        {
            InitializeComponent();
            grid1.Visibility = Visibility.Collapsed;
            btn1.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E15try_catch");
            };
            btn2.Click += delegate
            {
                grid1.Visibility = grid1.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            };
            btnOK.Click += delegate
            {
                var c = new Wpfz.Ch03.C15try_catch();
                try
                {
                    var s = textBox1.Text.Split(',','，'); //英文逗号和中文逗号
                    result.Text = c.GetResult(s[0], s[1]);
                }
                catch
                {
                    result.Text = "输入不符合要求。";
                }
            };
        }
    }
}
