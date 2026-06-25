using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z05HashSet : Page
    {
        public Z05HashSet()
        {
            InitializeComponent();
            var v = new HashSetDemo();
            uc.Result.Text = v.Result;

        }
    }
    public class HashSetDemo
    {
        public string Result { get; }
        public HashSetDemo()
        {
            HashSet<int> h1 = new HashSet<int> { 1, 3, 5 };
            Result = $"h1=[{Output(h1)}]\n";
            HashSet<int> h2 = new HashSet<int> { 1, 3, 7, 8 };
            Result += $"h2=[{Output(h2)}]\n";
            h1.UnionWith(h2);
            Result += $"求并集后，h1=[{Output(h1)}]\n";
        }
        private string Output(HashSet<int> h)
        {
            string r = "";
            foreach (var v in h)
            {
                r += $"{v},";
            }
            return r.TrimEnd(',');
        }
    }
}
