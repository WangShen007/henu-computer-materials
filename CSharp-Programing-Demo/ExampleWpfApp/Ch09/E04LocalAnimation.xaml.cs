using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
namespace ExampleWpfApp.Ch09
{
    public partial class E04LocalAnimation : Page
    {
        public E04LocalAnimation()
        {
            InitializeComponent();
            btn1.Loaded += (s, e) =>
            {
                DoubleAnimation da1 = InitDoubleAnimation(100, 1);
                DoubleAnimation da2 = InitDoubleAnimation(60, 1);
                //对背景颜色进行动画处理
                ColorAnimation ca = new ColorAnimation()
                {
                    From = Colors.Blue,
                    To = Colors.Red,
                    Duration = new Duration(TimeSpan.FromSeconds(1.5)),
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever
                };
                btn1.BeginAnimation(WidthProperty, da1);
                btn1.BeginAnimation(HeightProperty, da2);
                btn1.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            };
        }
        private DoubleAnimation InitDoubleAnimation(double to, double seconds)
        {
            DoubleAnimation da = new DoubleAnimation()
            {
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            return da;
        }
    }
}
