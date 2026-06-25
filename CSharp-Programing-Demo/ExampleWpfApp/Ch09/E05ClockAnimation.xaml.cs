using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch09
{
    public partial class E05ClockAnimation : Page
    {
        public E05ClockAnimation()
        {
            InitializeComponent();
            CreateAnimatedEllipse();
        }
        private List<AnimationClock> acList;
        private const int w = 20; //小球的宽和高
        private int ellipseNumber = 10;
        private Random r = new Random(DateTime.Now.Millisecond);
        private void CreateAnimatedEllipse()
        {
            if (acList != null)
            {
                foreach (var ac in acList)
                {
                    ac.Controller.Remove();
                }
                acList.Clear();
                acList = null;
            }
            canvas1.Children.Clear();
            acList = new List<AnimationClock>();
            for (int i = 0; i < ellipseNumber; i++)
            {
                Ellipse ellipse = new Ellipse()
                {
                    Width = w,
                    Height = w,
                    Fill = Brushes.Blue,
                };
                double bottom = canvas1.ActualHeight;
                double ellipseLeft = r.NextDouble() * canvas1.ActualWidth - w;
                double ellipseTop = r.NextDouble() * bottom - w;
                if (ellipseLeft <= 0) ellipseLeft = 0;
                if (ellipseTop <= 0) ellipseTop = 0;
                Canvas.SetLeft(ellipse, ellipseLeft);
                Canvas.SetTop(ellipse, ellipseTop);
                canvas1.Children.Add(ellipse);
                AnimationClock ac1 = CreateDoubleAnimation(ellipseLeft);
                AnimationClock ac2 = CreateDoubleAnimation(ellipseTop);
                TranslateTransform tt = new TranslateTransform();
                tt.ApplyAnimationClock(TranslateTransform.XProperty, ac1);
                tt.ApplyAnimationClock(TranslateTransform.YProperty, ac2);
                ellipse.RenderTransform = tt;
                acList.Add(ac1);
                acList.Add(ac2);
            }
        }
        private AnimationClock CreateDoubleAnimation(double n)
        {
            double d = 0;
            while (d == 0)
            {
                d = r.NextDouble() - r.NextDouble();
            }
            DoubleAnimation da = new DoubleAnimation()
            {
                From = 0,
                To = d * n,
                Duration = new Duration(TimeSpan.FromSeconds(Math.Abs(d) * 2)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            AnimationClock ac = da.CreateClock();
            return ac;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button btn)
            {
                string s = btn.Content.ToString();
                switch (s)
                {
                    case "开始": foreach (var ac in acList) ac.Controller.Begin(); break;
                    case "停止": foreach (var ac in acList) ac.Controller.Stop(); break;
                    case "暂停": foreach (var ac in acList) ac.Controller.Pause(); break;
                    case "继续": foreach (var ac in acList) ac.Controller.Resume(); break;
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (e.Source is RadioButton r)
            {
                if (r.Content != null)
                {
                    ellipseNumber = int.Parse(r.Content.ToString());
                    CreateAnimatedEllipse();
                }
            }
        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CreateAnimatedEllipse();
        }
    }
}
