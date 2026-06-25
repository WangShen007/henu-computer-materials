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

namespace FuLuAWpfApp.A01
{
    public partial class PageA0104 : Page
    {
        public PageA0104()
        {
            InitializeComponent();
            Loaded += delegate
            {
                App.ExecConsoleApp("FuLuAConsoleApp.A01.A0104");
            };
        }
    }
}
