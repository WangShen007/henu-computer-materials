namespace FuLuAWinForms
{
    public partial class LX17Form : Form
    {
        public LX17Form()
        {
            InitializeComponent();

            button1.Click += (s, e) =>
            {
                listBox1.Items.Clear();
                ChuZhanTongJi tj = new(100, 5, listBox1);
            };
        }
    }

    //出站人数统计
    class ChuZhanTongJi
    {
        public volatile int yingChuZhanRenShu;
        private readonly Object lockedObj = new();
        private readonly ListBox listBox1;

        /// <summary>
        /// 旅客出站统计
        /// </summary>
        /// <param name="shangCheRenShu">购票上车人数</param>
        /// <param name="chuZhanKouNum">出站口个数</param>
        /// <param name="listBox1"></param>
        public ChuZhanTongJi(int shangCheRenShu, int chuZhanKouNum, ListBox listBox1)
        {
            this.yingChuZhanRenShu = shangCheRenShu;
            this.listBox1 = listBox1;
            listBox1.Items.Add($"购票上车人数：{shangCheRenShu}");

            //给每个出站口创建1个线程，让旅客从多个口同时出站
            Thread[] threads = new Thread[chuZhanKouNum];
            for (int i = 0; i < chuZhanKouNum; i++)
            {
                Thread t = new(DoTransactions)
                {
                    Name = $"出站口{i + 1}"
                };
                threads[i] = t;
                threads[i].Start();
            }
        }

        /// <summary>（线程调用的方法）</summary>
        public void DoTransactions()
        {
            int n = 0;
            while (yingChuZhanRenShu > 0)
            {
                //模拟某旅客从该出站口出站
                ChuZhan();
                n++;
            }
            AddMessageToListBox($"{Thread.CurrentThread.Name}共出站 {n} 人。");
        }

        public void ChuZhan()
        {
            lock (lockedObj)
            {
                yingChuZhanRenShu--;
            }
            string str = $"{Thread.CurrentThread.Name}：出站1人";
            AddMessageToListBox(str);
        }

        public void AddMessageToListBox(string str)
        {
            listBox1.Invoke(() => { listBox1.Items.Add(str); });
        }
    }
}
