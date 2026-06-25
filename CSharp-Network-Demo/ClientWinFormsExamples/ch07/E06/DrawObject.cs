using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    public abstract class DrawObject
    {
        /// <summary>画笔颜色</summary>
        [DataMember] public Color PenColor { get; set; }

        /// <summary>画笔宽度</summary>
        [DataMember] public int PenWidth { get; set; }

        /// <summary>对象ID </summary>
        [DataMember] public int ID { get; set; }

        /// <summary>是否选择了该对象</summary>
        public bool Selected { get; set; }

        private readonly E0706DrawForm fm;
        public DrawObject(E0706DrawForm fm)
        {
            this.fm = fm;
        }

        protected void AddOtherFields(DrawObject w)
        {
            w.PenColor = PenColor;
            w.PenWidth = PenWidth;
            w.ID = fm.UC1.ID;
        }

        #region 扩充类必须实现的属性或方法

        /// <summary>句柄数</summary>
        public abstract int HandleCount { get; }

        /// <summary>克隆</summary>
        public abstract DrawObject Clone();

        /// <summary>画图</summary>
        public abstract void Draw(Graphics g);

        /// <summary>取句柄所在的点</summary>
        public abstract Point GetHandle(int handleNumber);

        /// <summary>画句柄</summary>
        public abstract void DrawHandle(Graphics g);

        /// <summary>判断是否选中该对象及句柄</summary>
        public abstract int HitTest(Point point);

        /// <summary>判断该点是否在对象范围内</summary>
        public abstract bool PointInObject(Point point);

        /// <summary>根据句柄取光标类型</summary>
        public abstract Cursor GetHandleCursor(int handleNumber);

        /// <summary>判断是否相交</summary>
        public abstract bool IntersectsWith(Rectangle rectangle);

        /// <summary>移动对象</summary>
        public abstract void Move(int deltaX, int deltaY);

        /// <summary>移动句柄</summary>
        public abstract void MoveHandleTo(Point point, int handleNumber);

        /// <summary>取句柄的实体矩形</summary>
        public abstract Rectangle GetHandleRectangle(int n);

        #endregion

    }
}