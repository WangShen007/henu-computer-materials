using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch11
{
    public partial class E05Polygon : Page
    {
        public E05Polygon()
        {
            InitializeComponent();
            btn1.Click += delegate
              {
                  if (int.TryParse(textBox1.Text, out int numSides) == false)
                  {
                      path1.Data = null;
                      return;
                  }
                  if (numSides < 3 || numSides > 30)
                  {
                      path1.Data = null;
                      return;
                  }
                  DrawRegularPolygon(numSides);
              };
        }
        private void DrawRegularPolygon(int numSides)
        {
            GeometryGroup gg = new GeometryGroup();
            gg.Children.Add(BuildRegularPolygon(numSides, 100));
            gg.Children.Add(BuildRegularPolygon(numSides, 50));
            gg.FillRule = FillRule.EvenOdd; //多个图形组合时才起作用
            gg.Freeze(); //冻结的目的是提高性能
            path1.Data = gg;
        }
        private StreamGeometry BuildRegularPolygon(int numSides, int r)
        {
            Point c = new Point(100, 100);  //中心点
            StreamGeometry geometry = new StreamGeometry();
            using (StreamGeometryContext ctx = geometry.Open())
            {
                Point c1 = c;
                double step = 2 * Math.PI / Math.Max(numSides, 3);
                double a = step;
                for (int i = 0; i < numSides; i++, a += step)
                {
                    c1.X = c.X + r * Math.Cos(a);
                    c1.Y = c.Y + r * Math.Sin(a);
                    if (i == 0) ctx.BeginFigure(c1, isFilled: true, isClosed: true);
                    else ctx.LineTo(c1, isStroked: true, isSmoothJoin: false);
                }
            }
            return geometry;
        }
    }
}
