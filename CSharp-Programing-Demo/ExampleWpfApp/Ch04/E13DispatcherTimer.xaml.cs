using System;
using System.Windows.Controls;
using System.Windows.Threading;
namespace ExampleWpfApp.Ch04
{
    public partial class E13DispatcherTimer : Page
    {
        public E13DispatcherTimer()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) =>
            {
                uc.Result.Content = $"{DateTime.Now:yyyy-MM-dd dddd tt HH:mm:ss}";
            };
            timer.Start();
        }
    }
}
