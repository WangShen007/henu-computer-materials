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
using System.Windows.Threading;

namespace FuLuAWpfApp.A04
{
    /// <summary>
    /// PageA0403.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0403 : Page
    {
        public PageA0403()
        {
            InitializeComponent();
            labelResult.Content = "";
            oldFontSize = labelResult.FontSize;
            newFontSize = oldFontSize * 2;
            timer1.Tick += delegate
            {
                if (isIntRandom)
                {
                    int r = RandomHelp.GetIntRandomNumber(min, max);
                    labelResult.Content = r.ToString();
                }
                else
                {
                    double r = RandomHelp.GetDoubleRandomNumber(min, max);
                    labelResult.Content = r.ToString();
                }
            };
            btnStart.Click += delegate
            {
                InitParameters();
                SetState(true);
                timer1.Start();
            };
            btnStop.Click += delegate
            {
                timer1.Stop();
                SetState(false);
            };
            InitParameters();
            SetState(false);
        }

        private DispatcherTimer timer1 = new DispatcherTimer();
        private int min, max;
        private double oldFontSize;
        private double newFontSize;
        private bool isIntRandom = true;

        private void InitParameters()
        {
            if (int.TryParse(textBoxInterval.Text, out int inteval) == false)
            {
                textBoxInterval.Text = "100";
                timer1.Interval = TimeSpan.FromMilliseconds(100);
            }
            else
            {
                timer1.Interval = TimeSpan.FromMilliseconds(inteval);
            }
            if (int.TryParse(textBoxMin.Text, out min) == false)
            {
                textBoxMin.Text = "0";
                min = 0;
            }
            if (int.TryParse(textBoxMax.Text, out max) == false)
            {
                textBoxMax.Text = "100";
                max = 100;
            }
            if (r1.IsChecked == true)
            {
                isIntRandom = true;
            }
            else
            {
                isIntRandom = false;
            }
        }

        private void SetState(bool isStarted)
        {
            btnStop.IsEnabled = isStarted;
            groupBox1.IsEnabled = !isStarted;
            btnStart.IsEnabled = !isStarted;
            if (isStarted)
            {
                labelResult.FontSize = oldFontSize;
            }
            else
            {
                labelResult.FontSize = newFontSize;
            }
        }
    }

    class RandomHelp
    {
        private static Random r = new Random();
        /// <summary>
        /// 获取指定范围的随机整数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>随机产生的整数</returns>
        public static int GetIntRandomNumber(int min, int max)
        {
            return r.Next(min, max + 1);
        }

        /// <summary>
        /// 获取指定范围的随机浮点数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>随机产生的浮点数</returns>
        public static double GetDoubleRandomNumber(int min, int max)
        {
            double d = max * r.NextDouble();
            if (d < min)
            {
                d += min;
            }
            return Math.Min(d, max);
        }
    }
}
