using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z08Stack : Page
    {
        public Z08Stack()
        {
            InitializeComponent();
            var v = new StackDemo();
            uc.Result.Text = v.Result;
        }
    }
    public class StackDemo
    {
        public string Result { get; set; } = "";
        public StackDemo()
        {
            Stack<string> numbers = new Stack<string>();
            //入栈
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");

            //出栈
            numbers.Pop();

            //输出
            foreach (string number in numbers)
            {
                Result += $"{number}\n";
            }
        }
    }
}
