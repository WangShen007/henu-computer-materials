namespace ClientWinFormsExamples.ch03
{
    public partial class E0306switch : Form
    {
        public E0306switch()
        {
            InitializeComponent();
            this.Text = "switch语句基本用法";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string? s = textBox1.Text;
            if (int.TryParse(s, out int x) == false)
            {
                MessageBox.Show("请确保输入的数据是整数！","转换失败");
                return;
            }
            label2.Text = $"结果为：{GetResult(x)}";
        }
        public static string GetResult(int grade)
        {
            string? result;
            if (grade < 0 || grade > 100)
            {
                result = "成绩不在0-100范围内";
            }
            else
            {
                result = (grade / 10) switch
                {
                    10 or 9 => "优秀",
                    8 or 7 => "良好",
                    6 => "及格",
                    _ => "不及格",
                };

                //上面的写法与下面的语句等价
                //switch (grade / 10)
                //{
                //    case 10:
                //    case 9: result = "优秀"; break;
                //    case 8:
                //    case 7: result = "良好"; break;
                //    case 6: result = "及格"; break;
                //    default: result = "不及格"; break;
                //}

            }
            return result;
        }
    }
}
