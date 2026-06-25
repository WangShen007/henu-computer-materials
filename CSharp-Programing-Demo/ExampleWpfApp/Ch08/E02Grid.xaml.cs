using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch08
{
    public partial class E03Grid : Page
    {
        public E03Grid()
        {
            InitializeComponent();
            Random r = new Random();
            var timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.5)
            };
            timer.Tick += (s, e) =>
            {
                Grid.SetRow(txt, r.Next(3));
                Grid.SetColumn(txt, r.Next(3));
            };
            timer.Start();
        }
    }
}
