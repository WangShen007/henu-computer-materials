using System.Diagnostics;
using System.Windows.Forms;

namespace FuLuAWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            foreach (Control control in panel2.Controls)
            {
                if (control is LinkLabel label)
                {
                    label.Click += LinkLabel_LinkClicked;
                }
            }
        }

        private void LinkLabel_LinkClicked(object? sender, EventArgs e)
        {
            if (sender is LinkLabel label)
            {
                Form fm;
                switch (label.Tag)
                {
                    case "LX02": fm = new LX02Form(); fm.ShowDialog(); break;
                    case "LX09": fm = new LX09Form(); fm.ShowDialog(); break;
                    case "LX10": fm = new LX10Form(); fm.ShowDialog(); break;
                    case "LX11": fm = new LX11Form(); fm.ShowDialog(); break;
                    case "LX12": fm = new LX12Form(); fm.ShowDialog(); break;
                    case "LX13": fm = new LX13Form(); fm.ShowDialog(); break;
                    case "LX14": fm = new LX14Form(); fm.ShowDialog(); break;
                    case "LX15": fm = new LX15Form(); fm.ShowDialog(); break;
                    case "LX17": fm = new LX17Form(); fm.ShowDialog(); break;
                    case "LX18": fm = new LX18Form(); fm.ShowDialog(); break;
                    case "SY02": fm = new SY02Form(); fm.ShowDialog(); break;
                    case "SY05": fm = new SY05Form(); fm.ShowDialog(); break;
                    case "SY06": fm = new SY06Form(); fm.ShowDialog(); break;
                    case "SY07": fm = new SY07Form(); fm.ShowDialog(); break;
                    case "SY08": fm = new SY08Form(); fm.ShowDialog(); break;
                    case "SY09": fm = new SY09Form(); fm.ShowDialog(); break;
                }
            }
        }
    }
}