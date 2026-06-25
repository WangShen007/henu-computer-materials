namespace ClientWinFormsExamples.ch02
{
    public partial class E0204 : Form
    {
        public E0204()
        {
            InitializeComponent();
            labelMessage.Text = "";
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            string s = "选项为：";
            s += GetSelectedItem(groupBox1);
            s += GetSelectedItem(groupBox2);
            labelMessage.Text = s.TrimEnd('，');
        }
        private static string GetSelectedItem(GroupBox groupbox)
        {
            string s = "";
            foreach (Control c in groupbox.Controls)
            {
                if (c is RadioButton r)
                {
                    if (r.Checked) s += r.Text + "，";
                }
                //下面是另一种写法（两种写法是等价的）
                //RadioButton? r = c as RadioButton;
                //if (r != null)
                //{
                //    if (r.Checked) s += r.Text + "，";
                //}
            }
            return s;
        }
    }
}
