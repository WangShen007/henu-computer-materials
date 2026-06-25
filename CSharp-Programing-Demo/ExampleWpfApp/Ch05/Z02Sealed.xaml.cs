using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z02Sealed : Page
    {
        public Z02Sealed()
        {
            InitializeComponent();
            var v = new SealedClassDemo();
            uc.Result.Text = v.Result;
        }
    }
    public class SealedClassDemo
    {
        public string Result { get; set; } = "";
        public SealedClassDemo()
        {
            E10A b = new E10B();
            Result = b.MethodA();
        }
    }
    public class E10A
    {
        protected string result = "";
        public virtual string MethodA()
        {
            result += "Class A, MethodA\n";
            return result;
        }
    }
    public sealed class E10B : E10A
    {
        public override sealed string MethodA()
        {
            result += "Class B, MethodA\n";
            return result;
        }
    }
}
