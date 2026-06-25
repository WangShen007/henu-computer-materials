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

namespace ExampleWpfApp.Ch12
{
    public partial class Z03 : Page
    {
        public Z03()
        {
            InitializeComponent();
            r1.Checked += RadioButton_Checked;
            r2.Checked += RadioButton_Checked;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (((RadioButton)sender).Name == "r1")
            {
                ss.Transform3dMode = Wpfz.Transform3DTransMode.RotateBySelf;
            }
            else
            {
                ss.Transform3dMode = Wpfz.Transform3DTransMode.RotateAroundCenter;
            }
        }
    }
}
