namespace FuLuAWinForms
{
    public partial class LX11Form : Form
    {
        public LX11Form()
        {
            InitializeComponent();
            this.Load += LX11Form_Load;
        }

        private void LX11Form_Load(object? sender, EventArgs e)
        {
            //（3）
            var d = new D();
            d.MyMethod(2);
            label1.Text = d.Result;
            var e1 = new E();
            e1.MyMethod(2);
            label1.Text += e1.Result;
        }
    }

    //（1）
    public class D
    {
        public string Result { get; protected set; } = "";
        public virtual void MyMethod(int num)
        {
            num += 10;
            Result += $"{num}\n";
        }
    }

    //（2）
    public class E : D
    {
        public override void MyMethod(int num)
        {
            num += 50;
            Result += $"{num}\n";
        }
    }
}
