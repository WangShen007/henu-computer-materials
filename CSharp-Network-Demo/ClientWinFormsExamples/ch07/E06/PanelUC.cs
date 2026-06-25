namespace ClientWinFormsExamples.ch07.E06
{
    public partial class PanelUC : UserControl
    {
        public ToolObject[] Tools { get; set; } = Array.Empty<ToolObject>();

        public ToolType ActiveTool { get; set; }

        /// <summary>绘图对象列表</summary>
        public GraphicsList Graphics { get; set; }= new GraphicsList();
        public MyTcpClient? MyClient { get; set; }

        /// <summary>绘制对象的唯一标识</summary>
        public int ID { get; set; } = 1;

        public PanelUC()
        {
            InitializeComponent();
            Graphics.UC1 = this;
        }

        /// <summary>找对应对象的id,如果找不到，返回-1，否则返回该对象的序号</summary>
        public int FindObjectIndex(int ID)
        {
            int index = -1;
            for (int i = 0; i < Graphics.Count; i++)
            {
                var a = Graphics[i];
                if (a != null)
                {
                    if (a.ID == ID)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        /// <summary>找对应对象的id,如果找不到，返回-1，否则返回该对象的序号</summary>
        public int FindObjectIndex()
        {
            int index = -1;
            for (int i = 0; i < Graphics.Count; i++)
            {
                var a = Graphics[i];
                if (a != null)
                {
                    if (a.ID == ID)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        /// <summary>是否画鼠标左键拖放范围的矩形框</summary>
        public bool IsDrawNetRectangle { get; set; } = false;

        /// <summary>鼠标左键拖放范围矩形大小及位置</summary>
        public Rectangle NetRectangle { get; set; }

        private void PanelUC_MouseDown(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            if (e.Button == MouseButtons.Left)
            {
                Tools![(int)ActiveTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ActiveTool = ToolType.Pointer;
            }
        }

        private void PanelUC_MouseMove(object sender, MouseEventArgs e)
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

        private void PanelUC_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Tools![(int)ActiveTool].OnMouseUp(this, e);
            }
        }

        private void PanelUC_Paint(object sender, PaintEventArgs e)
        {
            if(this.Graphics == null)
            {
                return;
            }
            Graphics.Draw(e.Graphics);
            //画鼠标左键拖放范围的选择框
            if (IsDrawNetRectangle == true)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, NetRectangle, Color.Black, Color.Transparent);
            }
        }
    }
}
