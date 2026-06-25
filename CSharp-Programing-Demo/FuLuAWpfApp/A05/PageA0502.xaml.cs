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
    public partial class PageA0502 : Page
    {
        public PageA0502()
        {
            InitializeComponent();

            //（3）
            Loaded += delegate
            {
                var d = new D();
                 d.MyMethod(2);
                TextBlock1.Text += d.Result;
                var e = new E();
                e.MyMethod(2);
                TextBlock1.Text += e.Result;
            };
        }
    }

    //（1）
    public class D
    {
        public string Result { get; protected set; } = "";
        public virtual void MyMethod(int num)
        {
            num += 10;
            Result += $"{num}\n";
        }
    }

    //（2）
    public class E : D
    {
        public override void MyMethod(int num)
        {
            num += 50;
            Result += $"{num}\n";
        }
    }
}
