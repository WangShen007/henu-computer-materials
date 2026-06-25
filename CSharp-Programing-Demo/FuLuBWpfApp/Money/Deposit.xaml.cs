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
using FuLuBWpfApp.Common;

namespace FuLuBWpfApp.Money
{
    /// <summary>
    /// Deposit.xaml 的交互逻辑
    /// </summary>
    public partial class Deposit : Page
    {
        public Deposit()
        {
            InitializeComponent();
            //存款
            btnOk.Click += delegate
            {
                Custom custom = DataOperation.GetCustom(this.txtAccount.Text);
                if (custom == null)
                {
                    MessageBox.Show("帐号不存在！");
                    return;
                }
                custom.MoneyInfo.accountNo = txtAccount.Text;
                custom.Diposit("存款", double.Parse(this.txtmount.Text));
                OperateRecord page = new OperateRecord();
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(page);
            };
            //取消存款
            btnCancel.Click += delegate
            {
                OperateRecord page = new OperateRecord();
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(page);
            };
        }
    }
}
