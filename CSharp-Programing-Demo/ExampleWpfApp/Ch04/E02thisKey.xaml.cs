using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E02thisKey : Page
    {
        public E02thisKey()
        {
            InitializeComponent();
            Loaded += delegate
            {
                var c = new C02("002", "李四");
                uc.Result.Content = c.Result;
            };
        }
    }
    class C02
    {
        private readonly string id = "001";
        private readonly string name = "张三";
        public string Result { get; } = "";
        public C02()
        {
            Result += $"id={id}，name={name}\n";
        }
        public C02(string id, string name) : this()
        {
            this.id = id;
            this.name = name;
            Result += $"id={id}，name={name}\n";
        }
    }
}
