namespace ClientWinFormsExamples.ch07.E05
{
    public partial class MyUC : UserControl
    {
        public MyToolObject[]? Tools { get; set; }

        public MyToolType ActiveTool { get; set; }

        /// <summary>绘图对象列表</summary>
        public MyGraphicsList Graphics { get; set; } = new MyGraphicsList();


        /// <summary>是否画鼠标左键拖放范围的矩形框</summary>
        public bool IsDrawNetRectangle { get; set; } = false;

        /// <summary>鼠标左键拖放范围矩形大小及位置</summary>
        public Rectangle NetRectangle { get; set; }

        public MyUC()
        {
            InitializeComponent();

            this.MouseDown += MyUC_MouseDown;
            this.MouseUp += MyUC_MouseUp;
            this.MouseMove += MyUC_MouseMove;
            this.Paint += MyUC_Paint;
        }

        private void MyUC_MouseDown(object? sender, MouseEventArgs e)
        {
            this.Capture = false;
            if (e.Button == MouseButtons.Left)
            {
                Tools![(int)ActiveTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ActiveTool = MyToolType.Pointer;
            }
        }
        private void MyUC_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tools![(int)ActiveTool].OnMouseUp(this, e);
            }
        }
        private void MyUC_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                Tools![(int)ActiveTool].OnMouseMove(this, e);
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void MyUC_Paint(object? sender, PaintEventArgs e)
        {
            this.Graphics.Draw(e.Graphics);
            //画鼠标左键拖放范围的选择框
            if (IsDrawNetRectangle == true)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, NetRectangle, Color.Black, Color.Transparent);
            }
        }
    }
}
