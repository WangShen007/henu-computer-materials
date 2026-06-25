namespace ClientWinFormsExamples.ch04
{
    public partial class E0410Stopwatch : Form
    {
        readonly System.Diagnostics.Stopwatch stopwatch = new();
        readonly int n = 80;
        int n1;
        readonly Random random = new();
        public E0410Stopwatch()
        {
            InitializeComponent();
            label1.Text = "计时尚未开始";
            timer1.Tick += Timer1_Tick;
            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
        }

        private void ButtonStop_Click(object? sender, EventArgs e)
        {
            stopwatch.Stop();
            timer1.Stop();
            label1.Text = "已停止计时";
        }

        private void ButtonStart_Click(object? sender, EventArgs e)
        {
            label4.Text = "";
            n1 = 0;
            stopwatch.Reset();
            stopwatch.Start();
            timer1.Start();
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            DateTime dt1 = DateTime.FromBinary(stopwatch.Elapsed.Ticks);
            label1.Text = $"计时：{dt1:H 时 m 分 s 秒}";
            int seconds = (int)stopwatch.Elapsed.TotalSeconds;
            if (n - seconds == 0)
            {
                stopwatch.Stop();
                timer1.Stop();
                label1.Text = "时间到！";
            }
            if (seconds % 5 == 0 && seconds != n1)
            {
                n1 = seconds;
                int n2 = random.Next(1, 100);
                label4.Text += $"{n2}  ";
            }
        }
    }
}
