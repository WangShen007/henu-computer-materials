namespace ClientWinFormsExamples.ch03
{
    public partial class E0307for : Form
    {
        public E0307for()
        {
            InitializeComponent();
            this.Text = "for语句基本用法";
            string s = "";
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    s += string.Format("{0}×{1}={2,2}{3,3}", j, i, i * j, ' ');
                }
                s += "\n";
            }
            label1.Text = s;
        }
    }
}
