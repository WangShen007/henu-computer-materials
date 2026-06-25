using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawCurveHandle : DrawObject
    {
        [DataMember]
        public List<Point> PointList { get; set; } = new List<Point>();

        /// <summary>当曲线上的点发生移动时,重新记录鼠标点的位置</summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            //Point p = PointList[handleNumber - 1];
            //float dx = point.X - p.X;
            //float dy = point.Y - p.Y;
            PointList[handleNumber - 1] = new Point(point.X, point.Y);
        }

        /// <summary>位移函数</summary>
        public override void Move(int dx, int dy)
        {
            int n = PointList.Count;
            for (int i = 0; i < n; i++)
            {
                Point p = new(dx, dy);
                PointList[i] = new Point(PointList[i].X + p.X, PointList[i].Y + p.Y);
            }

        }
    }
}
