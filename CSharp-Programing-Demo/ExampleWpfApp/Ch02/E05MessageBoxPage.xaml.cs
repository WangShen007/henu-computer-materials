using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E05MessageBoxPage : Page
    {
        public E05MessageBoxPage()
        {
            InitializeComponent();
            InitOthers();
        }
        private void InitOthers()
        {
            //单击【用法1】按钮引发的事件
            btn1.Click += delegate
            {
                txtResult.Text = "";
                MessageBox.Show("OK");
            };
            //单击【用法2】按钮引发的事件
            btn2.Click += (s, e) =>
            {
                txtResult.Text = "";
                MessageBox.Show("OK", "Hello", MessageBoxButton.OK, MessageBoxImage.Information);
            };
            //单击【用法3】按钮引发的事件
            btn3.Click += (s, e) =>
            {
                var r = MessageBox.Show("是否保存数据？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (r == MessageBoxResult.OK)
                {
                    txtResult.Text = "【用法3】你选择了“确定”";
                }
                else
                {
                    txtResult.Text = "【用法3】你选择了“取消”";
                }
            };
            //单击【用法4】按钮引发的事件
            btn4.Click += (s, e) =>
            {
                var r = MessageBox.Show("保存数据吗？", "提示", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                if (r == MessageBoxResult.Yes)
                {
                    txtResult.Text = "【用法4】你选择了“是”";
                }
                else if (r == MessageBoxResult.No)
                {
                    txtResult.Text = "【用法4】你选择了“否”";
                }
                else
                {
                    txtResult.Text = "【用法4】你选择了“取消”";
                }
            };
            //单击【结束程序】按钮引发的事件
            btn5.Click += (s, e) =>
            {
                txtResult.Text = "";
                var r = MessageBox.Show("退出应用程序吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (r == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }
            };
        }
    }
}
