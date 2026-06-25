using ClientWinFormsExamples.ch07.E04;

namespace ClientWinFormsExamples.ch07.E04
{
    public partial class E0704MainForm : Form
    {
        private enum MyToolType
        {
            /// <summary>矩形</summary>
            Rectangle,
            /// <summary>椭圆</summary>
            Ellipse,
            /// <summary>工具个数</summary>
            Count
        };
        private MyToolType toolType = MyToolType.Rectangle;
        private readonly List<DrawMyObject> graphicsList = new();

        public E0704MainForm()
        {
            InitializeComponent();

            radioButtonEllipse.Click += RadioButtonEllipse_Click;
            radioButtonRectangle.Click += RadioButtonRectangle_Click;
            btnClear.Click += BtnClear_Click;
            panel1.MouseDown += new MouseEventHandler(Panel1_MouseDown);
            panel1.MouseMove += new MouseEventHandler(Panel1_MouseMove);
            panel1.Paint += Panel1_Paint;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void RadioButtonEllipse_Click(object? sender, EventArgs e)
        {
            toolType = MyToolType.Ellipse;
        }

        private void RadioButtonRectangle_Click(object? sender, EventArgs e)
        {
            toolType = MyToolType.Rectangle;
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Clear();
            graphicsList.Clear();
            panel1.Refresh();
        }

        private void Panel1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (toolType == MyToolType.Rectangle)
                {
                    DrawMyObject w = new DrawMyRectangle(e.X, e.Y, 1, 1, Color.Red);
                    graphicsList.Add(w);
                    listBox1.Items.Add($"对象{listBox1.Items.Count + 1}：矩形");
                }
                else if (toolType == MyToolType.Ellipse)
                {
                    DrawMyObject w = new DrawMyEllipse(e.X, e.Y, 1, 1, Color.Red);
                    graphicsList.Add(w);
                    listBox1.Items.Add($"对象{listBox1.Items.Count + 1}：椭圆");
                }
                panel1.Refresh();
            }
        }

        private void Panel1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (graphicsList.Count > 0)
                {
                    var myObject = graphicsList.Last();
                    if (myObject is DrawMyRectangle w1)
                    {
                        int x = w1.Rect.X;
                        int y = w1.Rect.Y;
                        Rectangle rect = new(x, y, e.X - x, e.Y - y);
                        w1.Rect = rect;
                    }
                    else if (myObject is DrawMyEllipse w2)
                    {
                        int x = w2.Rect.X;
                        int y = w2.Rect.Y;
                        w2.Rect = new Rectangle(x, y, e.X - x, e.Y - y);
                    }
                    panel1.Refresh();
                }
            }
        }

        private void Panel1_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var g in graphicsList)
            {
                g.Draw(e.Graphics);
            }
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                foreach (var w in graphicsList)
                {
                    w.PenColor = Color.Red;
                }
                DrawMyObject dw = graphicsList[listBox1.SelectedIndex];
                dw.PenColor = Color.Blue;
                panel1.Refresh();
            }
        }
    }
}


