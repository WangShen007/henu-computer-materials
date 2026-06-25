using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpfz;
namespace ExampleWpfApp.Ch08
{
    public partial class Z01WindowzMessageBoxz : Page
    {
        public Z01WindowzMessageBoxz()
        {
            InitializeComponent();
            InitEvents();
        }
        private void InitEvents()
        {
            btnShowWindowz.Click += (s, e) =>
            {
                Windowz w = new Windowz
                {
                    Title = "这是窗口标题",
                    Content = new TextBlock
                    {
                        Text = "这是窗口内容",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Foreground = Brushes.Black,
                        FontSize = 36
                    }
                };
                w.ShowDialog();
            };

            btnShowWaitingBox.Click += (s, e) =>
            {
                WaitingBox.Show(() => System.Threading.Thread.Sleep(3000), "正在加载，请稍后...");
                MessageBoxz.ShowInfo("加载完毕!");
            };

            btnInfo1.Click += (s, e) =>
            {
                MessageBox.Show("这是提示信息。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            };
            btnInfo2.Click += (s, e) => MessageBoxz.ShowInfo("这是提示信息。");

            btnError1.Click += (s, e) =>
            {
                MessageBox.Show("这是出错信息。", "出错了", MessageBoxButton.OK, MessageBoxImage.Error);
            };
            btnError2.Click += (s, e) => MessageBoxz.ShowError("这是出错信息。");

            btnWarning1.Click += (s, e) =>
            {
                MessageBox.Show("这是警告信息。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            };
            btnWarning2.Click += (s, e) => MessageBoxz.ShowWarning("这是警告信息！");

            btnQuestion1.Click += (s, e) =>
            {
                var r = MessageBox.Show("这是问题嘛。", "疑问", MessageBoxButton.YesNo, MessageBoxImage.Question);
                MessageBox.Show(r.ToString());
            };
            btnQuestion2.Click += (s, e) =>
            {
                var r = MessageBoxz.ShowQuestion("这是问题嘛？");
                MessageBoxz.ShowInfo(r.ToString());
            };

            btnSuccess1.Click += (s, e) =>
            {
                MessageBox.Show("哈哈哈哈哈，操作成功了！", "啦啦啦", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            };
            btnSuccess2.Click += (s, e) => MessageBoxz.ShowSuccess("哈哈哈哈哈，操作成功了！", "啦啦啦");
        }
    }
}
