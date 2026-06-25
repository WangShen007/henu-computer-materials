namespace ClientWinFormsExamples.ch04
{
    public partial class E0411 : Form
    {
        public E0411()
        {
            InitializeComponent();
            A a1 = new B();
            a1.M1();
            a1.M2();
            a1.M3();
            label1.Text = $"A a1 = new B()的执行结果：\n{a1.R}\n";
            A a2 = new C();
            a2.M1();
            a2.M2();
            a2.M3();
            label1.Text += $"A a2 = new C()的执行结果：\n{a2.R}\n";
        }
    }
    public abstract class A
    {
        public string R { get; set; } = "";
        public A()
        {
            R += "调用了A的构造函数\n";
        }
        public void M1()
        {
            R += "调用了A.M1方法\n";
        }
        public abstract void M2();
        public virtual void M3()
        {
            R += "调用了A.M3方法\n";
        }
    }
    public class B : A
    {
        public B()
        {
            R += "调用了B的构造函数\n";
        }
        public new void M1()
        {
            R += "调用了B.M1方法\n";
        }
        public override void M2()
        {
            R += "调用了B.M2方法\n";
        }
        public override void M3()
        {
            R += "调用了B.M3方法\n";
        }
    }
    public class C : B
    {
        public C()
        {
            R += "调用了C的构造函数\n";
        }
        public new void M1()
        {
            R += "调用了C.M1方法\n";
        }
        public override void M2()
        {
            R += "调用了C.M2方法\n";
        }
        public new void M3()
        {
            R += "调用了C.M3方法\n";
        }
    }
}
