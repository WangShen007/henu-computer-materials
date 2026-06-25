using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpfz;
namespace ExampleWpfApp.Ch08
{
    public partial class Z08ProgressBar : Page
    {
        private IAsyncNotify asyncNotify = new DefaultAsynNotify();

        public Z08ProgressBar()
        {
            InitializeComponent();
            //进度条数据绑定
            pro1.DataContext = asyncNotify;
            //注册事件
            btnzSuccess.Click += BtnzSuccess_Click;
            btnzFail.Click += BtnzFail_Click;
            btnzReset.Click += BtnzReset_Click;
        }
        private async void BtnzSuccess_Click(object sender, RoutedEventArgs e)
        {
            asyncNotify.Start(100);
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    this.asyncNotify.Advance(1);
                    System.Threading.Thread.Sleep(50);
                }
                this.asyncNotify.IsSuccess = true;
            });
        }
        private async void BtnzFail_Click(object sender, RoutedEventArgs e)
        {
            asyncNotify.Start(100);
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    this.asyncNotify.Advance(1);
                    System.Threading.Thread.Sleep(50);
                    if (i >= 30)
                    {
                        this.asyncNotify.Cancel();
                        this.asyncNotify.IsSuccess = false;
                        break;
                    }
                }
            });
        }
        private void BtnzReset_Click(object sender, RoutedEventArgs e)
        {
            asyncNotify.Start(0);
        }
    }
}