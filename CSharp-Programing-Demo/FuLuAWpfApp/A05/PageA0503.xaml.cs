using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A05
{
    /// <summary>
    /// PageA0503.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0503 : Page
    {
        public PageA0503()
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
            string s = "Key\t Value\n";
            s += new string('-', 20) + "\n";
            var result = list.Reverse();
            foreach (var v in result)
            {
                s += $"{v.Key}\t{v.Value}\n";
            }
            TextBlock1.Text = s;
        }
    }
}
