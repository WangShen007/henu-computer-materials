using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E03staticKey : Page
    {
        public E03staticKey()
        {
            InitializeComponent();
            Loaded += delegate
            {
                C03.Hello1();
                var c = new C03();
                c.Hello2();
                uc.Result.Content = C03.Result;
            };
        }
    }
    class C03
    {
        public static string Result { get; set; } = "";
        static C03()
        {
            Result += "静态构造函数\t";
        }
        public C03()
        {
            Result += "实例构造函数\t";
        }
        public static void Hello1()
        {
            Result += "静态方法\n";
        }
        public void Hello2()
        {
            Result += "实例方法\n";
        }
    }
}
