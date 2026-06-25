namespace ClientWinFormsExamples.ch04
{
    public partial class E0409Timer : Form
    {
        public E0409Timer()
        {
            InitializeComponent();
            label1.Text = "动画设计：张三\n\n美  工：李四\n\n代码设计：王五";
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Red;
            label1.Font = new Font("宋体", 19F, FontStyle.Regular, GraphicsUnit.Point);
            timer1.Interval = 30;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X, label1.Location.Y - 1);
            if (label1.Top <= -label1.Height)
            {
                label1.Top = this.ClientRectangle.Height + 10;
            }
        }
    }
}
