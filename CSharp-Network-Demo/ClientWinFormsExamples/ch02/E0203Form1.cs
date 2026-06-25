namespace ClientWinFormsExamples.ch02
{
    public partial class E0203Form1 : Form
    {
        public E0203Form1()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"用户名：{textBoxUserName.Text}，密码：{textBoxPwd.Text}", "提示");
        }
    }
}
