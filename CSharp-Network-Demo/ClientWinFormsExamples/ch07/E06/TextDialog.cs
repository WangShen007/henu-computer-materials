namespace ClientWinFormsExamples.ch07.E06
{
    public partial class TextDialog : Form
    {
        public string? MyText { get; set; }

        public Color MyColor { get; set; }

        public TextDialog()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.AcceptButton = buttonOK;
            this.CancelButton = buttonCancel;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            MyColor = Color.Black;
            textBox1.Text = "´ºÌìÀ´ÁË";
            buttonTextColor.Click += (s, e) =>
            {
                ColorDialog c = new();
                if (c.ShowDialog() == DialogResult.OK)
                {
                    MyColor = c.Color;
                    textBox1.ForeColor = MyColor;
                }
            };
            buttonOK.Click += (s, e) =>
            {
                MyText = textBox1.Text;
            };
            buttonCancel.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}