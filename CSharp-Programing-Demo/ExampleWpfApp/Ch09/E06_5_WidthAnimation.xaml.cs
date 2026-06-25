using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace ExampleWpfApp.Ch09
{
    public partial class E06_5_WidthAnimation : Page
    {
        public E06_5_WidthAnimation()
        {
            InitializeComponent();
            btn3.Loaded += Button3_Loaded;
        }
        private Storyboard story1;
        void Button3_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da1 = new DoubleAnimation()
            {
                To = 100,
                Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            DoubleAnimation da2 = da1.Clone();
            da2.To = 200;
            da2.Duration = new Duration(TimeSpan.FromSeconds(1));
            story1 = new Storyboard();
            Storyboard.SetTarget(da1, btn3);
            Storyboard.SetTargetProperty(da1, new PropertyPath(Button.WidthProperty));
            story1.Children.Add(da1);
            Storyboard.SetTarget(da2, btn4);
            Storyboard.SetTargetProperty(da2, new PropertyPath(Button.WidthProperty));
            story1.Children.Add(da2);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button btn)
            {
                string s = btn.Content.ToString();
                switch (s)
                {
                    case "开始": story1.Begin(); break;
                    case "停止": story1.Stop(); break;
                    case "暂停": story1.Pause(); break;
                    case "继续": story1.Resume(); break;
                }
            }
        }
    }
}
