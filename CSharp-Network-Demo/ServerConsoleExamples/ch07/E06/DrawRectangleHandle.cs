using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawRectangleHandle : DrawObject
    {
        /// <summary>矩形对象位置及大小</summary>
        [DataMember]
        public Rectangle ObjRectangle { get; set; }

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
    }
}
