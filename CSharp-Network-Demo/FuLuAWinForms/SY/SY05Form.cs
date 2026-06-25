namespace FuLuAWinForms
{
    public partial class SY05Form : Form
    {
        private System.Windows.Forms.Timer timer1 = new();
        private int min, max;
        private Font oldFont;
        private Font newFont;
        private bool isIntRandom = true;
        public SY05Form()
        {
            InitializeComponent();

            labelResult.Text = "";
            oldFont = new Font(labelResult.Font.FontFamily.Name, 16);
            newFont = new Font(labelResult.Font.FontFamily.Name, 32);
            timer1.Tick += delegate
            {
                if (isIntRandom)
                {
                    int r = RandomHelp.GetIntRandomNumber(min, max + 1);
                    labelResult.Text = r.ToString();
                }
                else
                {
                    double r = RandomHelp.GetDoubleRandomNumber(min, max + 1);
                    labelResult.Text = r.ToString();
                }
            };
            btnStart.Click += delegate
            {
                InitParameters();
                SetState(true);
                timer1.Start();
            };
            btnStop.Click += delegate
            {
                timer1.Stop();
                SetState(false);
            };
            InitParameters();
            SetState(false);
        }

        private void InitParameters()
        {
            if (int.TryParse(textBoxInterval.Text, out int inteval) == true)
            {
                timer1.Interval = inteval;
            }
            else
            {
                textBoxInterval.Text = "100";
                timer1.Interval = 100;
            }
            if (int.TryParse(textBoxMin.Text, out min) == false)
            {
                textBoxMin.Text = "0";
                min = 0;
            }
            if (int.TryParse(textBoxMax.Text, out max) == false)
            {
                textBoxMax.Text = "100";
                max = 100;
            }
            if (radioButton1.Checked == true)
            {
                isIntRandom = true;
            }
            else
            {
                isIntRandom = false;
            }
        }

        private void SetState(bool isStarted)
        {
            btnStop.Enabled = isStarted;
            groupBox1.Enabled = !isStarted;
            btnStart.Enabled = !isStarted;
            if (isStarted)
            {
                labelResult.Font = oldFont;
            }
            else
            {
                labelResult.Font = newFont;
            }
        }

    }

    class RandomHelp
    {
        private static Random r = new Random();
        /// <summary>
        /// 获取指定范围的随机整数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>随机产生的整数</returns>
        public static int GetIntRandomNumber(int min, int max)
        {
            return r.Next(min, max + 1);
        }

        /// <summary>
        /// 获取指定范围的随机浮点数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>随机产生的浮点数</returns>
        public static double GetDoubleRandomNumber(int min, int max)
        {
            double d = max * r.NextDouble();
            if (d < min)
            {
                d += min;
            }
            return Math.Min(d, max);
        }
    }
}
