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

namespace FuLuAWpfApp.A02
{
    /// <summary>
    /// PageA0201.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0201 : Page
    {
        public PageA0201()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                App.ExecConsoleApp("FuLuAConsoleApp.A02.A0201");
            };
        }
    }
}
