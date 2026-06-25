using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A11
{
    public class MyRectangle : MyShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public MyRectangle(Border border, int width, int height)
            : base(border)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void Draw()
        {
            Rectangle r = new Rectangle()
            {
                Width = this.Width,
                Height = this.Height,
                StrokeThickness = 1,
                Stroke = Brushes.Red
            };
            this.parentElement.Child = r;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        /// <summary>
        /// 根据宽和高计算矩形的周长
        /// </summary>
        /// <returns>矩形的周长</returns>
        public double Perimeter()
        {
            return (Width + Height) * 2;
        }

        /// <summary>
        /// 是否为正方形
        /// </summary>
        public bool IsEquilateral
        {
            get
            {
                return (Width == Height);
            }
        }
    }
}
