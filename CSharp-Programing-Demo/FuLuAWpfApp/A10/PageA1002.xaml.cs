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

namespace FuLuAWpfApp.A10
{
    /// <summary>
    /// PageA1002.xaml 的交互逻辑
    /// </summary>
    public partial class PageA1002 : Page
    {

        private Random r = new Random();

        public PageA1002()
        {
            InitializeComponent();

            btn.Click += delegate
            {
                int[] a = new int[20];
                string s = "";
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = r.Next(500);
                    s += a[i].ToString() + "  ";
                }
                textBlockNumbers.Text = s.TrimEnd();

                txtMinValue.Text = a.Min().ToString();
                txtAverageValue.Text = a.Average().ToString("#");
                txtMaxValue.Text = a.Max().ToString();
            };
        }
    }
}
