using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E06 : Page
    {
        public E06()
        {
            InitializeComponent();
            checkBoxShowPwd1.Click += delegate
            {
                if (checkBoxShowPwd1.IsChecked == true)
                {
                    pwd.Visibility = Visibility.Collapsed;
                    pwd1.Visibility = Visibility.Visible;
                }
                else
                {
                    pwd.Visibility = Visibility.Visible;
                    pwd1.Visibility = Visibility.Collapsed;
                }
            };
            pwd.PasswordChanged += (s, e) =>
            {
                if (checkBoxShowPwd1.IsChecked == false)
                {
                    pwd1.Text = pwd.Password;
                }
            };
            pwd1.TextChanged += (s, e) =>
            {
                if (checkBoxShowPwd1.IsChecked == true)
                {
                    pwd.Password = pwd1.Text;
                }
            };
            pwd.Password = "12345";
            btnOK.Click += delegate
            {
                if (!int.TryParse(txt1.Text, out int t1)
                    || !int.TryParse(txt2.Text, out int t2))
                {
                    result.Content = "输入有错无法计算";
                    return;
                }
                result.Content = t1 + t2;
            };
            btnClear.Click += (s, e) => { result.Content = ""; };
        }
    }
}
