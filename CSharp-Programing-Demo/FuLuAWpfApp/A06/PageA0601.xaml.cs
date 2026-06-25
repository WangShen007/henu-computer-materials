using System;
using System.Collections.Generic;
using System.IO;
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

namespace FuLuAWpfApp.A06
{
    /// <summary>
    /// PageA0601.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0601 : Page
    {
        public PageA0601()
        {
            InitializeComponent();
            Loaded += delegate
            {
                //获取FuLuAWpfApp.exe文件的完整路径
                string file = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //得到目录位置
                string path = System.IO.Path.GetDirectoryName(file) + @"\A0601";
                TextBlock1.Text = $"目录位置：{path}";
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        TextBlock1.Text += "\n创建该目录成功。";
                    }
                    else
                    {
                        TextBlock1.Text += "\n该目录已存在。";
                    }
                }
                catch (Exception e)
                {
                    TextBlock1.Text += $"\n创建该目录失败: {e.Message}";
                }
            };
        }
    }
}
