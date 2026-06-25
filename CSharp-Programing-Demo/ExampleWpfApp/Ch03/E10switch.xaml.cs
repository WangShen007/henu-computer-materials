using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E10switch : Page
    {
        public E10switch()
        {
            InitializeComponent();
            grid1.Visibility = Visibility.Collapsed;
            btn1.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E10switch");
            };
            btn2.Click += delegate
            {
                grid1.Visibility = grid1.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            };
            btnOK.Click += delegate
            {
                if (int.TryParse(textBox1.Text, out int x) == false)
                {
                    textBlockResult.Text = "请确保输入的数据是整数！";
                    return;
                }
                var c = new Wpfz.Ch03.C10switch();
                textBlockResult.Text = "结果：" + c.GetResult(x);
            };
        }
    }
}
