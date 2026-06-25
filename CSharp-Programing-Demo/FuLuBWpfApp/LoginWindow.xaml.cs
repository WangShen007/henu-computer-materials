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
using System.Windows.Shapes;

namespace FuLuBWpfApp
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            this.SourceInitialized += delegate
            {
                using (var c = new BankEntities())
                {
                    //将操作员账户表中的账号信息显示到此处
                    var q = from t in c.LoginInfo select t.Bno;
                    combox.ItemsSource = q.ToList();
                }
                combox.SelectedIndex = 0;
                //操作员初始密码（应建议操作员登录后尽快更改密码，此为密码复位后的默认初始密码）
                pass.Password = "123456";
            };
            btnLogin.Click += delegate
            {
                using (var c = new BankEntities())
                {
                    var query = from t in c.LoginInfo
                                where t.Bno == combox.Text && t.Password == pass.Password
                                select t;
                    if (query.Count() > 0)
                    {
                        var q = query.First();

                        var userName = Common.DataOperation.GetOperateName(q.Bno);
                        FuLuBMainWindow.Instance.Title += $"{new string(' ', 10)}操作员：{userName}";

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                        pass.Clear();
                        pass.Focus();
                    }
                }
            };
            btnCancel.Click += delegate
            {
                Application.Current.Shutdown();
            };
        }
    }
}
