using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E04Page : Page
    {
        public E04Page()
        {
            InitializeComponent();
            //Wingdings图形字符（Unicode十六进制编码，004A：笑脸，004B:无表情，004C：哭脸）
            txt.Text = "\u004A\u004B\u004C";
            btnWindow.Click += delegate
            {
                var w = new E04_Window
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                w.ShowDialog();
            };
        }
    }
}
