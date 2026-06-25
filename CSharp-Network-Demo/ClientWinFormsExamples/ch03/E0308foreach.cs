namespace ClientWinFormsExamples.ch03
{
    public partial class E0308foreach : Form
    {
        public E0308foreach()
        {
            InitializeComponent();
            this.Text = "foreach语句基本用法";
            string[] a = new string[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = string.Format("{0,2}", i + 1);
            }
            string s = "";
            foreach (var v in a)
            {
                s += v + " ";
            }
            label1.Text = s;
        }
    }
}
