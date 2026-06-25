using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    public abstract class DrawObject
    {
        /// <summary>移动对象</summary>
        public abstract void Move(int deltaX, int deltaY);

        /// <summary>移动句柄</summary>
        public abstract void MoveHandleTo(Point point, int handleNumber);


        /// <summary>是否选择了该对象</summary>
        public bool Selected { get; set; }

        /// <summary>画笔颜色</summary>
        [DataMember] public Color PenColor { get; set; }

        /// <summary>画笔宽度</summary>
        [DataMember] public int PenWidth { get; set; }

        [DataMember] public int ID { get; set; }

    }
}