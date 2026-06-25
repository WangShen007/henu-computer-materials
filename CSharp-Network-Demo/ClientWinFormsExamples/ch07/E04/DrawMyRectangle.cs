namespace ClientWinFormsExamples.ch07.E04
{
    /// <summary>
    /// 矩形绘制类
    /// </summary>
    internal class DrawMyRectangle : DrawMyObject
    {
        public Rectangle Rect { get; set; }
        public DrawMyRectangle(int x, int y, int width, int height, Color penColor)
        {
            Rect = new Rectangle(x, y, width, height);
            PenColor = penColor;
        }
        //绘制方法
        public override void Draw(Graphics g)
        {
            using Pen pen = new(PenColor);
            g.DrawRectangle(pen, Rect);
        }
    }
}
