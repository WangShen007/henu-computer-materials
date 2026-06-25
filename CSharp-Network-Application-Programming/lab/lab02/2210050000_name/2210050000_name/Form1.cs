namespace _2210050000_name
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int count = 0;

        private void Login_Click(object sender, EventArgs e)
        {
            if (password.Text == "sonder")
            {
                MessageBox.Show($"您输入的用户名是:{Username.Text}\n,您输入的密码是:{password.Text}\n,密码正确");
                mainForm mainForm = new mainForm();
                mainForm.Show();
            }
            else
            {
                if (count < 2)
                {
                    count++;
                    MessageBox.Show($"您输入的用户名是:{Username.Text}\n,您输入的密码是:{password.Text}\n,密码错误\n您已经输错{count}次\n如果输入错误三次,窗口将会关闭");
                }
                else
                {
                    MessageBox.Show("输错三次,窗口关闭");
                    this.Close();
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            passwordshow.Text = password.Text;
        }
    }
}
