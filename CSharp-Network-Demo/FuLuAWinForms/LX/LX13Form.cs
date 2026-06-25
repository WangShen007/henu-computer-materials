using System.Web;

namespace FuLuAWinForms
{
    public partial class LX13Form : Form
    {
        public LX13Form()
        {
            InitializeComponent();


            SortedList<int, string> list = new SortedList<int, string>
            {
                { 10, "str10" },
                { 2, "str2" },
                { 13, "str13" },
                { 24, "str24" },
                { 15, "str15" }
            };
            string space = new(' ', 8);
            string s = $"Key{space}Value\n";
            s += new string('-', 20) + "\n";
            var result = list.Reverse();
            foreach (var v in result)
            {
                s += $"{v.Key,-8}{v.Value}\n";
            }
            label1.Text = s;
        }
    }
}
