namespace ClientWinFormsExamples.ch07.E04
{
    /// <summary>
    /// 基类
    /// </summary>
    internal abstract class DrawMyObject
    {
        public bool IsSelected { get; set; } = false;
        public Color PenColor { get; set; } = Color.Black;
        public int PenWidth { get; set; } = 2;
        //扩充类必须实现该方法
        public abstract void Draw(Graphics g);
    }
}
