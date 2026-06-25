namespace FuLuAWinForms
{
    public partial class SY06Form : Form
    {
        Random r = new Random();
        const int min = 1;  //随机数最小为1
        const int max = 31;  //随机数最大为30（=31-1）
        readonly System.Windows.Forms.Timer timer = new();
        readonly int maxTime = 25;  //限时25秒
        int count;

        public SY06Form()
        {
            InitializeComponent();

            groupBox1.Enabled = false;
            btnStart.Enabled = true;
            btnOK.Enabled = false;
            timer.Interval = 1000;
            timer.Tick += delegate
            {
                if (count == 0)
                {
                    CheckResult();
                }
                else
                {
                    count--;
                    textBoxCount.Text = count.ToString();
                }
            };
            btnStart.Click += delegate
            {
                count = maxTime;
                textBoxCount.Text = count.ToString();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                label1.Text = string.Format("1、{0}+{1}=", r.Next(min, max), r.Next(min, max));
                label2.Text = string.Format("2、{0}-{1}=", r.Next(min, max), r.Next(min, max));
                label3.Text = string.Format("3、{0}*{1}=", r.Next(10, max), r.Next(min, 11));
                int a1, a2;
                do
                {
                    a1 = r.Next(10, max);
                    a2 = r.Next(min, 11);
                } while ((a1 * 100) % a2 != 0);
                label4.Text = string.Format("4、{0}/{1}=", a1, a2);
                groupBox1.Enabled = true;
                timer.Start();
                btnStart.Enabled = false;
                btnOK.Enabled = true;
            };
            btnOK.Click += delegate
            {
                CheckResult();
            };
        }
        private void CheckResult()
        {
            timer.Stop();
            groupBox1.Enabled = false;
            btnStart.Enabled = true;
            btnOK.Enabled = false;

            string[] s1 = label1.Text.ToString().Split('、', '+', '=');
            string[] s2 = label2.Text.ToString().Split('、', '-', '=');
            string[] s3 = label3.Text.ToString().Split('、', '*', '=');
            string[] s4 = label4.Text.ToString().Split('、', '/', '=');
            try
            {
                if (int.Parse(s1[1]) + int.Parse(s1[2]) == int.Parse(textBox1.Text)
                    && int.Parse(s2[1]) - int.Parse(s2[2]) == int.Parse(textBox2.Text)
                    && int.Parse(s3[1]) * int.Parse(s3[2]) == int.Parse(textBox3.Text)
                    && int.Parse(s4[1]) / (double)int.Parse(s4[2]) == double.Parse(textBox4.Text))
                {
                    MessageBox.Show("恭喜，过关成功。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("过关失败，请继续努力。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("过关失败，请继续努力。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
