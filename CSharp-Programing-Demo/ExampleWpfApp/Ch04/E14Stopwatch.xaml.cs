using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E14Stopwatch : Page
    {
        public E14Stopwatch()
        {
            InitializeComponent();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += (s, e) =>
            {
                DateTime dt = DateTime.FromBinary(stopwatch.Elapsed.Ticks);
                this.Dispatcher.InvokeAsync(() => {
                    tip.Text = $"{dt: HH : mm : ss : fff}";
                });
                var t = stopwatch.Elapsed.TotalMilliseconds;
                if (t > 5000)
                {
                    stopwatch.Stop();
                    timer.Stop();
                    this.Dispatcher.InvokeAsync(() => {
                        result.Text = $"共用时{Math.Round(t, 0)}毫秒";
                    });
                }
            };
            stopwatch.Start();
            timer.Start();
        }
    }
}
