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

namespace ExampleWpfApp.Ch01
{
    public partial class E03HelloWorldPage : Page
    {
        public E03HelloWorldPage()
        {
            InitializeComponent();
            TextBlock1.Text = Wpfz.Ch01.HelloWorldWpfCustomControlLibrary.Result;
        }
    }
}
