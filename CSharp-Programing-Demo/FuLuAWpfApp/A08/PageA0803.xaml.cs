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
    /// PageA0803.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0803 : Page
    {
        Random r = new Random();
        const int min = 1;  //随机数最小为1
        const int max = 31;  //随机数最大为30（=31-1）
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        int maxTime = 25;  //限时25秒
        int count;

        public PageA0803()
        {
            InitializeComponent();

            groupBox1.IsEnabled = false;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += delegate
            {
                if (count == 0)
                {
                    CheckResult();
                }
                else
                {
                    count--;
                    labelCount.Content = $"{count} 秒";
                }
            };
            btnStart.Click += delegate
            {
                count = maxTime;
                labelCount.Content = $"{count} 秒";
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                label1.Content = string.Format("1、{0}+{1}=", r.Next(min, max), r.Next(min, max));
                label2.Content = string.Format("2、{0}-{1}=", r.Next(min, max), r.Next(min, max));
                label3.Content = string.Format("3、{0}*{1}=", r.Next(10, max), r.Next(min, 11));
                int a1, a2;
                do
                {
                    a1 = r.Next(10, max);
                    a2 = r.Next(min, 11);
                } while ((a1 * 100) % a2 != 0);
                label4.Content = string.Format("4、{0}/{1}=", a1, a2);
                groupBox1.IsEnabled = true;
                timer.Start();
            };
            btnOK.Click += delegate
            {
                CheckResult();
            };
        }
        private void CheckResult()
        {
            timer.Stop();
            groupBox1.IsEnabled = false;

            string[] s1 = label1.Content.ToString().Split('、', '+', '=');
            string[] s2 = label2.Content.ToString().Split('、', '-', '=');
            string[] s3 = label3.Content.ToString().Split('、', '*', '=');
            string[] s4 = label4.Content.ToString().Split('、', '/', '=');
            try
            {
                if (int.Parse(s1[1]) + int.Parse(s1[2]) == int.Parse(textBox1.Text)
                    && int.Parse(s2[1]) - int.Parse(s2[2]) == int.Parse(textBox2.Text)
                    && int.Parse(s3[1]) * int.Parse(s3[2]) == int.Parse(textBox3.Text)
                    && int.Parse(s4[1]) / (double)int.Parse(s4[2]) == double.Parse(textBox4.Text))
                {
                    MessageBox.Show("恭喜，过关成功。","", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("过关失败，请继续努力。", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("过关失败，请继续努力。", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
