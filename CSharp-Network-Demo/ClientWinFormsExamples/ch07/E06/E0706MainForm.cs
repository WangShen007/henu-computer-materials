namespace ClientWinFormsExamples.ch07.E06
{
    public partial class E0706MainForm : Form
    {
        public E0706MainForm()
        {
            InitializeComponent();
            buttonOK.Click += ButtonOK_Click;
        }

        private void ButtonOK_Click(object? sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var fm1 = new E0706DrawForm("张三")
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(450, 0)
                };
                fm1.Show();
                var fm2 = new E0706DrawForm("李四")
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(450, 400)
                };
                fm2.Show();
            }
            else
            {
                var fm = new E0706DrawForm("张三")
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(450, 200)
                };
                fm.ShowDialog();
            }
        }
    }
}
