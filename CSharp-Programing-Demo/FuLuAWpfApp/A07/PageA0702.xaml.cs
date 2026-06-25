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

namespace FuLuAWpfApp.A07
{
    /// <summary>
    /// PageA0702.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0702 : Page
    {
        public PageA0702()
        {
            InitializeComponent();
            using (var c = new A07DbEntities())
            {
                var q = from t in c.MyTable1 select t;
                if (q.Count() == 0)
                {
                    c.MyTable1.Add(new MyTable1 { 学号 = 19001001, 姓名 = "张三雨", 性别 = "男", 专业 = "软件工程", 宿舍号 = "1-202" });
                    c.MyTable1.Add(new MyTable1 { 学号 = 19001002, 姓名 = "李四平", 性别 = "男", 专业 = "网络工程", 宿舍号 = "1-203" });
                    c.SaveChanges();
                    q = from t in c.MyTable1 select t;
                }
                dataGrid1.ItemsSource = q.ToList();
            }
        }
    }
}
