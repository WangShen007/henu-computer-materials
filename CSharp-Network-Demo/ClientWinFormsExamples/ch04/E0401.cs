namespace ClientWinFormsExamples.ch04
{
    public partial class E0401 : Form
    {
        public E0401()
        {
            InitializeComponent();
            var v1 = new C0401();
            var v2 = new C0401("李四", new DateTime(1998, 10, 15));
            label1.Text = $"{v1.Result}\n{v2.Result}";
        }
    }
    internal class C0401
    {
        //属性
        public string Result { get; private set; } = "";
        public string Name { get; } = "张三";
        public DateTime BirthDate { get; set; } = new DateTime(2005, 9, 13);
        //构造函数
        public C0401()
        {
            AddToResult();
        }
        public C0401(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            AddToResult();
        }
        //方法
        private void AddToResult()
        {
            Result += $"姓名：{Name}，出生日期：{BirthDate:yyyy-MM-dd}\n";
        }
    }
}
