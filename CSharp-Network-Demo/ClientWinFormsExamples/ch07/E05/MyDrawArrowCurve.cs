using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E05
{
    class MyDrawArrowCurve : MyDrawCurveHandle
    {
        public MyDrawArrowCurve()
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

        public MyDrawArrowCurve(Point p, Color mycolor, int myPenWidth, int id)
        {
            AddPoint(p);
            PenColor = mycolor;
            PenWidth = myPenWidth;
            ID = id;
        }

        public MyDrawArrowCurve(List<Point> myPointList, int myPenWidth, Color mycolor, int id)
        {
            for (int i = 0; i < myPointList.Count; i++)
            {
                AddPoint(myPointList[i]);
            }
            PenColor = mycolor;
            PenWidth = myPenWidth;
            ID = id;
        }

        public void AddPoint(Point p)
        {
            PointList.Add(p);
        }

        public override void Draw(Graphics g)
        {
            Point[] pts = new Point[PointList.Count];
            PointList.CopyTo(pts);
            Pen pen = new(PenColor, PenWidth);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            AdjustableArrowCap myArrow = new(4, 4, true);
            pen.CustomEndCap = myArrow;
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
