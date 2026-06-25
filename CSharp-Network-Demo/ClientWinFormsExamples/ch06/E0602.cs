namespace ClientWinFormsExamples.ch06
{
    public partial class E0602 : Form
    {
        private readonly MyClass c;
        public E0602()
        {
            InitializeComponent();
            textBox1.Text = "";
            c = new(textBox1);
            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void ButtonStart_Click(object? sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            textBox1.Text = "";
            c.IsStop = false;
            MyData state = new() { Message = "a", Info = "\r\n线程1已终止" };
            Thread thread1 = new(c.MyMethod)
            {
                IsBackground = true
            };
            thread1.Start(state);
            state = new MyData { Message = "b", Info = "\r\n线程2已终止" };
            Thread thread2 = new(c.MyMethod)
            {
                IsBackground = true
            };
            thread2.Start(state);

            state = new MyData { Message = "c", Info = "\r\n线程3已终止" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(c.MyMethod), state);

            state = new MyData { Message = "d", Info = "\r\n线程4已终止" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(c.MyMethod), state);
        }

        private void ButtonStop_Click(object? sender, EventArgs e)
        {
            c.IsStop = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

    }
    public class MyClass
    {
        public volatile bool IsStop;
        private readonly TextBox textBox1;
        public MyClass(TextBox textBox1)
        {
            this.textBox1 = textBox1;
        }
        public void MyMethod(Object? obj)
        {
            if (obj is not MyData state) return;
            while (IsStop == false)
            {
                AddMessage(state.Message);
                Thread.Sleep(200);   //当前线程休眠200ms
            }
            AddMessage(state.Info);
        }
        private void AddMessage(string s)
        {
            textBox1.Invoke(() =>
            {
                textBox1.Text += s;
            });
        }
    }
    public class MyData
    {
        public string Info { get; set; } = "";
        public string Message { get; set; } = "";
    }

}
