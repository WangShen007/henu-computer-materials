namespace ClientWinFormsExamples.ch07.E02
{
    public partial class E0702MainForm : Form
    {

        public E0702MainForm()
        {
            InitializeComponent();
            buttonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object? sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var fm2 = new ChatForm("用户2");
                fm2.Show();
                var fm1 = new ChatForm("用户1")
                {
                    Location = new Point(0, 0)
                };
                fm1.Show();
            }
            else
            {
                var fm = new ChatForm("用户1");
                fm.ShowDialog();
            }
        }
    }
}
