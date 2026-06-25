namespace ClientWinFormsExamples.ch02
{
    public partial class E0207 : Form
    {
        public E0207()
        {
            InitializeComponent();
            button1.Size = new Size(imageList1.ImageSize.Width, imageList1.ImageSize.Height + 25);
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.ImageList = imageList1;
            button1.ImageIndex = 0;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ImageIndex = 1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ImageIndex = 0;
        }
    }
}
