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
    /// PageA0303.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0303 : Page
    {
        public PageA0303()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                App.ExecConsoleApp("FuLuAConsoleApp.A03.A0303");
            };
        }
    }
}
