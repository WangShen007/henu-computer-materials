using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A08
{
    /// <summary>
    /// PageA0801.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0801 : Page
    {
        public PageA0801()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 1;  //默认一般用户

            btnOK.Click += delegate
            {
                bool isSuccess = false;
                //注意：此处仅仅是为了练习，实际应用中应该将密码保存到数据库中并加密。
                if (comboBox1.SelectedIndex == 0)
                {
                    if (userName.Text.Length > 0 && password.Password == "123abc")
                    {
                        isSuccess = true;
                    }
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    if (userName.Text.Length > 0 && password.Password == "abcabc")
                    {
                        isSuccess = true;
                    }
                }
                if(isSuccess)
                {
                    MessageBox.Show("验证成功！", "恭喜", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确！", "验证失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };
            btnCancel.Click += delegate
            {
                Application.Current.Shutdown();
            };
        }
    }
}
