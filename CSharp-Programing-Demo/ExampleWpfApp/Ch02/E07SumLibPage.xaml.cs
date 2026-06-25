using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E07SumLibPage : Page
    {
        public E07SumLibPage()
        {
            InitializeComponent();
            btnOK.Click += delegate
            {
                string[] a = txt1.Text.Split(' ');
                int len = a.Length;
                if (len < 2) MessageBox.Show("输入的数不能少于2个", "警告");
                int[] b = new int[len];
                for (int i = 0; i < len; i++)
                {
                    if (int.TryParse(a[i], out int n))
                    {
                        b[i] = n;
                    }
                    else
                    {
                        result.Content = "输入有错";
                        return;
                    }
                }
                int x = Wpfz.Ch02.LibDemo.Sum(b);
                result.Content = $"{string.Join(" + ", b)} = {x}";
            };
            btnClear.Click += delegate
            {
                result.Content = "";
            };
        }
    }
}
