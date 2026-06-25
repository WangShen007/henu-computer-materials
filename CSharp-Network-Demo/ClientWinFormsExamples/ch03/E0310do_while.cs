namespace ClientWinFormsExamples.ch03
{
    public partial class E0310do_while : Form
    {
        const int n = 4;
        public E0310do_while()
        {
            InitializeComponent();
            this.Text = "do-while语句基本用法";
            //求n的阶乘
            int x = n;
            double result = 1;
            do
            {
                result *= x--;  //即result=result*x;x=x-1;
            } while (x > 1);
            label1.Text = $"{n}的阶乘为：{result}";
        }
    }
}
