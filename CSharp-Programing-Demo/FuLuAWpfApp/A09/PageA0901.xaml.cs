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

namespace FuLuAWpfApp.A09
{
    /// <summary>
    /// PageA0901.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0901 : Page
    {
        private double d1;     //第1个数
        private double d2;     //第2个数
        private string oper;   //运算符
        private TextBlock current;  //当前表达式

        public PageA0901()
        {
            InitializeComponent();
            LabelErrorInfo.Visibility = System.Windows.Visibility.Hidden;
            InitNewValues();
        }

        private void InitNewValues()
        {
            d1 = double.NaN;   //第1个数
            d2 = double.NaN;   //第2个数
            oper = string.Empty;
            myTextBox.Text = "";  // ""与string.Empty作用相同
            current = new TextBlock();
            current.Text = "";
            myListBox.Items.Add(current);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] s1 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };
            string[] s2 = { "+", "-", "*", "/", "%" };
            Button btn = e.Source as Button;
            string s = btn.Content.ToString();
            if (s1.Contains(s))
            {
                LabelErrorInfo.Visibility = Visibility.Hidden;
                myTextBox.Text += s;
                return;
            }
            if (s2.Contains(s))
            {
                CheckValueString(s);
                return;
            }
            if (s == "CLR")
            {
                myListBox.Items.Clear();
                InitNewValues();
                return;
            }
            if (s == "=")
            {
                CalcResults();
            }
        }

        private void CheckValueString(string currentOper)
        {
            if (CheckValue(ref d1) == true)
            {
                myTextBox.Text = "";
                oper = currentOper;
            }
            else
            {
                oper = string.Empty;
            }
            current.Text = d1.ToString() + oper;
        }

        private bool CheckValue(ref double currentValue)
        {
            if (double.TryParse(myTextBox.Text, out currentValue) == false)
            {
                currentValue = double.NaN;
                LabelErrorInfo.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                LabelErrorInfo.Visibility = Visibility.Hidden;
                return true;
            }
        }

        private void CalcResults()
        {
            if (oper == string.Empty || d1 == double.NaN)
            {
                return;
            }
            if (CheckValue(ref d2) == false)  //d2有错
            {
                return;
            }
            string format = "{0}{1}{2}={3:0.####}";
            string s = "";
            switch (oper)
            {
                case "+":
                    s = string.Format(format, d1, oper, d2, d1 + d2);
                    break;
                case "-":
                    s = string.Format(format, d1, oper, d2, d1 - d2);
                    break;
                case "*":
                    s = string.Format(format, d1, oper, d2, d1 * d2);
                    break;
                case "/":
                    if (d2 == 0)
                    {
                        LabelErrorInfo.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        s = string.Format(format, d1, oper, d2, d1 / d2);
                    }
                    break;
                case "%":
                    if (d2 == 0)
                    {
                        LabelErrorInfo.Visibility = Visibility.Visible;
                        return;
                    }
                    else
                    {
                        s = string.Format(format, d1, oper, d2, d1 % d2);
                    }
                    break;
            }
            current.Text = s;
            InitNewValues();
        }
    }
}
