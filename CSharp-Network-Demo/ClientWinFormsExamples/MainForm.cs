using System.Diagnostics;
namespace ClientWinFormsExamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            foreach (Control control in this.Controls)
            {
                if (control is LinkLabel linkLabel)
                {
                    linkLabel.Click += LinkLabel_Click;
                }
            }
        }
        private void LinkLabel_Click(object? sender, EventArgs e)
        {
            if (sender is LinkLabel linkLabel)
            {
                Form? fm = null;
                switch (linkLabel.Text)
                {
                    case "例2-3": fm = new ch02.E0203Form(); break;
                    case "例2-4": fm = new ch02.E0204(); break;
                    case "例2-5": fm = new ch02.E0205(); break;
                    case "例2-6": fm = new ch02.E0206(); break;
                    case "例2-7": fm = new ch02.E0207(); break;

                    case "例3-1": fm = new ch03.E0301enum(); break;
                    case "例3-2": fm = new ch03.E0302string(); break;
                    case "例3-3": fm = new ch03.E0303array(); break;
                    case "例3-4": fm = new ch03.E0304convert(); break;
                    case "例3-5": fm = new ch03.E0305if(); break;
                    case "例3-6": fm = new ch03.E0306switch(); break;
                    case "例3-7": fm = new ch03.E0307for(); break;
                    case "例3-8": fm = new ch03.E0308foreach(); break;
                    case "例3-9": fm = new ch03.E0309while(); break;
                    case "例3-10": fm = new ch03.E0310do_while(); break;
                    case "例3-11": fm = new ch03.E0311try_catch(); break;

                    case "例4-1": fm = new ch04.E0401(); break;
                    case "例4-2": fm = new ch04.E0402thisKey(); break;
                    case "例4-3": fm = new ch04.E0403staticKey(); break;
                    case "例4-4": fm = new ch04.E0404Method(); break;
                    case "例4-5": fm = new ch04.E0405Property(); break;
                    case "例4-6": fm = new ch04.E0406Event(); break;
                    case "例4-7": fm = new ch04.E0407Math(); break;
                    case "例4-8": fm = new ch04.E0408DateTime(); break;
                    case "例4-9": fm = new ch04.E0409Timer(); break;
                    case "例4-10": fm = new ch04.E0410Stopwatch(); break;
                    case "例4-11": fm = new ch04.E0411(); break;
                    case "例4-12": fm = new ch04.E0412(); break;
                    case "例4-13": fm = new ch04.E0413(); break;

                    case "例5-1": fm = new ch05.E0501(); break;
                    case "例5-2": fm = new ch05.E0502(); break;
                    case "例5-3": fm = new ch05.E0503(); break;
                    case "例5-4": fm = new ch05.E0504(); break;
                    case "例5-5": fm = new ch05.E0505(); break;
                    case "例5-6": fm = new ch05.E0506(); break;

                    case "例6-1": fm = new ch06.E0601(); break;
                    case "例6-2": fm = new ch06.E0602(); break;
                    case "例6-3": fm = new ch06.E0603(); break;
                    case "例6-4": fm = new ch06.E0604(); break;
                    case "例6-5": fm = new ch06.E0605(); break;

                    case "例7-1": fm = new ch07.E01.E0701MainForm(); break;
                    case "例7-2": fm = new ch07.E02.E0702MainForm(); break;
                    case "例7-3": fm = new ch07.E03.E0703MainForm(); break;
                    case "例7-4": fm = new ch07.E04.E0704MainForm(); break;
                    case "例7-5": fm = new ch07.E05.E0705MainForm(); break;
                    case "例7-6": fm = new ch07.E06.E0706MainForm(); break;

                    case "例8-1": fm = new ch08.E01.E0801UdpChat(); break;
                    case "例8-2": fm = new ch08.E02.E0802AsyncUdpChat(); break;
                    case "例8-3": fm = new ch08.E03.E0803Broadcast(); break;
                    case "例8-4": fm = new ch08.E04.E0804Meeting(); break;

                }
                if (fm != null)
                {
                    fm.StartPosition = FormStartPosition.CenterScreen;
                    fm.ShowDialog();
                }
            }
        }
    }
}
