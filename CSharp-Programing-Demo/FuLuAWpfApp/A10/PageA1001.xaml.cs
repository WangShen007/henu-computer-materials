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
    /// PageA1001.xaml 的交互逻辑
    /// </summary>
    public partial class PageA1001 : Page
    {
        public PageA1001()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxA == null || textBoxR == null || textBoxG == null || textBoxB == null) return;
            if (byte.TryParse(textBoxA.Text, out byte A) == false
                || byte.TryParse(textBoxR.Text, out byte R) == false
                || byte.TryParse(textBoxG.Text, out byte G) == false
                || byte.TryParse(textBoxB.Text, out byte B) == false)
            {
                MessageBox.Show("输入有错，请修改！");
                return;
            }
            Color c = Color.FromArgb(A, R, G, B);
            SolidColorBrush sb = new SolidColorBrush(c);
            myRectangle.Fill = sb;
        }
    }
}
