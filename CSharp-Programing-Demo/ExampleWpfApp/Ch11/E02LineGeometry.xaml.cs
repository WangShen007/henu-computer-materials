using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch11
{
    public partial class E02LineGeometry : Page
    {
        public E02LineGeometry()
        {
            InitializeComponent();
            //带箭头的坐标线
            canvas1.Children.Add(GetAxis(canvas1.Width / 2, canvas1.Height / 2, Brushes.Red));
            //虚线正弦曲线
            canvas1.Children.Add(new Path
            {
                Stroke = Brushes.Black,
                StrokeDashArray = new DoubleCollection(new List<double> { 2, 2 }),
                StrokeDashOffset = 1,
                Data = SinGeometry(maxX: 360, maxY: 100, step: 1)
            });
            //实线正弦曲线
            canvas1.Children.Add(new Path
            {
                Stroke = Brushes.Green,
                Data = SinGeometry(maxX: 360, maxY: 50, step: 60)
            });
        }
        private Path GetAxis(double maxX, double maxY, Brush stroke)
        {
            double w = maxX, h = maxY;
            //横坐标
            Geometry axisX = Geometry.Parse($"M-{w},0 L{w + 5},0 {w - 5},5 M{w + 5},0 L{w - 5},-5");
            //纵坐标
            Geometry axisY = Geometry.Parse($"M0,{h + 5} L0,-{h + 5} -5,-{h - 5} M0,-{h + 5} L5,-{h - 5}");
            PathGeometry p = new PathGeometry();
            p.AddGeometry(axisX);
            p.AddGeometry(axisY);
            return new Path { Stroke = stroke, Data = p };
        }
        private StreamGeometry SinGeometry(int maxX, int maxY, int step)
        {

            StreamGeometry g = new StreamGeometry();
            using (StreamGeometryContext ctx = g.Open())
            {
                double y0 = Math.Sin(-maxX * Math.PI / 180.0);
                ctx.BeginFigure(startPoint: new Point(-maxX, maxY * y0), isFilled: false, isClosed: false);
                for (int x = -maxX; x < maxX + step; x += step)
                {
                    double y = Math.Sin(x * Math.PI / 180.0);
                    ctx.LineTo(point: new Point(x, maxY * y), isStroked: true, isSmoothJoin: true);
                }
            }
            g.Freeze(); //冻结的目的是提高性能
            return g;
        }
    }
}
