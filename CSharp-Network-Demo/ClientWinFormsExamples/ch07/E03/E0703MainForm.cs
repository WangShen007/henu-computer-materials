namespace ClientWinFormsExamples.ch07.E03
{
    public partial class E0703MainForm : Form
    {
        public E0703MainForm()
        {
            InitializeComponent();
            buttonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object? sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var fm2 = new E0703PlayingTable("玩家2")
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(450, 200)
                };
                fm2.Show();
                var fm1 = new E0703PlayingTable("玩家1")
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(0, 0)
                };
                fm1.Show();
            }
            else
            {
                var fm = new E0703PlayingTable("玩家1");
                fm.ShowDialog();

            }
        }
    }
}
