using System;
using System.IO;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch06
{
    public partial class E01Environment : Page
    {
        public E01Environment()
        {
            InitializeComponent();
            Loaded += delegate {
                EnvironmentDemo();
                DriveInfoDemo();
            };
        }
        private void EnvironmentDemo()
        {
            string[] drives = Environment.GetLogicalDrives();
            uc1.Result.Text = $"本机逻辑驱动器：{string.Join(", ", drives)}" +
                $"\n操作系统版本：{Environment.OSVersion}" +
                $"\n是否为64位系统：{Environment.Is64BitOperatingSystem}" +
                $"\n计算机名：{Environment.MachineName}" +
                $"\n处理器个数：{Environment.ProcessorCount}" +
                $"\n系统启动后经过的秒数：{Environment.TickCount / 1000}" +
                $"\n系统登录用户名：{Environment.UserName}";
        }
        private void DriveInfoDemo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                uc1.Result.Text += $"\n\n驱动器 {d.Name}，类型：{d.DriveType}";
                double x = 1024.0;
                if (d.IsReady)
                {
                    var y = x * x * x;
                    uc1.Result.Text += $"，格式：{d.DriveFormat}" +
                        $"，总容量：{d.TotalSize / y:f2}GB" +
                        $"，空闲容量：{d.TotalFreeSpace / y:f2}GB";
                }
            }
        }
    }
}
