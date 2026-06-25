using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch09
{
    public partial class E06_6_OpacityAnimation : Page
    {
        public E06_6_OpacityAnimation()
        {
            InitializeComponent();
        }
        private void MyRectangle2_Clicked(object sender, MouseButtonEventArgs e)
        {
            //实现淡出效果（为了仍能看到矩形，让不透明度从1.0变化到0.05）
            DoubleAnimation da = new DoubleAnimation
            {
                From = 1.0,
                To = 0.05,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(da);
            Storyboard.SetTarget(da, MyRectangle2);
            Storyboard.SetTargetProperty(da, new PropertyPath(Rectangle.OpacityProperty));
            myStoryboard.Begin();
        }
    }
}
