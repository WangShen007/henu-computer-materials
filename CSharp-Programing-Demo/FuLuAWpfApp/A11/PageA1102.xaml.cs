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

namespace FuLuAWpfApp.A11
{
    /// <summary>
    /// PageA1102.xaml 的交互逻辑
    /// </summary>
    public partial class PageA1102 : Page
    {
        public PageA1102()
        {
            InitializeComponent();
            btnDrawTriangle.Click += delegate
            {
                MyTriangle t = new MyTriangle(border1, int.Parse(textBoxA.Text), int.Parse(textBoxB.Text), int.Parse(textBoxAngle.Text));
                t.Draw();
                textBlock1.Text = t.GetArea().ToString();
                textBlock2.Text = t.IsEquilateralTriangle == true ? "是" : "否";
            };
            btnDrawRectangle.Click += delegate
            {
                MyRectangle r = new MyRectangle(border2, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                r.Draw();
                textBlock3.Text = r.GetArea().ToString();
                textBlock4.Text = r.IsEquilateral == true ? "是" : "否";
            };
        }
    }
}
