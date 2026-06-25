namespace ClientWinFormsExamples.ch07.E01
{
    public partial class E0701MainForm : Form
    {
        public E0701MainForm()
        {
            InitializeComponent();
            buttonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object? sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var fm2 = new E0701PlayingTable("玩家2")
                {
                    Location = new Point(450, 400)
                };
                fm2.Show();
                var fm1 = new E0701PlayingTable("玩家1")
                {
                    Location = new Point(0, 0)
                };
                fm1.Show();
            }
            else
            {
                var fm = new E0701PlayingTable("玩家1");
                fm.ShowDialog();
            }
        }
    }
}
