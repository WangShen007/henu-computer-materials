using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawCurve : DrawCurveHandle
    {
        private readonly E0706DrawForm fm;
        public DrawCurve(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public override DrawObject Clone()
        {
            DrawArrowCurve w = new(fm);
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
        public DrawCurve(E0706DrawForm fm, Point p, Color mycolor, int myPenWidth, int id):base(fm)
        {
            this.fm = fm;
            AddPoint(p);
            PenColor = mycolor;
            PenWidth = myPenWidth;
            ID = id;
        }

        /// <summary>点集、画笔宽度、画笔颜色、ID</summary>
        public DrawCurve(E0706DrawForm fm, List<Point> myPointList, int myPenWidth, Color mycolor, int id):base(fm)
        {
            this.fm = fm;
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
