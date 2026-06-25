using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z04Generic : Page
    {
        public Z04Generic()
        {
            InitializeComponent();
            var v = new GenericClassDemo();
            uc.Result.Text = v.Result;
        }
    }
    public class GenericClassDemo
    {
        public string Result { get; private set; } = "";
        public GenericClassDemo()
        {
            A<int> v1 = new A<int> { a = 5 };
            Result += $"a={v1.a}\n";
            A<string> v2 = new A<string> { a = "Hello" };
            Result += $"a={v2.a}\n";
            Pair<int, string> pair = new Pair<int, string>
            {
                First = 1,
                Second = "two"
            };
            Result += $"first={pair.First},second={pair.Second}";
        }
    }
    public class A<T>
    {
        public T a;
    }
    public class Pair<T1, T2>
    {
        public T1 First;
        public T2 Second;
    }
}
