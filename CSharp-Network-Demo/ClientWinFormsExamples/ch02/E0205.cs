namespace ClientWinFormsExamples.ch02
{
    public partial class E0205 : Form
    {
        public E0205()
        {
            InitializeComponent();
            labelMessage.Text = "";
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ShowResult();
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isCheckall = true;
            bool isUncheckAll = true;
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.CheckBox c)
                {
                    if (c.Checked)
                    {
                        isUncheckAll = false;
                    }
                    else
                    {
                        isCheckall = false;
                    }
                }
            }
            if (isCheckall)
            {
                checkBoxAll.CheckState = CheckState.Checked;
            }
            else if (isUncheckAll)
            {
                checkBoxAll.CheckState = CheckState.Unchecked;
            }
            else
            {
                checkBoxAll.CheckState = CheckState.Indeterminate;
            }
            ShowResult();
        }
        private void ShowResult()
        {
            string s = "选项为：";
            foreach (Control c in groupBox1.Controls)
            {
                if (c is System.Windows.Forms.RadioButton r)
                {
                    if (r.Checked) s += r.Text + "，";
                }
            }
            foreach (Control c in panel1.Controls)
            {
                if (c is System.Windows.Forms.CheckBox r)
                {
                    if (r.Checked) s += r.Text + "，";
                }
            }
            labelMessage.Text = s.TrimEnd('，');
        }
    }
}
