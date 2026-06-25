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

namespace FuLuAWpfApp.A03
{
    /// <summary>
    /// PageA0308.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0308 : Page
    {
        public PageA0308()
        {
            InitializeComponent();
            labelResult.Content = "";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (labelResult == null) return;
            string p = "";
            labelResult.Content = "";
            string s = (e.Source as RadioButton).Content.ToString();
            switch (s)
            {
                case "加法": p = "+"; break;
                case "减法": p = "-"; break;
                case "乘法": p = "*"; break;
                case "除法": p = "/"; break;
                case "取模": p = "%"; break;
            }
            label1.Content = p;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double n1) || !double.TryParse(textBox2.Text, out double n2))
            {
                labelResult.Content = "?"; return;
            }
            string result = "", format = "{0:0.####}", s = label1.Content.ToString();
            switch (s)
            {
                case "+":
                    result = string.Format(format, n1 + n2);
                    break;
                case "-":
                    result = string.Format(format, n1 - n2);
                    break;
                case "*": result = string.Format(format, n1 * n2); break;
                case "/":
                    if (n2 == 0) result = "?";
                    else result = string.Format(format, n1 / n2);
                    break;
                case "%":
                    if (n2 == 0) result = "?";
                    else result = string.Format(format, n1 % n2);
                    break;
            }
            labelResult.Content = result;
        }
    }
}
