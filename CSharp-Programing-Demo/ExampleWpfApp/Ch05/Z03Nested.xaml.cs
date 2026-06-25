using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z03Nested : Page
    {
        public Z03Nested()
        {
            InitializeComponent();
            var v = new NestedClassDemo();
            uc.Result.Text = v.Result;

        }
    }
    public class NestedClassDemo
    {
        private int n = 10;
        public int N1 { get => n; set => n = value; }
        public int N2 { get; set; }
        public string Result { get; set; } = "";
        public NestedClassDemo()
        {
            InnerClass c = new InnerClass(this);
            c.GetResult();
        }
        private class InnerClass
        {
            private NestedClassDemo c;
            public InnerClass(NestedClassDemo c)
            {
                this.c = c;
            }
            public void GetResult()
            {
                c.n += 10;
                c.Result += $"N1={c.N1},N2={c.N2}";
            }
        }
    }
}
