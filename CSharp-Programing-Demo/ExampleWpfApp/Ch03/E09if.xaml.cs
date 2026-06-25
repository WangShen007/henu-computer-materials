using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch03
{
    public partial class E09if : Page
    {
        public E09if()
        {
            InitializeComponent();
            border1.Visibility = Visibility.Collapsed;
            btn1.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E09if");
            };
            btn2.Click += delegate
            {
                border1.Visibility = border1.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            };
            btnOK.Click += delegate
            {
                if(int.TryParse(textBox1.Text, out int x) == false)
                {
                    labelResult.Content = "请确保输入的数据是整数！";
                    return;
                }
                var c = new Wpfz.Ch03.C09if();
                labelResult.Content = "结果：" + c.Calculate(x);
            };
        }
    }
}
