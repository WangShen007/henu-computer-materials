namespace ClientWinFormsExamples.ch02
{
    public partial class E0203Form : Form
    {
        private E0203Form1? fm;
        public E0203Form()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (fm == null)
            {
                fm = new E0203Form1();
            }
            fm.Show();
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (fm != null)
            {
                fm.Hide();
            }
        }

        private void E0203Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fm != null)
            {
                fm.Close();
            }
        }
    }
}
