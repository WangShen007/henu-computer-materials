namespace ClientWinFormsExamples.ch03
{
    public partial class E0309while : Form
    {
        public E0309while()
        {
            InitializeComponent();
            this.Text = "while语句基本用法";
            int x = 1;
            string s = "";
            while (x <= 20)
            {
                if (x % 3 == 0) s += x.ToString() + " ";
                x++;
            }
            label1.Text = $"1到20以内所有能被3整除的自然数有：{s}";
        }
    }
}
