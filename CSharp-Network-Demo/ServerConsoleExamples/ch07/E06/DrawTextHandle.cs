using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    internal class DrawTextHandle : DrawObject
    {
        [DataMember] public Point StartPoint { get; protected set; }

        [DataMember] public Point EndPoint { get; protected set; }

        [DataMember] public int FontHeight { get; protected set; }

        [DataMember] public string Text { get; protected set; } = "";

        [DataMember] public float Angle { get; protected set; }

        /// <summary>当曲线上的点发生移动时,重新记录鼠标点的位置</summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (handleNumber == 1)
            {
                return;
            }
            else
            {
                float distance = GetDistance(StartPoint, point) - Text.Length;
                int height = (int)(distance / Text.Length);
                if (height > 0)
                {
                    FontHeight = height;
                    EndPoint = point;
                    Angle = (float)(Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X) * 180.0 / Math.PI);
                }
            }
        }

        /// <summary>位移函数</summary>
        public override void Move(int dx, int dy)
        {
            StartPoint = new Point(StartPoint.X + dx, StartPoint.Y + dy);
            EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);

        }

        protected static float GetDistance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int distance = (int)Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }
    }
}
