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

namespace FuLuBWpfApp.rateManage
{
    /// <summary>
    /// ratePage.xaml 的交互逻辑
    /// </summary>
    public partial class ratePage : Page
    {
        BankEntities context = new BankEntities();
        public ratePage()
        {
            InitializeComponent();

            InitEvents();

            var q = from t in context.RateInfo select t;
            dataGrid1.ItemsSource = q.ToList();
        }
        private void InitEvents()
        {
            //保存
            btnSave.Click += delegate
            {
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "保存失败");
                }
            };
            Unloaded += delegate
            {
                context.Dispose();
            };
        }
    }
}
