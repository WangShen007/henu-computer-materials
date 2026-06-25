using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A11
{
    public class MyTriangle : MyShape
    {
        public MyTriangle(Border parent, int a, int b, int angle) : base(parent)
        {
            A = a;
            B = b;
            Angle = angle;
        }

        /// <summary>
        /// 三角形左侧的边
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// 三角形下方的边
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// 边a和边b的夹角（0到90）
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        /// 三角形右侧的边
        /// </summary>
        public int C
        {
            get
            {
                return (int)Math.Round(Math.Sqrt(A * A + B * B - 2 * A * B * Math.Cos(Angle * Math.PI / 180.0)));
            }
        }

        public bool IsEquilateralTriangle
        {
            get
            {
                return (A == B && B == C);
            }
        }

        public override void Draw()
        {
            double d = Math.PI / 180.0;
            Polygon polygon = new Polygon()
            {
                StrokeThickness = 2,
                Stroke = Brushes.Red,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            polygon.Points.Add(new Point(0, 60));  //三角形左下角的点(固定值)
            polygon.Points.Add(new Point(B, 60));  //三角形右下角的点
            //三角形上面的点
            polygon.Points.Add(new Point(
                A * Math.Cos(Angle * d),       //x
                60 - A * Math.Sin(Angle * d)   //y
                ));
            this.parentElement.Child = polygon;
        }

        public override double GetArea()
        {
            double p = (A + B + C) / 2;
            return (int)Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
