using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawTextHandle : DrawObject
    {
        [DataMember] public Point StartPoint { get; protected set; }

        [DataMember] public Point EndPoint { get; protected set; }

        [DataMember] public int FontHeight { get; protected set; }

        [DataMember] public string Text { get; protected set; } = "";

        [DataMember] public float Angle { get; protected set; }

        protected Font? font;
        protected GraphicsPath? areaPath = null;
        protected Pen? areaPen = null;
        protected Region? areaRegion = null;

        private readonly E0706DrawForm fm;
        public DrawTextHandle(E0706DrawForm fm) : base(fm)
        {
            this.fm = fm;
        }

        public override void Draw(Graphics g)
        {
            throw new Exception("该方法还没有实现，请在扩充类中实现该方法");
        }

        protected static float GetDistance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int distance = (int)Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }

        public override DrawObject Clone()
        {
            DrawText w = new(fm)
            {
                font = font,
                Text = Text,
                StartPoint = StartPoint,
                EndPoint = EndPoint,
                Angle = Angle
            };
            AddOtherFields(w);
            return w;
        }

        /// <summary>画句柄</summary>
        public override void DrawHandle(Graphics g)
        {
            SolidBrush brush = new(Color.Blue);
            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }
            brush.Dispose();
            Matrix matrix = new();
            matrix.RotateAt(Angle, StartPoint);
            g.Transform = matrix;
            g.DrawRectangle(Pens.Red, StartPoint.X, StartPoint.Y, GetDistance(StartPoint, EndPoint), FontHeight);
            g.ResetTransform();
            matrix.Dispose();
        }

        /// <summary>取句柄的实体矩形</summary>
        public override Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
            return new Rectangle(point.X - PenWidth, point.Y - PenWidth, 5, 5);
        }

        /// <summary>
        /// 1：左边，2：右边
        /// </summary>
        public override int HandleCount
        {
            get { return 2; }
        }

        /// <summary>获得句柄</summary>
        public override Point GetHandle(int handleNumber)
        {
            if (handleNumber == 1)
            {
                return StartPoint;
            }
            else
            {
                return EndPoint;
            }
        }

        /// <summary>根据句柄,获得鼠标形状</summary>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.SizeWE;
        }

        /// <summary>当前鼠标位置是否在句柄范围内</summary>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(new Point(point.X, point.Y)))
                        return i;
                }
            }
            if (PointInObject(point))
                return 0;
            return -1;
        }

        public override bool PointInObject(Point point)
        {
            CreateTrackObject();
            if (areaRegion != null)
            {
                return areaRegion.IsVisible(point);
            }
            else
            {
                return false;
            }
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateTrackObject();
            if (areaRegion != null)
            {
                return areaRegion.IsVisible(rectangle);
            }
            else
            {
                return false;
            }
        }

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
            ClearTrackObject();
        }

        /// <summary>位移函数</summary>
        public override void Move(int dx, int dy)
        {
            StartPoint = new Point(StartPoint.X + dx, StartPoint.Y + dy);
            EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);
            ClearTrackObject();
        }

        /// <summary>创建聚焦用的对象</summary>
        protected virtual void CreateTrackObject()
        {
            if (areaPath != null)
            {
                areaPath.Reset();
                areaPath.FillMode = FillMode.Winding;
            }
            else
            {
                areaPath = new GraphicsPath(FillMode.Winding);
            }
            if (areaRegion != null)
            {
                areaRegion.MakeEmpty();
            }
            else
            {
                areaRegion = new Region();
            }
            if(areaPen == null)
            {
                if (fm == null)
                {
                    areaPen = new Pen(Color.White, FontHeight);
                }
                else
                {
                    areaPen = new Pen(fm.UC1.BackColor, FontHeight);
                }
            }
            if (GetDistance(StartPoint, EndPoint) > 0)
            {
                areaPath.AddLine(StartPoint, EndPoint);
                areaPath.CloseFigure();
                areaPath.Widen(areaPen);
                areaRegion.Union(areaPath);
            }
        }

        protected virtual void ClearTrackObject()
        {
            if (areaPath != null)
            {
                areaPath.Dispose();
                areaPath = null;
            }

            if (areaPen != null)
            {
                areaPen.Dispose();
                areaPen = null;
            }

            if (areaRegion != null)
            {
                areaRegion.Dispose();
                areaRegion = null;
            }
        }
    }
}
