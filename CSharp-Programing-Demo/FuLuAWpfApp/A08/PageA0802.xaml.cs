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

namespace FuLuAWpfApp.A08
{
    /// <summary>
    /// PageA0802.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0802 : Page
    {

        Random r = new Random();
        byte[] rgb = new byte[3];
        int[] fontSizeArray = { 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 68, 72 };
        int fontSizeIndex = 0;

        public PageA0802()
        {
            InitializeComponent();

            //（1）
            btn1.IsEnabled = true;  //btn1：增大字体
            btn2.IsEnabled = false; //btn2：减小字体
            ShowState();

            //（2）
            btn1.Click += delegate
            {
                fontSizeIndex++;
                ShowState();
                btn2.IsEnabled = true;
                if (fontSizeIndex == fontSizeArray.Length - 1)
                {

                    btn1.IsEnabled = false;
                }
            };
            btn2.Click += delegate
            {
                fontSizeIndex--;
                ShowState();
                btn1.IsEnabled = true;
                if (fontSizeIndex == 0)
                {
                    btn2.IsEnabled = false;
                }
            };
            btn3.Click += delegate
            {
                rgb[0] = (byte)r.Next(-1, 255);
                rgb[1] = (byte)r.Next(-1, 255);
                rgb[2] = (byte)r.Next(-1, 255);
                Color color = Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
                txt.Foreground = new SolidColorBrush(color);
            };
        }
        private void ShowState()
        {
            txt.FontSize = fontSizeArray[fontSizeIndex];
            tip.Text = $"FontSize={txt.FontSize:f1}, RGB={rgb[0]:x2}{rgb[1]:x2}{rgb[2]:x2}";
        }
    }
}
