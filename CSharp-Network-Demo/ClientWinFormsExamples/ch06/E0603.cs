namespace ClientWinFormsExamples.ch06
{
    public partial class E0603 : Form
    {
        public E0603()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Thread[] threads = new Thread[10];
            Account acc = new(1000, listBox1);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new(acc.DoTransactions)
                {
                    Name = "线程" + i
                };
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
        }
    }

    class Account
    {
        private readonly Object lockedObj = new();
        int balance;
        readonly Random r = new();
        readonly ListBox listBox1;
        public Account(int initial, ListBox listBox1)
        {
            this.listBox1 = listBox1;
            this.balance = initial;
        }


        public void AddMessageToListBox(string str)
        {
            listBox1.Invoke(() => { listBox1.Items.Add(str); });
        }

        /// <summary>取款。amount：取款金额，返回：余额 </summary>
        private int Withdraw(int amount)
        {
            if (balance < 0)
            {
                AddMessageToListBox("余额：" + balance + " 已经为负值了，还想取呵！");
            }
            //将下面的lock (lockedObj)这行语句注释掉，看看会发生什么情况
            lock (lockedObj)
            {
                if (balance >= amount)
                {
                    string str = Thread.CurrentThread.Name + "取款---";
                    str += string.Format("取款前余额：{0,-6}取款：{1,-6}", balance, amount);
                    balance -= amount;
                    str += "取款后余额：" + balance;
                    AddMessageToListBox(str);
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>自动取款</summary>
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
}
