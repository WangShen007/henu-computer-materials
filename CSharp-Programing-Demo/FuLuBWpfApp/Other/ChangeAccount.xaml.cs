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

namespace FuLuBWpfApp.other
{
    /// <summary>
    /// ChangeEmployee.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeEmployee : Page
    {
        BankEntities context = new BankEntities();
        public ChangeEmployee()
        {
            InitializeComponent();

            //更改密码
            btnOk.Click += delegate
            {
                var query = from t in context.AccountInfo
                            where t.accountNo == this.txtAccount.Text
                            select t;
                if (query.Count() > 0)
                {
                    var q = query.First();
                    q.accountPass = this.txtNewPass.Password;
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更改密码成功！");
                    }
                    catch
                    {
                        MessageBox.Show("更改密码失败！");
                    }
                }
            };
            //取消更改
            btnCancel.Click += delegate
            {
                txtNewPass.Clear();
                txtPassConf.Clear();
            };
        }
    }
}
