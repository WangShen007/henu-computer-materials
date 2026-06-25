namespace ClientWinFormsExamples.ch07.E05
{
    public partial class E0705MainForm : Form
    {
        public E0705MainForm()
        {
            InitializeComponent();

            myuc1.Tools = new MyToolObject[Enum.GetNames(typeof(MyToolType)).Length];
            myuc1.Tools[(int)MyToolType.Pointer] = new MyToolPointer();
            myuc1.Tools[(int)MyToolType.Curve] = new MyToolCurve();
            myuc1.Tools[(int)MyToolType.ArrowCurve] = new MyToolArrowCurve();
            MyCC.UC1 = myuc1;
            radioButtonHandle.Click += RadioButtonHandle_Click;
            radioButtonCurve.Click += RadioButtonCurve_Click;
            radioButtonArrowCurve.Click += RadioButtonArrowCurve_Click;
            myuc1.MouseDown += PanelUc1_MouseDown;
        }
        private void PanelUc1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                radioButtonHandle.Checked = true;
            }
        }
        private void RadioButtonHandle_Click(object? sender, EventArgs e)
        {
            myuc1.ActiveTool = MyToolType.Pointer;

        }
        private void RadioButtonCurve_Click(object? sender, EventArgs e)
        {
            myuc1.ActiveTool = MyToolType.Curve;
        }
        private void RadioButtonArrowCurve_Click(object? sender, EventArgs e)
        {
            myuc1.ActiveTool = MyToolType.ArrowCurve;
        }
    }
}
