using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E05
{
    class MyDrawCurve : MyDrawCurveHandle
    {
        public MyDrawCurve()
        {
        }

        public override MyDrawObject Clone()
        {
            MyDrawArrowCurve w = new();
            for (int i = 0; i < PointList.Count; i++)
            {
                w.PointList.Add(PointList[i]);
            }
            w.PenColor = PenColor;
            w.PenWidth = PenWidth;
            AddOtherFields(w);
            return w;
        }

        /// <summary>点、画笔宽度、画笔颜色、ID</summary>
        public MyDrawCurve(Point p, Color mycolor, int myPenWidth, int id)
        {
            AddPoint(p);
            PenColor = mycolor;
            PenWidth = myPenWidth;
            ID = id;
        }

        /// <summary>点集、画笔宽度、画笔颜色、ID</summary>
        public MyDrawCurve(List<Point> myPointList, int myPenWidth, Color mycolor, int id)
        {
            for (int i = 0; i < myPointList.Count; i++)
            {
                AddPoint(myPointList[i]);
            }
            PenColor = mycolor;
            PenWidth = myPenWidth;
            ID = id;
        }

        /// <summary>添加曲线点</summary>
        public void AddPoint(Point p)
        {
            PointList.Add(p);
        }

        /// <summary>曲线绘制方法</summary>
        public override void Draw(Graphics g)
        {
            Point[] pts = new Point[PointList.Count];
            PointList.CopyTo(pts);
            Pen pen = new(PenColor, PenWidth);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (pts.Length < 3)
            {
                if (pts.Length > 1)
                {
                    g.DrawLine(pen, pts[0], pts[1]);
                }
            }
            else
            {
                g.DrawCurve(pen, pts);
            }
            pen.Dispose();
        }
    }
}
