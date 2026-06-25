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

namespace FuLuBWpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FuLuBMainWindow : Window
    {
        public static FuLuBMainWindow Instance;
        public FuLuBMainWindow()
        {
            InitializeComponent();
            Instance = this;
            SourceInitialized += delegate
            {
                //初始化测试数据，演示用（确保测试数据可预测，如果不希望每次都初始化，注释掉此句即可）
                Common.Helps.InitTestData();
                //默认显示的页面
                this.frame1.Source = new Uri("money/OperateRecord.xaml", UriKind.Relative);
                //启动登录窗体
                LoginWindow login = new LoginWindow();
                login.ShowDialog();
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button item)
            {
                frame1.Source = new Uri(item.Tag.ToString(), UriKind.Relative);
            }
        }
    }
}
