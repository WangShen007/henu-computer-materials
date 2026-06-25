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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A09
{
    /// <summary>
    /// PageA0902.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0902 : Page
    {
        TextBlock[] textBlocks;
        Rectangle[] rectangles;

        public PageA0902()
        {
            InitializeComponent();

            textBlocks = new TextBlock[] { t1, t2, t3, t4, t5, t6, t7 };
            rectangles = new Rectangle[] { r1, r2, r3, r4, r5, r6, r7 };

            btn1.Click += delegate
            {
                //清除上次动画
                for (int i = 0; i < rectangles.Length; i++)
                {
                    rectangles[i].Height = 0;
                    rectangles[i].ApplyAnimationClock(Rectangle.HeightProperty, null);
                }

                //计算字母出现次数
                string s = myTextBox.Text.ToUpper();
                int[] a = new int[7];
                for (int i = 0; i < s.Length; i++)
                {
                    int c = s[i];
                    if (c >= 'A' && c <= 'G')
                    {
                        a[c - 'A']++;
                    }
                }

                //开始本次动画
                int startTime = 0;
                int duration = 2;
                for (int i = 0; i < rectangles.Length; i++)
                {
                    textBlocks[i].Text = a[i].ToString();
                    AnimationRectangle(rectangles[i], a[i], startTime, duration);
                    startTime += duration;
                }
            };
        }
        private void AnimationRectangle(Rectangle r, int count, int startTime, int duration)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = count * 40,
                BeginTime = TimeSpan.FromSeconds(startTime),
                Duration = TimeSpan.FromSeconds(duration),
                AutoReverse = false
            };
            AnimationClock clock = da.CreateClock();
            r.ApplyAnimationClock(Rectangle.HeightProperty, clock);
        }
    }
}
