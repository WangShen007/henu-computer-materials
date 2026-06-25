namespace ClientWinFormsExamples.ch03
{
    public partial class E0311try_catch : Form
    {
        public E0311try_catch()
        {
            InitializeComponent();
            this.Text = "try-catch语句基本用法";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                string[] sArray = s.Split(',', '，');
                labelResult.Text = GetResult(sArray[0], sArray[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"出错了");
            }
        }
        public string GetResult(string n1, string n2)
        {
            string s = "";
            try
            {
                double x = double.Parse(n1);
                double y = double.Parse(n2);
                s = $"x/y = {Divide(x, y)}";
                return s;
            }
            catch (Exception err)
            {
                s = $"出错了：{err.Message}";
                return s;
            }
            finally
            {
                //此处一般做一些释放资源的操作
            }
        }
        private static double Divide(double x, double y)
        {
            if (y == 0) throw new Exception("除数不能为零！");
            return Math.Round(x / y, 2, MidpointRounding.AwayFromZero);
        }
    }
}
