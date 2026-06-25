using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Threading;
namespace ExampleWpfApp.Ch04
{
    public partial class E15Random : Page
    {
        public E15Random()
        {
            InitializeComponent();

            Random r = new Random();
            int lastElapsed = 0;
            Stopwatch stopwatch = new Stopwatch();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timer.Tick += (s, e) =>
            {
                var x = DateTime.FromBinary(stopwatch.Elapsed.Ticks);
                textBlock1.Text = $"{x: HH : mm : ss : fff}";
                int t = (int)stopwatch.Elapsed.TotalSeconds;
                if (t % 5 == 0 && t != lastElapsed)
                {
                    lastElapsed = t;
                    string str = $"第{t}秒产生的随机数为：";
                    for (int i = 0; i < 5; i++)
                    {
                        str += r.Next(1, 41) + "，";
                    }
                    textBlock2.Text += str.TrimEnd('，') + "\n";
                }
            };
            stopwatch.Start();
            timer.Start();
        }
    }
}
