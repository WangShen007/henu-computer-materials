namespace ClientWinFormsExamples.ch04
{
    public partial class E0402thisKey : Form
    {
        public E0402thisKey()
        {
            InitializeComponent();
            var c1 = new C0402();
            var c2 = new C0402("002", "李四");
            label1.Text = $"{c1.Result}\n{c2.Result}";
        }
    }
    internal class C0402
    {
        private readonly string id = "001";
        private readonly string name = "张三";
        public string Result { get; } = "";
        public C0402()
        {
            Result += $"id={id}，name={name}\n";
        }
        public C0402(string id, string name)
        {
            this.id = id;
            this.name = name;
            Result += $"id={id}，name={name}\n";
        }
    }
}
