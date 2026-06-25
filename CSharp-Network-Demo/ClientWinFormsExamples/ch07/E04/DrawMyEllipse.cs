using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWinFormsExamples.ch07.E04
{
    /// <summary>
    /// 椭圆绘制类
    /// </summary>
    internal class DrawMyEllipse : DrawMyObject
    {
        public Rectangle Rect { get; set; }
        public DrawMyEllipse(int x, int y, int width, int height, Color penColor)
        {
            Rect = new Rectangle(x, y, width, height);
            PenColor = penColor;
        }
        public override void Draw(Graphics g)
        {
            using Pen pen = new(PenColor);
            g.DrawEllipse(pen, Rect);
        }
    }
}
