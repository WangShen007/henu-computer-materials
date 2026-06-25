using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    //带有句柄的矩形
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawRectangleHandle : DrawObject
    {
        /// <summary>矩形对象位置及大小</summary>
        [DataMember] public Rectangle ObjRectangle { get; set; }

        private readonly E0706DrawForm fm;
        public DrawRectangleHandle(E0706DrawForm fm) : base(fm)
        {
            this.fm = fm;
        }

        public override void Draw(Graphics g)
        {
            throw new Exception("该方法还没有实现，请在扩充类中实现该方法");
        }

        public override DrawObject Clone()
        {
            DrawRectangle w = new(fm)
            {
                ObjRectangle = ObjRectangle
            };
            AddOtherFields(w);
            return w;
        }

        ///<summary>句柄数</summary>
        public override int HandleCount { get { return 8; } }

        /// <summary>取句柄所在的点</summary>
        public override Point GetHandle(int handleNumber)
        {
            Rectangle rect = new(ObjRectangle.X, ObjRectangle.Y, ObjRectangle.Width, ObjRectangle.Height);
            int x = rect.X;
            int y = rect.Y;
            int xCenter = x + rect.Width / 2;
            int yCenter = y + rect.Height / 2;
            switch (handleNumber)
            {
                case 1:
                    x = rect.X; y = rect.Y; break;
                case 2:
                    x = xCenter; y = rect.Y; break;
                case 3:
                    x = rect.Right; y = rect.Y; break;
                case 4:
                    x = rect.Right; y = yCenter; break;
                case 5:
                    x = rect.Right; y = rect.Bottom; break;
                case 6:
                    x = xCenter; y = rect.Bottom; break;
                case 7: x = rect.X; y = rect.Bottom; break;
                case 8:
                    x = rect.X; y = yCenter; break;
            }
            return new Point(x, y);
        }

        /// <summary>画句柄</summary>
        public override void DrawHandle(Graphics g)
        {
            SolidBrush brush = new(Color.Black);
            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }
            brush.Dispose();
        }

        /// <summary>判断该对象及句柄是否被选中，-1：未选中，0：选中对象，1-8：选中句柄</summary>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                    {
                        return i;
                    }
                }
            }
            if (PointInObject(point))
            {
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// 判断该点是否在对象范围内
        /// </summary>
        public override bool PointInObject(Point point)
        {
            return ObjRectangle.Contains(point);
        }

        /// <summary>根据句柄取光标类型</summary>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            return handleNumber switch
            {
                1 => Cursors.SizeNWSE,
                2 => Cursors.SizeNS,
                3 => Cursors.SizeNESW,
                4 => Cursors.SizeWE,
                5 => Cursors.SizeNWSE,
                6 => Cursors.SizeNS,
                7 => Cursors.SizeNESW,
                8 => Cursors.SizeWE,
                _ => Cursors.Default,
            };
        }

        /// <summary>判断该矩形与rectangle是否相交</summary>
        public override bool IntersectsWith(Rectangle rectangle)
        {
            return ObjRectangle.IntersectsWith(rectangle);
        }

        /// <summary>移动对象</summary>
        public override void Move(int deltaX, int deltaY)
        {
            var rect = ObjRectangle;
            rect.X += deltaX;
            rect.Y += deltaY;
            ObjRectangle = rect;
        }

        /// <summary>移动句柄</summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = ObjRectangle.X;
            int top = ObjRectangle.Y;
            int right = ObjRectangle.Right;
            int bottom = ObjRectangle.Bottom;
            switch (handleNumber)
            {
                case 1:
                    left = point.X; top = point.Y; break;
                case 2:
                    top = point.Y; break;
                case 3:
                    right = point.X; top = point.Y; break;
                case 4:
                    right = point.X; break;
                case 5:
                    right = point.X; bottom = point.Y; break;
                case 6:
                    bottom = point.Y; break;
                case 7:
                    left = point.X; bottom = point.Y; break;
                case 8:
                    left = point.X; break;
            }
            ObjRectangle = CC.GetNormalizedRectangle(left, top, right, bottom);
        }

        /// <summary>取句柄的实体矩形</summary>
        public override Rectangle GetHandleRectangle(int n)
        {
            Point point = GetHandle(n);
            int x = point.X;
            int y = point.Y;
            if (n == 1) { x -= 4; y -= 4; }
            else if (n == 2) { x -= 2; y -= 4; }
            else if (n == 3) { x += PenWidth; y -= 4; }
            else if (n == 4) { x += PenWidth; y -= 2; }
            else if (n == 5) { x += PenWidth; y += PenWidth; }
            else if (n == 6) { x -= 2; y += PenWidth; }
            else if (n == 7) { x -= 4; y += PenWidth; }
            else if (n == 8) { x -= 4; y -= 2; }
            return new Rectangle(x, y, 5, 5);
        }
    }
}
