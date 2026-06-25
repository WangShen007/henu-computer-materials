namespace ClientWinFormsExamples.ch04
{
    public partial class E0403staticKey : Form
    {
        public E0403staticKey()
        {
            InitializeComponent();
            C0403.Hello1();
            var c = new C0403();
            c.Hello2();
            label1.Text = C0403.Result;
        }
    }
    internal class C0403
    {
        public static string Result { get; set; } = "";
        static C0403()
        {
            Result += "这个是C0403类的静态构造函数\n";
        }
        public C0403()
        {
            Result += "这个是C0403类的实例构造函数\n";
        }
        public static void Hello1()
        {
            Result += "这个是C0403类中的静态方法\n";
        }
        public void Hello2()
        {
            Result += "这个是C0403类中的实例方法";
        }
    }
}
