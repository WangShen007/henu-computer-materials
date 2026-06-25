namespace ClientWinFormsExamples.ch03
{
    public partial class E0305if : Form
    {
        public E0305if()
        {
            InitializeComponent();
            this.Text = "if语句基本用法";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string? s = textBox1.Text;
            if (int.TryParse(s, out int x) == false)
            {
                MessageBox.Show("请确保输入的数据是整数！", "转换失败");
                return;
            }
            int y = Calculate(x);
            label2.Text = $"y的值为：{y}";
        }
        public static int Calculate(int x)
        {
            if (x > 0) return 1;
            else if (x == 0) return 0;
            else return -1;
        }
    }
}
