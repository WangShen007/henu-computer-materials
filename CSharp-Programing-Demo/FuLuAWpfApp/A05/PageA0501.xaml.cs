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
    /// PageA0501.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0501 : Page
    {
        public PageA0501()
        {
            InitializeComponent();

            //（4）
            Loaded += delegate
            {
                B b = new C();
                TextBlock1.Text = b.Result;
            };
        }
    }

    //（1）
    public class A
    {
        public string Result { get; protected set; } = "";
        public A()
        {
            Result += "A\n";
        }
    }

    //（2）
    public class B : A
    {
        public B()
        {
            Result += "B\n";
        }
    }

    //（3）
    public class C : B
    {
        public C()
        {
            Result += "C\n";
        }
    }

}
