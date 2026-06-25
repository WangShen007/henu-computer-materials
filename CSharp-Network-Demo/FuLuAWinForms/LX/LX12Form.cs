namespace FuLuAWinForms
{
    public partial class LX12Form : Form
    {
        public LX12Form()
        {
            InitializeComponent();

            Random r = new();
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(r.Next());
            }
        }
    }
}
